from __future__ import annotations

from aoc2025.core import Puzzle


class Day01(Puzzle):
    """Example puzzle implementation used to validate the project scaffold."""

    day = 1

    def __init__(self) -> None:
        super().__init__(day=self.day)

    def part1(self, data: str) -> int:
        numbers = [int(value) for value in data.split() if value.strip()]
        return sum(numbers)

    def part2(self, data: str) -> int:
        numbers = [int(value) for value in data.split() if value.strip()]
        return sum(value * value for value in numbers)


def get_puzzle() -> Day01:
    return Day01()
