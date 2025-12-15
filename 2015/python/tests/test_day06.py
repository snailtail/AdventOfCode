# test_day06.py
import pytest

# Ändra importen så den matchar din fil, t.ex.:
# from day06 import Coordinate, Rectangle, LightGrid, Instruction
from day06 import Coordinate, Rectangle, LightGrid, Instruction


def test_instruction_parse_toggle():
    i = Instruction("toggle 0,0 through 999,999")
    assert i.action == "toggle"
    assert (i.coordinate1.x, i.coordinate1.y) == (0, 0)
    assert (i.coordinate2.x, i.coordinate2.y) == (999, 999)


def test_instruction_parse_turn_on():
    i = Instruction("turn on 12,34 through 56,78")
    assert i.action == "on"
    assert (i.coordinate1.x, i.coordinate1.y) == (12, 34)
    assert (i.coordinate2.x, i.coordinate2.y) == (56, 78)


def test_instruction_parse_turn_off():
    i = Instruction("turn off 1,2 through 3,4")
    assert i.action == "off"
    assert (i.coordinate1.x, i.coordinate1.y) == (1, 2)
    assert (i.coordinate2.x, i.coordinate2.y) == (3, 4)


def test_rectangle_inclusive_coordinates_count():
    r = Rectangle(Coordinate(0, 0), Coordinate(1, 1))
    coords = r.get_rectangle_coordinates()
    # 2x2 inkl hörn => 4 koordinater
    assert len(coords) == 4
    assert {(c.x, c.y) for c in coords} == {(0, 0), (0, 1), (1, 0), (1, 1)}


def test_rectangle_order_independent():
    r = Rectangle(Coordinate(3, 4), Coordinate(1, 2))
    coords = r.get_rectangle_coordinates()
    assert len(coords) == (3 - 1 + 1) * (4 - 2 + 1)  # 3x3 = 9
    assert (r.xmin, r.ymin, r.xmax, r.ymax) == (1, 2, 3, 4)


def test_lightgrid_part1_turn_on_single_cell():
    g = LightGrid()
    g.process_instruction("on", Coordinate(0, 0), Coordinate(0, 0), use_brightness=False)
    assert g.coordinates[0][0] == 1
    assert g.gridsum() == 1


def test_lightgrid_part1_toggle_single_cell_twice_returns_to_zero():
    g = LightGrid()
    g.process_instruction("toggle", Coordinate(10, 10), Coordinate(10, 10), use_brightness=False)
    assert g.coordinates[10][10] == 1
    g.process_instruction("toggle", Coordinate(10, 10), Coordinate(10, 10), use_brightness=False)
    assert g.coordinates[10][10] == 0
    assert g.gridsum() == 0


def test_lightgrid_part1_turn_on_then_off_rectangle():
    g = LightGrid()
    g.process_instruction("on", Coordinate(0, 0), Coordinate(1, 1), use_brightness=False)
    assert g.gridsum() == 4
    g.process_instruction("off", Coordinate(0, 0), Coordinate(1, 1), use_brightness=False)
    assert g.gridsum() == 0


def test_lightgrid_part1_aoc_examples():
    # Exempel från AoC 2015 Day 6 (Part 1)
    g = LightGrid()
    g.process_instruction("on", Coordinate(0, 0), Coordinate(999, 999), use_brightness=False)
    assert g.gridsum() == 1_000_000

    g = LightGrid()
    g.process_instruction("toggle", Coordinate(0, 0), Coordinate(999, 0), use_brightness=False)
    assert g.gridsum() == 1000

    g = LightGrid()
    g.process_instruction("on", Coordinate(0, 0), Coordinate(999, 999), use_brightness=False)
    g.process_instruction("off", Coordinate(499, 499), Coordinate(500, 500), use_brightness=False)
    assert g.gridsum() == 1_000_000 - 4


def test_lightgrid_part2_brightness_increase_decrease_floor_at_zero():
    g = LightGrid()
    # off på noll ska stanna på noll
    g.process_instruction("off", Coordinate(0, 0), Coordinate(0, 0), use_brightness=True)
    assert g.coordinates[0][0] == 0

    # on ökar +1
    g.process_instruction("on", Coordinate(0, 0), Coordinate(0, 0), use_brightness=True)
    assert g.coordinates[0][0] == 1

    # toggle ökar +2
    g.process_instruction("toggle", Coordinate(0, 0), Coordinate(0, 0), use_brightness=True)
    assert g.coordinates[0][0] == 3

    # off minskar -1
    g.process_instruction("off", Coordinate(0, 0), Coordinate(0, 0), use_brightness=True)
    assert g.coordinates[0][0] == 2


def test_lightgrid_part2_aoc_examples():
    # Exempel från AoC 2015 Day 6 (Part 2)
    g = LightGrid()
    g.process_instruction("on", Coordinate(0, 0), Coordinate(0, 0), use_brightness=True)
    assert g.gridsum() == 1

    g = LightGrid()
    g.process_instruction("toggle", Coordinate(0, 0), Coordinate(999, 999), use_brightness=True)
    assert g.gridsum() == 2_000_000

    g = LightGrid()
    g.process_instruction("on", Coordinate(0, 0), Coordinate(999, 999), use_brightness=True)
    g.process_instruction("toggle", Coordinate(0, 0), Coordinate(999, 999), use_brightness=True)
    assert g.gridsum() == 3_000_000


def test_lightgrid_invalid_action_raises():
    g = LightGrid()
    with pytest.raises(NotImplementedError):
        g.process_instruction("blink", Coordinate(0, 0), Coordinate(0, 0), use_brightness=False)
    with pytest.raises(NotImplementedError):
        g.process_instruction("blink", Coordinate(0, 0), Coordinate(0, 0), use_brightness=True)
