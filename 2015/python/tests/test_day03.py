from pathlib import Path
from day03 import setup, Santa
import pytest

def parse_testdata(path="testinput_day03.dat"):
    base_path = Path(__file__).parent.parent
    input = setup(base_path / path)
    return input

def test_parse():
    instructions = parse_testdata()
    assert instructions[0]=='^'
    assert len(instructions)==4


@pytest.mark.parametrize(
        "instruction,expected_y,expected_x",
        [
            ('^',-1,0),
            ('v',1,0),
            ('<',0,-1),
            ('>',0,1),
        ]
        )
def test_santa_move_one_step(instruction: str, expected_y: int,expected_x: int):
    santa = Santa()
    santa.move_one_step(instruction)
    assert santa.y == expected_y
    assert santa.x == expected_x

@pytest.mark.parametrize(
        "instructions,expected_y,expected_x",
        [
            ('^>>',-1,2),
            ('v><<<',1,-2),
            ('^>v<',0,0),
            ('>>>vvv',3,3),
        ]
        )
def test_santa_move_multiple_steps(instructions: str, expected_y: int,expected_x: int):
    santa = Santa()
    santa.move_multiple_steps(instructions)
    assert santa.y == expected_y
    assert santa.x == expected_x