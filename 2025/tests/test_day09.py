from pathlib import Path
import pytest

from day09 import setup, Coordinate, get_pairs_with_distances, get_area


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
