import sys
from aoc import inpututil as iu
import os

file=os.path.basename(__file__).replace('.py','')
util = iu()

def bfs(map, start, end):
    coord_queue = [(start, 0)]
    checked = set()
    best_score = int(sys.maxsize)

    while len(coord_queue) > 0:
        (current, score) = coord_queue.pop(0)

        if current == end:
            if score < best_score:
                best_score = score
            continue

        if current in checked:
            continue

        checked.add(current)

        # Store the result of each directions relative impact on the current position as coordinates
        up = (current[0], current[1] - 1)
        down = (current[0], current[1] + 1)
        left = (current[0] - 1, current[1])
        right = (current[0] + 1, current[1])

        # Perform a check in each of the four directions, for this coordinate.
        for dir in [up, down, left, right]:
            # are we inside the map?
            if dir[0] >= 0 and dir[0] < len(map[0]) and dir[1] >= 0 and dir[1] < len(map):
                current_elevation = map[current[1]][current[0]]

                # The starting point also counts as being at elevation level a
                if current_elevation == "S":
                    current_elevation = "a"

                new_elevation = map[dir[1]][dir[0]]

                if new_elevation == "E":
                    new_elevation = "z"

                # Using the ascii values for the character at the position on the map to evaluate elevation level
                if ord(current_elevation) + 1 >= ord(new_elevation):
                    coord_queue.append((dir, score + 1))

    return best_score



def main():
    puzzlemap = util.GetCharMap(file, test=False)
    start = (0, 0)
    end = (0, 0)
    a_positions = []
    for (y, row) in enumerate(puzzlemap):
        for (x, col) in enumerate(row):
            if col == "S":
                start = (x, y)
            elif col == "E":
                end = (x, y)
            elif col == "a":
                a_positions.append((x, y))

    print("Part one: {}".format(bfs(puzzlemap, start, end)))
    print("Part two: {}".format(min([bfs(puzzlemap, a, end) for a in a_positions])))

if __name__ == "__main__":
    main()