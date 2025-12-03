from pathlib import Path

from day03 import solve, setup


def test_setup() -> None:
    base_path = Path(__file__).parent.parent
    data = setup(base_path / "testinput_day03.dat")
    assert data == [[9, 8, 7, 6, 5, 4, 3, 2, 1, 1, 1, 1, 1, 1, 1], [8, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9], [2, 3, 4, 2, 3, 4, 2, 3, 4, 2, 3, 4, 2, 7, 8], [8, 1, 8, 1, 8, 1, 9, 1, 1, 1, 1, 2, 1, 1, 1]]

    
def test_solutions() -> None:
    base_path = Path(__file__).parent.parent
    data = setup(base_path / "testinput_day03.dat")
    assert solve(data,2) == 357
    assert solve(data,12) == 3121910778619