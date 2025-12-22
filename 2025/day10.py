"""
Day 10: Factory
"""

import re
from collections import deque


class Machine:
    def __init__(self, line: str):
        self.raw = line.strip()

        # Extract light diagram (from inside the square brackets)
        pattern_match = re.search(r"\[([.#]+)\]", self.raw)
        if not pattern_match:
            raise ValueError(f"No pattern found in line: {self.raw}")
        self.pattern_str = pattern_match.group(1)  # Example: ".##."
        self.num_lights = len(self.pattern_str)

        # Calculate bitmask for target state
        #    least significant bit to the left, most significant bit to the right to match the order of the wiring schemes
        self.target_mask = self._pattern_to_mask(self.pattern_str)

        # 3. Extract all the buttons from ( ... )
        button_parts = re.findall(r"\(([^)]*)\)", self.raw)
        self.button_masks = [self._button_to_mask(part) for part in button_parts]

        # 3. Joltages: new structure for part 2
        joltage_match = re.search(r"\{([^}]*)\}", self.raw)
        if joltage_match:
            # ex: "3,5,4,7" -> ["3","5","4","7"] -> (3,5,4,7)
            self.target_counters = tuple(
                int(x) for x in joltage_match.group(1).split(",")
            )
        else:
            self.target_counters = tuple()

        self.num_counters = len(self.target_counters)

        # 4. Precompute per-button counter deltas for BFS in part 2
        #    For each button: a tuple of length num_counters with 0/1 per counter.
        self.button_counter_deltas = []
        for mask in self.button_masks:
            delta = []
            for i in range(self.num_counters):
                # om knappen påverkar counter i → +1
                if mask & (1 << i):
                    delta.append(1)
                else:
                    delta.append(0)
            self.button_counter_deltas.append(tuple(delta))

    def _pattern_to_mask(self, pattern: str) -> int:
        """
        ".##." -> bitmask for the wanted state
        Bit 0 = first light (left), bit 1 = second light, and so on
        """
        mask = 0
        for i, ch in enumerate(pattern):
            if ch == "#":
                mask |= 1 << i
        return mask

    def _button_to_mask(self, token: str) -> int:
        """
        "3"         -> toggles light 3
        "1,3"       -> toggles lights 1 and 3
        """
        token = token.strip()
        if not token:
            return 0
        indexes = [int(x) for x in token.split(",")]
        mask = 0
        for idx in indexes:
            mask |= 1 << idx
        return mask

    def min_presses_bruteforce(self) -> int | None:
        """
        Calculates least amount of button presses for this machine using pure bruteforce.
        Returns None if no solution is found
        """
        target = self.target_mask
        buttons = self.button_masks
        m = len(buttons)

        best = None  # best so far

        # loop over all subsets of buttons - which are 0..(2^m - 1) - , or range(1 << m) in python.
        # example, if m is 7, 1 << 7 == 128, so we loop from 0 to 127
        for mask in range(1 << m):
            # if the mask already has more presses than our best solution so far, skip!
            if best is not None and mask.bit_count() >= best:
                continue

            state = 0
            # XOR together all the button masks for all the buttons we press... I think :D
            for i in range(m):
                if mask & (
                    1 << i
                ):  # if we're supposed to push this button now in this combo
                    state ^= buttons[i]

            # Check for a match
            if state == target:
                presses = mask.bit_count()
                if (
                    best is None or presses < best
                ):  # store as best if it is lower or if best isn't set yet
                    best = presses

        return best

    def min_presses_joltage_bfs(self) -> int | None:
        """
        Part 2: BFS i "counter space".
        Returnerar minsta antal knapptryck för att nå target_counters,
        eller None om det är omöjligt.
        """
        useful_deltas = []
        for delta in self.button_counter_deltas:
            if any(
                delta[i] > 0 and self.target_counters[i] > 0
                for i in range(self.num_counters)
            ):
                useful_deltas.append(delta)

        self.button_counter_deltas = useful_deltas

        target = self.target_counters
        k = self.num_counters

        for i in range(self.num_counters):
            if self.target_counters[i] > 0:
                # kolla om någon delta har 1 i position i
                if all(delta[i] == 0 for delta in self.button_counter_deltas):
                    return None

        # Om maskinen inte har några joltages definierade
        if k == 0:
            return 0

        start = tuple(0 for _ in range(k))
        if start == target:
            return 0

        # BFS-queue: (state, presses_so_far)
        queue = deque()
        queue.append((start, 0))

        # Besökta states, så vi inte loopar
        visited = {start}
        states_explored = 0
        while queue:
            state, presses = queue.popleft()
            states_explored += 1

            # Prova att trycka på varje knapp en gång
            for delta in self.button_counter_deltas:
                # Bygg next_state = state + delta
                new_vals = []
                overshoot = False
                for i in range(k):
                    val = state[i] + delta[i]
                    if val > target[i]:
                        overshoot = True
                        break
                    new_vals.append(val)

                if overshoot:
                    continue

                next_state = tuple(new_vals)

                if next_state in visited:
                    continue

                if next_state == target:
                    return presses + 1  # en knapptryckning till

                visited.add(next_state)
                queue.append((next_state, presses + 1))

        # Ingen lösning hittades
        print("States explored for this machine:", states_explored)
        return None

    def __str__(self):
        return (
            f"Machine(pattern='{self.pattern_str}', "
            f"target_mask={bin(self.target_mask)}, "
            f"buttons={len(self.button_masks)}, "
            f"target_counters={self.target_counters})"
        )


def setup(path="testinput_day10.dat") -> list[Machine]:
    """
    Parses input and returns a list of Machine
    """
    input = []
    with open(path, "r") as f:
        for row in f:
            input.append(Machine(row.strip()))

    return input


if __name__ == "__main__":
    machines = setup("testinput_day10.dat")
    # print(machines)
    part1_fewest_buttonpresses_total = 0
    part2_fewest_buttonpresses_total = 0
    for machine in machines:
        part1_fewest_buttonpresses_total += machine.min_presses_bruteforce()
        part2_fewest_buttonpresses_total += machine.min_presses_joltage_bfs()
    print("Part 1:", part1_fewest_buttonpresses_total)
    print("Part 2:", part2_fewest_buttonpresses_total)
