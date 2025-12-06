from pathlib import Path

from day06 import setup, part1, part2


def parse_testdata(path = "testinput_day06.dat", part2=False):
    base_path = Path(__file__).parent.parent
    input = setup(base_path / path,part2)
    return input

def test_parse_p1():
    expected = [['123', '328', '51', '64'],
                ['45', '64', '387', '23'],
                ['6', '98', '215', '314'],
                ['*', '+', '*', '+']]
    data = parse_testdata(part2=False)
    assert data == expected

def test_parse_p2():
    expected = [['1', '2', '3', ' ', '3', '2', '8', ' ', ' ', '5', '1', ' ', '6', '4', ' '],
                [' ', '4', '5', ' ', '6', '4', ' ', ' ', '3', '8', '7', ' ', '2', '3', ' '],
                [' ', ' ', '6', ' ', '9', '8', ' ', ' ', '2', '1', '5', ' ', '3', '1', '4'],
                ['*', ' ', ' ', ' ', '+', ' ', ' ', ' ', '*', ' ', ' ', ' ', '+', ' ', ' ']]
    data = parse_testdata(part2=True)
    assert data == expected
    
def test_solution_p1():
    data = parse_testdata(part2=False)
    result = part1(data)
    expected = 4277556
    assert result == expected

def test_solution_p2():
    data = parse_testdata(part2=True)
    result = part2(data)
    expected = 3263827
    assert result == expected