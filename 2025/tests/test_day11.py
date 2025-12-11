from pathlib import Path
from day11 import setup
import pytest



def parse_testdata(path="testinput_day11.dat"):
    base_path = Path(__file__).parent.parent
    rack = setup(base_path / path)
    return rack

@pytest.mark.parametrize(
        "index,expected_id",
        [
            (0, "aaa"),
            (1, "you"),
            (2, "hhh"),
            (3, "bbb"),
            (4, "ccc"),
            (5, "ddd"),
            (6, "eee"),
            (7, "fff"),
            (8, "ggg"),
            (9, "out"),
            (10, "iii"),
        ],
)
def test_setup_and_parse_vertices(index,expected_id):
    rack = parse_testdata()
    assert rack.servers[index] == expected_id


@pytest.mark.parametrize(
        "index, expected_values",
        [
            (0,[0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0]),
            (1,[0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0]), 
            (2,[0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1]), 
            (3,[0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0]), 
            (4,[0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0]), 
            (5,[0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0]), 
            (6,[0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0]), 
            (7,[0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0]), 
            (8,[0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0]), 
            (9,[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]), 
            (10,[0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0]),
        ],
)
def test_setup_and_parse_adjacency_matrix(index, expected_values):
    rack = parse_testdata()
    assert rack.cable_matrix[index] == expected_values