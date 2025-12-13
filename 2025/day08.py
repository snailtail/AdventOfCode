"""
Day 8: Playground
"""

import math


class DisjointSet:
    def __init__(self, n):
        self.parent = list(range(n))
        self.size = [1] * n

    def find(self, x):
        # hitta rot (med path compression)
        if self.parent[x] != x:
            self.parent[x] = self.find(self.parent[x])
        return self.parent[x]

    def union(self, a, b):
        ra = self.find(a)
        rb = self.find(b)
        if ra == rb:
            return False  # redan samma krets

        # union by size
        if self.size[ra] < self.size[rb]:
            ra, rb = rb, ra

        self.parent[rb] = ra
        self.size[ra] += self.size[rb]
        return True


class Coordinate:
    def __init__(self, x, y, z):
        self.x = x
        self.y = y
        self.z = z

    @property
    def distance_from_origin(self):
        return math.sqrt(self.x**2 + self.y**2 + self.z**2)

    def distance_to(self, other):
        return math.sqrt(
            (self.x - other.x) ** 2 + (self.y - other.y) ** 2 + (self.z - other.z) ** 2
        )

    def __repr__(self):
        return f"Coordinate({self.x}, {self.y}, {self.z})"


def setup(path="testinput_day08.dat"):
    """
    Parses input and returns a list of Coordinates representing junction boxes
    Example:

    """
    input = []
    with open(path, "r") as f:
        for row in f:
            (x, y, z) = list(map(int, [x for x in row.strip().split(",")]))
            mycoord = Coordinate(x, y, z)

            input.append(mycoord)
    # sorted_points = sorted(input, key=lambda p: p.distance_from_origin)
    # input.sort(key = lambda p: p.distance_from_origin)

    # return sorted_points
    return input


def get_pairs_with_distances(coordinates):
    """
    Takes a list of Coordinate and calculates distances between pairs.
    Returns a list representing (Distance, Coord x index, Coord y index)
    """
    pairs = []
    for i in range(len(coordinates)):
        for j in range(i + 1, len(coordinates)):
            p1 = coordinates[i]
            p2 = coordinates[j]
            dist = p1.distance_to(p2)
            pairs.append((dist, i, j))

    pairs.sort(key=lambda x: x[0])

    return pairs


def apply_shortest_connections(num_points, pairs, k):
    ds = DisjointSet(num_points)

    # pairs måste vara sorterade på dist redan
    for idx, (dist, a, b) in enumerate(pairs):
        if idx >= k:
            break
        ds.union(a, b)  # om de redan sitter ihop händer inget

    return ds


def part1(data, num_points, depth):
    roots = set()
    ds = apply_shortest_connections(num_points, data, depth)
    for i in range(num_points):
        roots.add(ds.find(i))

    circuit_sizes = [ds.size[root] for root in roots]
    circuit_sizes.sort(reverse=True)
    return math.prod(circuit_sizes[0:3])


def part2(coordinates, pairs):
    n = len(coordinates)
    ds = DisjointSet(n)
    component_count = n
    last_a = last_b = None

    for dist, i, j in pairs:
        if ds.union(i, j):  # bara om en verklig sammanslagning sker
            component_count -= 1
            last_a, last_b = i, j  # den senaste kopplingen som gjorde skillnad
            if component_count == 1:
                break

    x1 = coordinates[last_a].x
    x2 = coordinates[last_b].x
    return x1 * x2


if __name__ == "__main__":
    coordinates = setup("testinput_day08.dat")
    pairs = get_pairs_with_distances(coordinates)

    p1 = part1(pairs, 20, 10)  # for test input
    # p1 = part1(pairs,1000,1000) # for prod input
    print("Part 1:", p1)

    p2 = part2(coordinates, pairs)  # for test input
    print("Part2:", p2)
