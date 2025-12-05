from ast import parse
from pathlib import Path

from day05 import setup, get_valid_ids, get_invalid_ids, merge_ranges, get_all_valid_id_count


def parse_testdata(path = "testinput_day05.dat"):
    base_path = Path(__file__).parent.parent
    (r, i) = setup(base_path / path)
    return (r,i)

def test_parse():
    (ranges,ids) = parse_testdata()
    assert 1 == 1
    assert ranges == [(3,5),(10,14),(16,20),(12,18)]
    assert ids == [1,5,8,11,17,32]

def test_valid_ids():
    ids = [1, 5, 7, 10, 12]
    ranges = [(5, 7), (10, 15)]

    assert get_valid_ids(ids, ranges) == {5, 7, 10, 12}

def test_invalid_ids():
    ids = [1, 5, 7, 10, 12, 16]
    ranges = [(5, 7), (10, 15)]

    assert get_invalid_ids(ids, ranges) == {1, 16}

def test_merge_ranges():
    ranges,ids = parse_testdata()
    merged_ranges = merge_ranges(ranges)
    assert merged_ranges == [(3,5),(10,20)]

def test_solutions():
    ranges,ids = parse_testdata()
    valid = get_valid_ids(ids,ranges)
    assert len(valid) == 3
    total_valid_count = get_all_valid_id_count(ranges)
    assert total_valid_count == 14