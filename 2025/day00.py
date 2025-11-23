"""Minimal Day 00 scaffold to show structure and test hooks."""
from pathlib import Path


def parse(input_path: Path) -> list[int]:
    """Read lines of integers from the provided file."""
    lines = input_path.read_text().splitlines()
    return [int(line) for line in lines if line.strip()]


def part1(values: list[int]) -> int:
    """Example solution: sum the numbers."""
    return sum(values)


def part2(values: list[int]) -> int:
    """Example solution: sum of squares."""
    return sum(v * v for v in values)


def main() -> None:
    base_path = Path(__file__).parent
    data = parse(base_path / "input_day00.dat")
    print(f"Del 1: {part1(data)}")
    print(f"Del 2: {part2(data)}")


if __name__ == "__main__":
    main()
