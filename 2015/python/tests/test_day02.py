from pathlib import Path
from day02 import setup, Present
import pytest

def parse_testdata(path="testinput_day02.dat"):
    base_path = Path(__file__).parent.parent
    input = setup(base_path / path)
    return input

@pytest.mark.parametrize("index, expected_paper_requirement, expected_ribbon_requirement",[
    (0,58, 34),
    (1,43, 14),
])
def test_part1(index: int, expected_paper_requirement: int, expected_ribbon_requirement: int):
    data = parse_testdata()
    assert data[index].paper_requirements() == expected_paper_requirement

