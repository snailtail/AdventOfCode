from pathlib import Path

from day04 import setup, adjacent_rolls, get_removable_rolls


def parse_input(file = "testinput_day04.dat"):
    base_path = Path(__file__).parent.parent
    data = setup(base_path / file)
    return data

def test_setup() -> None:
    base_path = Path(__file__).parent.parent
    data = setup(base_path / "testinput_day04.dat")
    assert data == [['.', '.', '@', '@', '.', '@', '@', '@', '@', '.'], ['@', '@', '@', '.', '@', '.', '@', '.', '@', '@'], ['@', '@', '@', '@', '@', '.', '@', '.', '@', '@'], ['@', '.', '@', '@', '@', '@', '.', '.', '@', '.'], ['@', '@', '.', '@', '@', '@', '@', '.', '@', '@'], ['.', '@', '@', '@', '@', '@', '@', '@', '.', '@'], ['.', '@', '.', '@', '.', '@', '.', '@', '@', '@'], ['@', '.', '@', '@', '@', '.', '@', '@', '@', '@'], ['.', '@', '@', '@', '@', '@', '@', '@', '@', '.'], ['@', '.', '@', '.', '@', '@', '@', '.', '@', '.']]

    
def test_solutions() -> None:
    base_path = Path(__file__).parent.parent
    data = setup(base_path / "testinput_day04.dat")
    assert adjacent_rolls(data,0,2) == 3
    
def test_get_removable_rolls() -> None:
    base_path = Path(__file__).parent.parent
    data = parse_input()
    removable_rolls = get_removable_rolls(data)
    assert len(removable_rolls) == 13