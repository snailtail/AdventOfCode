from ast import parse
from pathlib import Path

from day07 import setup, get_start_position, get_splitter_indexes, part1


def parse_testdata(path="testinput_day07.dat"):
    base_path = Path(__file__).parent.parent
    input = setup(base_path / path)
    return input


def test_parse():
    data = parse_testdata()
    expected = [
        [".", ".", ".", ".", ".", ".", ".", "S", ".", ".", ".", ".", ".", ".", "."],
        [".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."],
        [".", ".", ".", ".", ".", ".", ".", "^", ".", ".", ".", ".", ".", ".", "."],
        [".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."],
        [".", ".", ".", ".", ".", ".", "^", ".", "^", ".", ".", ".", ".", ".", "."],
        [".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."],
        [".", ".", ".", ".", ".", "^", ".", "^", ".", "^", ".", ".", ".", ".", "."],
        [".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."],
        [".", ".", ".", ".", "^", ".", "^", ".", ".", ".", "^", ".", ".", ".", "."],
        [".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."],
        [".", ".", ".", "^", ".", "^", ".", ".", ".", "^", ".", "^", ".", ".", "."],
        [".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."],
        [".", ".", "^", ".", ".", ".", "^", ".", ".", ".", ".", ".", "^", ".", "."],
        [".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."],
        [".", "^", ".", "^", ".", "^", ".", "^", ".", "^", ".", ".", ".", "^", "."],
        [".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "."],
    ]
    assert data == expected


def test_get_startposition():
    data = parse_testdata()
    expected = (0, 7)
    start = get_start_position(data)
    assert start == expected

def test_get_splitter_indexes():
    data = parse_testdata()
    r1_expected = set()
    r1_result = get_splitter_indexes(data,1)
    assert r1_result == r1_expected

    r2_expected = {7}
    r2_result = get_splitter_indexes(data,2)
    assert r2_result == r2_expected

    r3_expected = set()
    r3_result = get_splitter_indexes(data,3)
    assert r3_result == r3_expected

    r14_expected = {1,3,5,7,9,13}
    r14_result = get_splitter_indexes(data,14)
    assert r14_result == r14_expected

def test_solution_p1():
    data = parse_testdata()
    p1_expected = 21
    p1_result = part1(data)
    assert p1_result == p1_expected