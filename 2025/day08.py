"""
Day 8: Playground
"""
import math

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
            (self.x - other.x)**2 +
            (self.y - other.y)**2 +
            (self.z - other.z)**2
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
    #sorted_points = sorted(input, key=lambda p: p.distance_from_origin)
    #input.sort(key = lambda p: p.distance_from_origin)

    #return sorted_points
    return input

def get_pairs_with_distances(coordinates):
    """
        Takes a list of Coordinate and calculates distances between pairs.
        Returns a list representing (Distance, Coord x, Coord y)
    """
    pairs = []
    for i in range(len(coordinates)):
        for j in range(i+1, len(coordinates)):
            p1 = coordinates[i]
            p2 = coordinates[j]
            dist = p1.distance_to(p2)
            pairs.append((dist, i, j))

    pairs.sort(key=lambda x: x[0])

    return pairs



if __name__ == "__main__":
    coordinates = setup("testinput_day08.dat")
    pairs = get_pairs_with_distances(coordinates)
    print(f"Found {len(pairs)} combinations of pairs")
    for d, c1, c2 in pairs:
        print(d, c1, c2)
