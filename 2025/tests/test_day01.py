from pathlib import Path

from day01 import part1, part2, move_part2, setup
dial = 50

def test_solutions() -> None:
    base_path = Path(__file__).parent.parent
    data = setup(base_path / "testinput_day00.dat")
    assert part1(data) == 3
    assert part2(data) == 6

def test_1000_spins() -> None:
    direction = 'R'
    distance = 1000
    assert move_part2(50, direction,distance) == (50, 10)
    