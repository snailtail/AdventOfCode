from pathlib import Path
import pytest
from day08 import Coordinate, setup, get_pairs_with_distances


def parse_testdata(path="testinput_day08.dat"):
    base_path = Path(__file__).parent.parent
    input = setup(base_path / path)
    return input



@pytest.mark.parametrize("index, expected_x, expected_y, expected_z", [
    (0,162,817,812),
    (1,57,618,57),
    (2,906,360,560),
    (3,592,479,940),
    (4,352,342,300),
    (5,466,668,158),
    (6,542,29,236),
    (7,431,825,988),
    (8,739,650,466),
    (9,52,470,668),
    (10,216,146,977),
    (11,819,987,18),
    (12,117,168,530),
    (13,805,96,715),
    (14,346,949,466),
    (15,970,615,88),
    (16,941,993,340),
    (17,862,61,35),
    (18,984,92,344),
    (19,425,690,689)
    ])
def test_parse(index,expected_x, expected_y, expected_z):
    coords = parse_testdata()
    assert coords[index].x == expected_x
    assert coords[index].y == expected_y
    assert coords[index].z == expected_z


def test_distance():
    a = Coordinate(0, 0, 0)
    b = Coordinate(3, 4, 12)
    assert b.distance_to(a) == 13