from pathlib import Path

from day06 import setup


def parse_testdata(path = "testinput_day06.dat"):
    base_path = Path(__file__).parent.parent
    (r, i) = setup(base_path / path)
    return (r,i)
