from pathlib import Path

from day02 import part1, part2, setup
dial = 50

def test_solutions() -> None:
    base_path = Path(__file__).parent.parent
    data = setup(base_path / "testinput_day02.dat")
    assert sum(part1(data)) == 1227775554
    assert sum(part2(data)) == 4174379265