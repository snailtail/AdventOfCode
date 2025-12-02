from pathlib import Path

from day02 import part1, part2, setup
dial = 50

def test_setup() -> None:
    base_path = Path(__file__).parent.parent
    data = setup(base_path / "testinput_day02.dat")
    assert data == [(11, 22), (95, 115), (998, 1012), (1188511880, 1188511890), (222220, 222224), (1698522, 1698528), (446443, 446449), (38593856, 38593862), (565653, 565659), (824824821, 824824827), (2121212118, 2121212124)]

def test_part1_logic() -> None:
    base_path = Path(__file__).parent.parent
    data = setup(base_path / "testinput_day02.dat")
    invalid_ids = part1(data)
    assert invalid_ids == [11, 22, 99, 1010, 1188511885, 222222, 446446, 38593859]

def test_part2_logic() -> None:
    base_path = Path(__file__).parent.parent
    data = setup(base_path / "testinput_day02.dat")
    invalid_ids = part2(data)
    assert invalid_ids == [11, 22, 99, 111, 999, 1010, 1188511885, 222222, 446446, 38593859, 565656, 824824824, 2121212121]
    
def test_solutions() -> None:
    base_path = Path(__file__).parent.parent
    data = setup(base_path / "testinput_day02.dat")
    assert sum(part1(data)) == 1227775554
    assert sum(part2(data)) == 4174379265