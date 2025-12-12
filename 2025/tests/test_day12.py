from pathlib import Path
from day12 import setup
import pytest


def parse_testdata(path="testinput_day12.dat"):
    base_path = Path(__file__).parent.parent
    shapes,regions = setup(base_path / path)
    return shapes,regions

def test_setup_basic_parsing():
    shapes,regions = parse_testdata()
    expected_shape_count = 6    #(0 through 5)
    expected_region_count = 3
    assert len(shapes) == expected_shape_count
    assert len(regions) == expected_region_count

@pytest.mark.parametrize(
        "index,expected_shape_data, expected_base_mask",
        [
            (0,'#####.##.',223),
            (1,'#####..##',415),
            (2,'.#######.',254),
            (3,'##.#####.',251),
            (4,'####..###',463),
            (5,'###.#.###',471),
        ])
def test_parsing_present_shapes(index: int, expected_shape_data, expected_base_mask):
    shapes, _ = parse_testdata()
    assert shapes[index].shape_data == expected_shape_data
    assert shapes[index].base_mask == expected_base_mask

@pytest.mark.parametrize(
        "index, expected_coords",
        [
            (0,((0, 0), (1, 0), (2, 0), (0, 1), (1, 1), (0, 2), (1, 2))),
            (1,((0, 0), (1, 0), (2, 0), (0, 1), (1, 1), (1, 2), (2, 2))),
            (2,((1, 0), (2, 0), (0, 1), (1, 1), (2, 1), (0, 2), (1, 2))),
            (3,((0, 0), (1, 0), (0, 1), (1, 1), (2, 1), (0, 2), (1, 2))),
            (4,((0, 0), (1, 0), (2, 0), (0, 1), (0, 2), (1, 2), (2, 2))),
            (5,((0, 0), (1, 0), (2, 0), (1, 1), (0, 2), (1, 2), (2, 2))),
        ]
)    
def test_parsing_present_coords_from_mask(index: int, expected_coords: tuple[tuple[int, int], ...]):
    shapes,_ = parse_testdata()
    assert shapes[index].coords_from_mask_3x3(shapes[index].base_mask) == expected_coords