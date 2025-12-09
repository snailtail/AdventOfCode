from pathlib import Path
import pytest

from day09 import setup


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
    (x,y) = coords[index]
    assert x == expected_x
    assert y == expected_y
    
