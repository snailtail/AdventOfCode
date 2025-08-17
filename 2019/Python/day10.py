import math

#  Step 1 
#  Read the map from the input
with open('input_day10.txt','r') as f:
    map = [l.rstrip() for l in f.readlines()]

# Function to compute the angle between two asteroids
def angle(ax, ay, bx, by):
    # Compute the difference in x and y coordinates
    dx = bx - ax
    dy = by - ay
    # Compute the angle in radians
    theta = math.atan2(dy, dx)
    # Convert the angle to degrees
    return theta * 180 / math.pi

# Find the best asteroid
max_asteroids = 0
max_x = 0
max_y = 0
for y in range(len(map)):
    for x in range(len(map[y])):
        if map[y][x] == '#':
            # This is an asteroid, so we need to check how many other
            # asteroids it can see
            angles = set()
            for y2 in range(len(map)):
                for x2 in range(len(map[y2])):
                    if map[y2][x2] == '#':
                        # This is another asteroid, so we need to check
                        # if it can be seen from the current asteroid
                        if (x, y) != (x2, y2):
                            # Compute the angle to the other asteroid
                            theta = angle(x, y, x2, y2)
                            # If the angle is not already in the set,
                            # then the asteroid can be seen
                            if theta not in angles:
                                angles.add(theta)
            # Update the maximum number of asteroids seen
            if len(angles) > max_asteroids:
                max_asteroids = len(angles)
                max_x = x
                max_y = y

# Print the result
print(f"The best asteroid is at {max_x},{max_y} with {max_asteroids} other asteroids detected")

# Step 2
# Parse the input

# Parse the input
grid = []
station_x=0
station_y=0

with open("input_day10.txt") as f:
    for line in f:
        grid.append(list(line.strip()))

# Find the location of the station
for y in range(len(grid)):
    for x in range(len(grid[y])):
        if grid[y][x] == "X":
            station_x = x
            station_y = y

# Function to find the angle between two points
def angle(x1, y1, x2, y2):
    return math.atan2(y2 - y1, x2 - x1)

# Function to find the distance between two points
def distance(x1, y1, x2, y2):
    return math.sqrt((x2 - x1)**2 + (y2 - y1)**2)

# Function to find the coordinates of the nth asteroid to be vaporized
def nth_vaporized(n):
    # Dictionary to store the angles and distances of all asteroids
    angles_and_distances = {}
    for y in range(len(grid)):
        for x in range(len(grid[y])):
            if grid[y][x] == "#":
                # Calculate the angle and distance from the station
                a = angle(station_x, station_y, x, y)
                d = distance(station_x, station_y, x, y)
                # Add the asteroid to the dictionary, grouped by angle
                if a not in angles_and_distances:
                    angles_and_distances[a] = [(d, x, y)]
                else:
                    angles_and_distances[a].append((d, x, y))
    
    # Sort the asteroids by angle and distance
    sorted_angles_and_distances = []
    for a in sorted(angles_and_distances.keys()):
        sorted_angles_and_distances.extend(sorted(angles_and_distances[a]))
    
    # Return the coordinates of the nth asteroid to be vaporized
    return sorted_angles_and_distances[n-1][1:]

# Find the 200th asteroid to be vaporized
x, y = nth_vaporized(200)

# Multiply the X coordinate by 100 and add the Y coordinate
result = x * 100 + y

# Print the result
print(result)
