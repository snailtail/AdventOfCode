from pathlib import Path
import pytest

from day09 import setup, Coordinate, get_area, get_edges, Edge, get_rect_from_coords, get_pairs_with_area, point_in_polygon, edge_intersects_rect_interior, rectangle_inside_polygon


def parse_testdata(path="testinput_day09.dat"):
    base_path = Path(__file__).parent.parent
    input = setup(base_path / path)
    return input


@pytest.mark.parametrize("index, expected_x, expected_y", [
    (0,7,1),
    (1,11,1),
    (2,11,7),
    (3,9,7),
    (4,9,5),
    (5,2,5),
    (6,2,3),
    (7,7,3),
    ])
def test_parse(index,expected_x, expected_y):
    coords = parse_testdata()
    coordinate = coords[index]
    assert coordinate.x == expected_x
    assert coordinate.y == expected_y

def test_get_area():
    expected = 50
    c1 = Coordinate(11,1)
    c2 = Coordinate(2,5)
    result = get_area(c1,c2)
    assert result == expected

    expected = 18
    c1 = Coordinate(7,1)
    c2 = Coordinate(2,3)
    result = get_area(c1,c2)
    assert result == expected

@pytest.mark.parametrize("expected_area, coordinate1, coordinate2", [
    (50, Coordinate(11, 1), Coordinate(2, 5)),
    (50, Coordinate(11, 7), Coordinate(2, 3)),
    (30, Coordinate(11, 1), Coordinate(2, 3)),
    (30, Coordinate(11, 7), Coordinate(2, 5)),
    (40, Coordinate(9, 7), Coordinate(2, 3)),
    (35, Coordinate(7, 1), Coordinate(11, 7)),
    (30, Coordinate(7, 1), Coordinate(2, 5)),
    (24, Coordinate(9, 7), Coordinate(2, 5)),
    (24, Coordinate(9, 5), Coordinate(2, 3)),
    (21, Coordinate(7, 1), Coordinate(9, 7)),
    (21, Coordinate(11, 1), Coordinate(9, 7)),
    (25, Coordinate(11, 7), Coordinate(7, 3)),
    (18, Coordinate(7, 1), Coordinate(2, 3)),
    (8, Coordinate(9, 5), Coordinate(2, 5)),
    (18, Coordinate(2, 5), Coordinate(7, 3)),
    (15, Coordinate(7, 1), Coordinate(9, 5)),
    (7, Coordinate(11, 1), Coordinate(11, 7)),
    (15, Coordinate(11, 1), Coordinate(9, 5)),
    (15, Coordinate(11, 1), Coordinate(7, 3)),
    (15, Coordinate(9, 7), Coordinate(7, 3)),
    (6, Coordinate(2, 3), Coordinate(7, 3)),
    (5, Coordinate(7, 1), Coordinate(11, 1)),
    (9, Coordinate(11, 7), Coordinate(9, 5)),
    (9, Coordinate(9, 5), Coordinate(7, 3)),
    (3, Coordinate(7, 1), Coordinate(7, 3)),
    (3, Coordinate(11, 7), Coordinate(9, 7)),
    (3, Coordinate(9, 7), Coordinate(9, 5)),
    (3, Coordinate(2, 5), Coordinate(2, 3)),
    ])
def test_get_areas(expected_area, coordinate1, coordinate2):
    
    result = get_area(coordinate1,coordinate2)
    assert result == expected_area

def test_build_edges_example():
    # Exempeldata från problemets beskrivning
    coords = [
        Coordinate(7,1),
        Coordinate(11,1),
        Coordinate(11,7),
        Coordinate(9,7),
        Coordinate(9,5),
        Coordinate(2,5),
        Coordinate(2,3),
        Coordinate(7,3)
    ]

    edges = get_edges(coords)

    # Förväntade kanter i exakt ordning
    expected = [
        (7,1, 11,1),
        (11,1, 11,7),
        (11,7, 9,7),
        (9,7, 9,5),
        (9,5, 2,5),
        (2,5, 2,3),
        (2,3, 7,3),
        (7,3, 7,1),   # sista kanten tillbaka till början
    ]

    # Testa antal kanter
    assert len(edges) == len(expected)

    # Testa varje kant individuellt
    for edge, (x1, y1, x2, y2) in zip(edges, expected):
        assert edge.x1 == x1
        assert edge.y1 == y1
        assert edge.x2 == x2
        assert edge.y2 == y2

