from pathlib import Path
from day12 import setup
from present_shape import PresentShape
from tree_region import TreeRegion
from treeregion_solver import TreeRegionSolver

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

def test_mask_rotation():
    shapes, _ = parse_testdata()
    for shape in shapes:
        coords = shape.coords_from_mask_3x3(shape.base_mask)
        for i in range(4):
            coords = [shape.rotate_coord_90deg_clockwise(coord) for coord in coords]
            new_mask = shape.mask_from_coords_3x3(coords)
        assert new_mask == shape.base_mask

def test_present_shape_variants_asymmetric():
    tile = """3:
.##
##.
###"""

    shape = PresentShape(tile)
    variants = shape.variants

    # 1) rimligt antal
    assert 1 <= len(variants) <= 8

    # 2) för denna shape: exakt 8
    assert len(variants) == 8

    # 3) basmasken finns med
    assert shape.base_mask in variants

    # 4) alla varianter har samma antal #
    base_count = shape.base_mask.bit_count()
    assert all(v.bit_count() == base_count for v in variants)

def test_rotate_4_times_returns_original():
    tile = """0:
###
##.
##."""

    shape = PresentShape(tile)
    m = shape.base_mask

    for _ in range(4):
        m = shape.rotate_mask_90deg(m)

    assert m == shape.base_mask

def test_tree_region_parsing():
    r = TreeRegion("12x5: 1 0 1 0 3 2")
    assert r.width == 12
    assert r.height == 5
    assert r.counts_tuple == (1,0,1,0,3,2)

def test_tree_region_derived_properties():
    r = TreeRegion("12x5: 1 0 1 0 3 2")
    assert r.total_presents == 7
    assert r.area == 60
    assert r.slots_3x3 == (12//3)*(5//3)

def test_quick_yes_by_slots():
    r = TreeRegion("9x6: 6 0 0 0 0 0")  # 9x6 → 6 slots
    assert r.quick_yes_by_slots() is True

def test_quick_yes_by_slots_false():
    r = TreeRegion("9x6: 7 0 0 0 0 0")
    assert r.quick_yes_by_slots() is False

def test_quick_no_by_area():
    shape_areas = (7,7,7,7,7,7)
    r = TreeRegion("4x4: 3 0 0 0 0 0")  # 3×7 = 21 > 16
    assert r.quick_no_by_area(shape_areas) is True

def test_quick_no_by_area_false():
    shape_areas = (7,7,7,7,7,7)
    r = TreeRegion("5x5: 3 0 0 0 0 0")  # 21 <= 25
    assert r.quick_no_by_area(shape_areas) is False

def test_full_input_all_regions_classified():
    shapes, regions = parse_testdata("input_day12.dat")
    solver = TreeRegionSolver(shapes)

    results = [solver.can_fit(r) for r in regions]

    assert all(r is True or r is False for r in results)
    assert sum(results) == 599
