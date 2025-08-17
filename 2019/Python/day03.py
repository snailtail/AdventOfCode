# Parse the input and extract the paths of the two wires
with open('input_day03.txt') as f:
    wire1_instructions = f.readline().strip().split(',')
    wire2_instructions = f.readline().strip().split(',')

# Define helper functions for moving along the grid and computing the Manhattan distance

def move(x, y, direction, distance):
    if direction == 'U':
        return x, y + distance
    elif direction == 'D':
        return x, y - distance
    elif direction == 'L':
        return x - distance, y
    elif direction == 'R':
        return x + distance, y

def manhattan_distance(x, y):
    return abs(x) + abs(y)

# Simulate the paths of the two wires and store the visited coordinates in sets
wire1_visited = {}
x, y = 0, 0
steps = 0

for instruction in wire1_instructions:
    direction, distance = instruction[0], int(instruction[1:])
    for _ in range(distance):
        x, y = move(x, y, direction, 1)
        steps += 1
        wire1_visited[(x, y)] = steps

wire2_visited = {}
x, y = 0, 0
steps = 0

for instruction in wire2_instructions:
    direction, distance = instruction[0], int(instruction[1:])
    for _ in range(distance):
        x, y = move(x, y, direction, 1)
        steps += 1
        wire2_visited[(x, y)] = steps

# Compute the intersection of the sets of visited coordinates
print(set(wire1_visited.keys()))
intersections = set(wire1_visited.keys()).intersection(set(wire2_visited.keys()))

# Compute the Manhattan distances from the origin to the intersection points and return the minimum
min_distance = float('inf')

for x, y in intersections:
    distance = manhattan_distance(x, y)
    min_distance = min(min_distance, distance)

print(min_distance)

min_steps = float('inf')

for intersection in intersections:
    stepsum=wire1_visited[intersection]+wire2_visited[intersection]
    min_steps = min(stepsum, min_steps)

print(min_steps)


