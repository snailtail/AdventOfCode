from pathlib import Path

from day00 import parse, part1, part2


def test_parse_and_solutions() -> None:
    base_path = Path(__file__).parent.parent
    data = parse(base_path / "testinput_day00.dat")

    assert data == [1, 2, 3, 4, 5]
    assert part1(data) == 15
    assert part2(data) == 55
