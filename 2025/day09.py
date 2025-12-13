"""
Day 9: Movie Theater
"""


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


def setup(path="testinput_day09.dat") -> list[Coordinate]:
    """
        Parses input and returns a list of coordinates
        Example: [(1,2),(2,3),(0,8)]
    """
    input = []
    with open(path, "r") as f:
        for row in f:
            (x, y) = list(map(int, [x for x in row.strip().split(",")]))

            input.append(Coordinate(x, y))
    return input


def get_pairs_with_distances(coordinates: list[Coordinate]) -> list[(int, int, int)]:
    """
        Takes a list of Coordinate and calculates distances between pairs.
        Returns a list representing (Distance, Coord x, Coord y)
    """
    pairs = []
    for i in range(len(coordinates)):
        for j in range(i + 1, len(coordinates)):
            c1 = coordinates[i]
            c2 = coordinates[j]
            dist = c1.distance_to(c2)
            pairs.append((dist, i, j))

    pairs.sort(key=lambda x: x[0], reverse=True)

    return pairs


def get_pairs_with_area(coordinates: list[Coordinate]):
    """
        Takes a list of Coordinate and calculates area of a rectangle between those two corners.
        Returns a list representing (Distance, Coord x, Coord y)
    """
    pairs = []
    for i in range(len(coordinates)):
        for j in range(i + 1, len(coordinates)):
            c1 = coordinates[i]
            c2 = coordinates[j]
            area = get_area(c1, c2)
            pairs.append((area, i, j))

    pairs.sort(key=lambda x: x[0], reverse=True)

    return pairs


def get_area(c1, c2):
    """
        Takes two coordinates and calculates the area
    """
    return (abs(c1.x - c2.x) + 1) * (abs(c1.y - c2.y) + 1)


def get_edges(coordinate_list: list[Coordinate]):
    """
        Takes in a list of Coordinate and joins them together as edges
        Returns a list of Edge
    """
    edge_list = []
    for i in range(1, len(coordinate_list)):
        coord1 = coordinate_list[i - 1]
        coord2 = coordinate_list[i]

        edge_list.append(Edge(coord1.x, coord1.y, coord2.x, coord2.y))

    # Connect the last and the first coordinates as an edge as well
    coord1 = coordinate_list[-1]
    coord2 = coordinate_list[0]

    edge_list.append(Edge(coord1.x, coord1.y, coord2.x, coord2.y))

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


def point_in_polygon(px: float, py: float, edges: list[Edge]) -> bool:
    """
        Checks if a point is inside of a polygon, receives a point and a list of edges.
        Returns Bool
        Author: ChatGPT
    """
    # På-kanten → "inne"
    for e in edges:
        # vertikal kant
        if e.x1 == e.x2:
            x = e.x1
            y1, y2 = sorted((e.y1, e.y2))
            if px == x and y1 <= py <= y2:
                return True
        # horisontell kant
        if e.y1 == e.y2:
            y = e.y1
            x1, x2 = sorted((e.x1, e.x2))
            if py == y and x1 <= px <= x2:
                return True

    inside = False

    for e in edges:
        # Vi bryr oss bara om vertikala kanter för "ray to the right"
        if e.x1 != e.x2:
            continue

        x = e.x1
        y1, y2 = sorted((e.y1, e.y2))

        # Kollar om strålen y = py från px→+∞ korsar kanten
        # Konvention: inkludera nedre änden, exkludera övre (min <= py < max)
        if y1 <= py < y2 and x > px:
            inside = not inside

    return inside


def edge_intersects_rect_interior(
    edge: Edge, xmin: int, xmax: int, ymin: int, ymax: int
) -> bool:
    # Vertical edge, x = constant
    if edge.x1 == edge.x2:
        x = edge.x1
        y1, y2 = sorted((edge.y1, edge.y2))

        # If edge is strictly inside the x interval
        if xmin < x < xmax:
            # Overlap y w recangle insides?
            if max(y1, ymin) < min(y2, ymax):
                return True
        return False

    # Horizontal edge, y = constant
    if edge.y1 == edge.y2:
        y = edge.y1
        x1, x2 = sorted((edge.x1, edge.x2))

        if ymin < y < ymax:
            if max(x1, xmin) < min(x2, xmax):
                return True
        return False

    # We should never end up here...
    return False


def rectangle_inside_polygon(c1: Coordinate, c2: Coordinate, edges: list[Edge]) -> bool:
    xmin, xmax, ymin, ymax = get_rect_from_coords(c1, c2)

    # A recangle consisting of only a line let's skip these since we probably won't find one with a large area
    if xmin == xmax or ymin == ymax:
        return False

    # Find the center of the rectangle
    cx = (xmin + xmax) / 2.0
    cy = (ymin + ymax) / 2.0

    # If the middle is not inside the polygon the rectangle is not completely inside either.
    if not point_in_polygon(cx, cy, edges):
        return False

    # Make sure that no edge cuts through the inside of the rectangle (costly, but I don't understand enough to avoid doing this)
    for e in edges:
        if edge_intersects_rect_interior(e, xmin, xmax, ymin, ymax):
            return False

    # The center of the rectangle is inside the polygon, and no edges cut through the inside of the rectangle -> the rectangle is completely inside the polygon
    return True


if __name__ == "__main__":
    coordinates = setup("testinput_day09.dat")

    pairs = get_pairs_with_area(coordinates)

    # part 1 is the largest area - which we now have in a
    p1_max_area, _, _ = pairs[0]
    print("Part 1:", p1_max_area)

    # For part 2 we need to get the edges
    edges = get_edges(coordinates)
    p2_max_area = 0
    for area, c1, c2 in pairs:
        if rectangle_inside_polygon(coordinates[c1], coordinates[c2], edges):
            p2_max_area = area
            break

    print("Part 2:", p2_max_area)
