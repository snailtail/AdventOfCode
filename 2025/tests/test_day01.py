from pathlib import Path

from aoc2025.core import default_input_path
from aoc2025.loader import load_puzzle


def test_day01_sample():
    puzzle = load_puzzle(1)
    sample_path = default_input_path(1, suffix="sample")
    data = sample_path.read_text(encoding="utf-8").rstrip("\n")
    assert puzzle.part1(data) == 15
    assert puzzle.part2(data) == 55


def test_day01_real_input():
    puzzle = load_puzzle(1)
    input_path = default_input_path(1)
    data = input_path.read_text(encoding="utf-8").rstrip("\n")
    assert puzzle.part1(data) == 150
    assert puzzle.part2(data) == 5500
