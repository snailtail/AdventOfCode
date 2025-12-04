from pathlib import Path

from day04 import setup, adjacent_rolls


def test_setup() -> None:
    base_path = Path(__file__).parent.parent
    data = setup(base_path / "testinput_day04.dat")
    assert data == [['.', '.', '@', '@', '.', '@', '@', '@', '@', '.'], ['@', '@', '@', '.', '@', '.', '@', '.', '@', '@'], ['@', '@', '@', '@', '@', '.', '@', '.', '@', '@'], ['@', '.', '@', '@', '@', '@', '.', '.', '@', '.'], ['@', '@', '.', '@', '@', '@', '@', '.', '@', '@'], ['.', '@', '@', '@', '@', '@', '@', '@', '.', '@'], ['.', '@', '.', '@', '.', '@', '.', '@', '@', '@'], ['@', '.', '@', '@', '@', '.', '@', '@', '@', '@'], ['.', '@', '@', '@', '@', '@', '@', '@', '@', '.'], ['@', '.', '@', '.', '@', '@', '@', '.', '@', '.']]

    
def test_solutions() -> None:
    base_path = Path(__file__).parent.parent
    data = setup(base_path / "testinput_day04.dat")
    assert adjacent_rolls(data,0,2) == 3
    