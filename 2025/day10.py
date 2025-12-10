"""
Day 10: Factory
"""

import re

class Machine:
    def __init__(self, line: str):
        self.raw = line.strip()

        # Extract light diagram (from inside the square brackets)
        pattern_match = re.search(r'\[([.#]+)\]', self.raw)
        if not pattern_match:
            raise ValueError(f"No pattern found in line: {self.raw}")
        self.pattern_str = pattern_match.group(1) # Example: ".##."
        self.num_lights = len(self.pattern_str)

        # Calculate bitmask for target state
        #    least significant bit to the left, most significant bit to the right to match the order of the wiring schemes
        self.target_mask = self._pattern_to_mask(self.pattern_str)

        # 3. Plocka ut alla knappar i ( ... )
        #    re.findall ger t.ex. ["3", "1,3", "2", ...]
        button_parts = re.findall(r'\(([^)]*)\)', self.raw)
        self.button_masks = [self._button_to_mask(part) for part in button_parts]

        # 4. Plocka ut joltage i { ... } (kan ignoreras senare)
        joltage_match = re.search(r'\{([^}]*)\}', self.raw)
        if joltage_match:
            self.joltages = [int(x) for x in joltage_match.group(1).split(",")]
        else:
            self.joltages = []

    def _pattern_to_mask(self, pattern: str) -> int:
        """
        ".##." -> bitmask for the wanted state
        Bit 0 = first light (left), bit 1 = second light, and so on
        """
        mask = 0
        for i, ch in enumerate(pattern):
            if ch == '#':
                mask |= (1 << i)
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
            mask |= (1 << idx)
        return mask
    
    def min_presses_bruteforce(self) -> int | None:
        """
        Beräknar minsta antal knapptryck för denna maskin med ren brute force.
        Returnerar None om ingen lösning finns (borde inte hända om input är korrekt).
        """
        target = self.target_mask
        buttons = self.button_masks
        m = len(buttons)

        best = None  # bästa hittills

        # loop over all subsets of buttons - which are 0..(2^m - 1) - , or range(1 << m) in python.
        # example, if m is 7, 1 << 7 == 128, so we loop from 0 to 127
        for mask in range(1 << m):
            # litet pruning: om masken redan har fler tryck än vår bästa lösning
            if best is not None and mask.bit_count() >= best:
                continue

            state = 0
            # XOR together all the button masks for all the buttons we press... I think :D
            for i in range(m):
                if mask & (1 << i): # if we're supposed to push this button now in this combo
                    state ^= buttons[i]

            # Kolla match
            if state == target:
                presses = mask.bit_count()
                if best is None or presses < best:
                    best = presses

        return best


    def __repr__(self):
        return (
            f"Machine(pattern='{self.pattern_str}', "
            f"target_mask={bin(self.target_mask)}, "
            f"buttons={len(self.button_masks)}, "
            f"joltages={self.joltages})"
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
    machines = setup("input_day10.dat")
    
    part1_fewest_buttonpresses_total = 0
    for machine in machines:
        part1_fewest_buttonpresses_total += machine.min_presses_bruteforce()
    print("Part 1:", part1_fewest_buttonpresses_total)
