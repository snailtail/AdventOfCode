from pathlib import Path
from day01 import setup, parse_parenthesis
import pytest

def parse_testdata(path="testinput_day01.dat"):
    base_path = Path(__file__).parent.parent
    input = setup(base_path / path)
    return input

@pytest.mark.parametrize("parens, expected_result,expected_p2_index",[
    ('(())',0,0),
    ('()()',0,0),
    ('(((',3,0),
    ('(()(()(',3,0),
    ('))(((((',3,1),
    ('())',-1,3),
    ('))(',-1,1),
    (')))',-3,1),
    (')())())',-3,1),
])
def test_parenthesis(parens: str, expected_result: int, expected_p2_index):
    result,p2index = parse_parenthesis(parens)
    assert result == expected_result
    assert p2index == expected_p2_index

