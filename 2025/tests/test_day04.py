from pathlib import Path

from day04 import setup, get_adjacent_rolls, get_removable_rolls, part1, part2


def parse_testdata(path = "testinput_day04.dat"):
    base_path = Path(__file__).parent.parent
    data = setup(base_path / "testinput_day04.dat")
    return data

def test_setup() -> None:
    base_path = Path(__file__).parent.parent
    data = setup(base_path / "testinput_day04.dat")
    assert data == [['.', '.', '@', '@', '.', '@', '@', '@', '@', '.'], ['@', '@', '@', '.', '@', '.', '@', '.', '@', '@'], ['@', '@', '@', '@', '@', '.', '@', '.', '@', '@'], ['@', '.', '@', '@', '@', '@', '.', '.', '@', '.'], ['@', '@', '.', '@', '@', '@', '@', '.', '@', '@'], ['.', '@', '@', '@', '@', '@', '@', '@', '.', '@'], ['.', '@', '.', '@', '.', '@', '.', '@', '@', '@'], ['@', '.', '@', '@', '@', '.', '@', '@', '@', '@'], ['.', '@', '@', '@', '@', '@', '@', '@', '@', '.'], ['@', '.', '@', '.', '@', '@', '@', '.', '@', '.']]

    
def test_adjacent_rolls() -> None:
    base_path = Path(__file__).parent.parent
    data = setup(base_path / "testinput_day04.dat")
    assert get_adjacent_rolls(data,0,2) == 3
    assert get_adjacent_rolls(data,4,4) == 8
    assert get_adjacent_rolls(data,2,3) == 7
    assert get_adjacent_rolls(data,9,0) == 1
    assert get_adjacent_rolls(data,7,3) == 6

    
def test_solution_part1() -> None:
    base_path = Path(__file__).parent.parent
    data = setup(base_path / "testinput_day04.dat")
    assert part1(data) == 13
    
def test_solution_part2() -> None:
    base_path = Path(__file__).parent.parent
    data = setup(base_path / "testinput_day04.dat")
    assert part2(data) == 43


def test_get_removable_rolls() -> None:
    # base_path = Path(__file__).parent.parent
    # data = setup(base_path / "testinput_day04.dat")
    data = parse_testdata()
    removable_rolls = get_removable_rolls(data)
    assert len(removable_rolls) == 13