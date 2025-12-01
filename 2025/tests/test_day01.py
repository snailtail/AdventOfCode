from pathlib import Path

from day01 import part1, part2, move_part2
dial = 50

def test_solutions() -> None:
    data = [('L', 68), ('L', 30), ('R', 48), ('L', 5), ('R', 60), ('L', 55), ('L', 1), ('L', 99), ('R', 14), ('L', 82)]
    assert part1(data) == 3
    assert part2(data) == 6

def test_1000_spins() -> None:
    direction = 'R'
    distance = 1000
    assert move_part2(50, direction,distance) == (50, 10)
    