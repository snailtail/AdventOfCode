from pathlib import Path
from day12 import setup
import pytest


def parse_testdata(path="testinput_day12.dat"):
    base_path = Path(__file__).parent.parent
    shapes,regions = setup(base_path / path)
    return shapes,regions

def test_setup_parsing():
    shapes,regions = parse_testdata()
    expected_shape_count = 6    #(0 through 5)
    expected_region_count = 3
    assert len(shapes) == expected_shape_count
    assert len(regions) == expected_region_count
