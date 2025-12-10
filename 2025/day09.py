"""
Day 9: Movie Theater
"""


import math

class Coordinate:
    def __init__(self, x, y):
        self.x = x
        self.y = y
        
    @property
    def distance_from_origin(self):
        return self.x + self.y

    def distance_to(self, other):
        return abs(self.x - other.x) + abs(self.y - other.y)
        

    def __repr__(self):
        return f"Coordinate({self.x}, {self.y})"
    
class Edge:
    def __init__(self, x1, y1, x2, y2):
        self.x1 = x1
        self.y1 = y1
        self.x2 = x2
        self.y2 = y2

    def __repr__(self):
        return f"Edge({self.x1},{self.y1}, {self.x2},{self.y2})"


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

    pairs.sort(key=lambda x: x[0],reverse=True)

    return pairs

def get_area(c1,c2):
    """
        Takes two coordinates and calculates the area

    """
    return (abs(c1.x - c2.x) + 1) * (abs(c1.y - c2.y) + 1)

def setup(path="testinput_day09.dat"):
    """
    Parses input and returns a list of coordinates
    Example: [(1,2),(2,3),(0,8)]
           
    """
    input = []
    with open(path, "r") as f:
        for row in f:
            (x, y) = list(map(int, [x for x in row.strip().split(",")]))
            

            input.append(Coordinate(x,y))
    return input

def get_edges(coordinate_list):
    """
    Takes in a list of Coordinate and joins them together as edges
    Returns a list of Edge
    """
    edge_list = []
    for i in range(1, len(coordinate_list)):
        coord1 = coordinate_list[i-1]
        coord2 = coordinate_list[i]

        edge_list.append(Edge(coord1.x,coord1.y,coord2.x,coord2.y))
    
    # Connect the last and the first coordinates as an edge as well
    coord1 = coordinate_list[-1]
    coord2 = coordinate_list[0]

    edge_list.append(Edge(coord1.x,coord1.y,coord2.x,coord2.y))

    return edge_list

def get_rect_from_coords(c1: Coordinate, c2: Coordinate):
    """
    Takes in two coordinates and returns the corners of the rectangle they create
    """
    xmin = min(c1.x, c2.x)
    xmax = max(c1.x, c2.x)
    ymin = min(c1.y, c2.y)
    ymax = max(c1.y, c2.y)
    return xmin, xmax, ymin, ymax



if __name__ == "__main__":
    coordinates = setup("testinput_day09.dat")
    
    print(coordinates)
    p1_pairs = get_pairs_with_distances(coordinates)
    p1_max_area = 0
    for (pair_distance,i,j) in p1_pairs:
        
        area = get_area(coordinates[i], coordinates[j])
        print(area,coordinates[i], coordinates[j])
        p1_max_area = max(area,p1_max_area)
        

    print("Part 1:", p1_max_area)

    # For part 2 we need to get the edges
    edges = get_edges(coordinates)
    print(edges)
    