def test_get_rect_from_coords_order_independent():
    c1 = Coordinate(2, 5)
    c2 = Coordinate(11, 1)

    xmin, xmax, ymin, ymax = get_rect_from_coords(c1, c2)
    assert (xmin, xmax, ymin, ymax) == (2, 11, 1, 5)

    # Byt ordning – resultatet ska bli detsamma
    xmin2, xmax2, ymin2, ymax2 = get_rect_from_coords(c2, c1)
    assert (xmin2, xmax2, ymin2, ymax2) == (2, 11, 1, 5)

def example_coords():
    return [
        Coordinate(7,1),
        Coordinate(11,1),
        Coordinate(11,7),
        Coordinate(9,7),
        Coordinate(9,5),
        Coordinate(2,5),
        Coordinate(2,3),
        Coordinate(7,3),
    ]


def test_point_in_polygon_inside_outside_and_border():
    coords = example_coords()
    edges = get_edges(coords)

    # En punkt tydligt inne i loopen (ungefär mitt i "grönt" området)
    assert point_in_polygon(8.0, 4.0, edges) is True

    # En punkt tydligt utanför
    assert point_in_polygon(1.0, 1.0, edges) is False

    # En punkt exakt på en kant (ska räknas som inne enligt din implementation)
    assert point_in_polygon(7.0, 1.0, edges) is True

def test_edge_intersects_rect_interior_vertical():
    # Rektangel: [0,10] x [0,10]
    xmin, xmax, ymin, ymax = 0, 10, 0, 10

    # Vertikal kant inne i rektangeln
    e_inside = Edge(5, -5, 5, 15)
    assert edge_intersects_rect_interior(e_inside, xmin, xmax, ymin, ymax) is True

    # Vertikal kant på vänstra kanten (x = xmin) → ska INTE räknas som inre snitt
    e_border = Edge(0, -5, 0, 15)
    assert edge_intersects_rect_interior(e_border, xmin, xmax, ymin, ymax) is False

    # Vertikal kant helt utanför
    e_outside = Edge(20, -5, 20, 15)
    assert edge_intersects_rect_interior(e_outside, xmin, xmax, ymin, ymax) is False


def test_edge_intersects_rect_interior_horizontal():
    # Rektangel: [0,10] x [0,10]
    xmin, xmax, ymin, ymax = 0, 10, 0, 10

    # Horisontell kant inne i rektangeln
    e_inside = Edge(-5, 5, 15, 5)
    assert edge_intersects_rect_interior(e_inside, xmin, xmax, ymin, ymax) is True

    # Horisontell kant på nederkant (y = ymin) → inte inre snitt
    e_border = Edge(-5, 0, 15, 0)
    assert edge_intersects_rect_interior(e_border, xmin, xmax, ymin, ymax) is False

    # Horisontell kant helt utanför
    e_outside = Edge(-5, 20, 15, 20)
    assert edge_intersects_rect_interior(e_outside, xmin, xmax, ymin, ymax) is False

def test_rectangle_inside_polygon_valid_and_invalid():
    coords = example_coords()
    edges = get_edges(coords)

    # Giltig rektangel för del 2-exemplet: (9,5) och (2,3) → area 24
    c_valid_1 = Coordinate(9,5)
    c_valid_2 = Coordinate(2,3)
    assert rectangle_inside_polygon(c_valid_1, c_valid_2, edges) is True

    # Den stora 50-rektangeln (11,1)-(2,5) som är OK i del 1 men INTE i del 2
    c_big_1 = Coordinate(11,1)
    c_big_2 = Coordinate(2,5)
    assert rectangle_inside_polygon(c_big_1, c_big_2, edges) is False

    

def test_get_pairs_with_area_basic_properties():
    coords = example_coords()
    pairs = get_pairs_with_area(coords)

    # Antal par = n * (n-1) / 2
    n = len(coords)
    assert len(pairs) == n * (n - 1) // 2

    # Första paret ska ha största area
    max_area, i, j = pairs[0]
    # kontrollera mot manuell max-beräkning
    manual_max = 0
    for a in range(n):
        for b in range(a+1, n):
            area = get_area(coords[a], coords[b])
            manual_max = max(manual_max, area)
    assert max_area == manual_max
