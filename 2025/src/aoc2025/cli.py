from __future__ import annotations

import argparse
from pathlib import Path
from typing import Iterable

from aoc2025.core import Puzzle, default_input_path, read_text
from aoc2025.loader import PuzzleNotFound, load_puzzle


def run_puzzle(puzzle: Puzzle, input_path: Path, parts: Iterable[int]) -> list[tuple[int, object]]:
    data = read_text(input_path)

    results: list[tuple[int, object]] = []
    for part in parts:
        if part == 1:
            results.append((1, puzzle.part1(data)))
        elif part == 2:
            results.append((2, puzzle.part2(data)))
        else:  # pragma: no cover - guarded by argparse choices
            raise ValueError(f"Unsupported part: {part}")

    return results


def parse_args(argv: list[str] | None = None) -> argparse.Namespace:
    parser = argparse.ArgumentParser(description="Run an Advent of Code 2025 puzzle")
    parser.add_argument("day", type=int, help="Day to run (1-25)")
    parser.add_argument(
        "--part",
        choices=["1", "2", "both"],
        default="both",
        help="Select which part to run. Defaults to both.",
    )
    parser.add_argument(
        "--input",
        type=Path,
        help="Path to input file. Defaults to inputs/dayXX_input.txt",
    )
    parser.add_argument(
        "--suffix",
        default="input",
        help="Suffix for the default input file (e.g. 'sample').",
    )
    return parser.parse_args(argv)


def main(argv: list[str] | None = None) -> int:
    args = parse_args(argv)
    try:
        puzzle = load_puzzle(args.day)
    except PuzzleNotFound as exc:
        raise SystemExit(str(exc))

    input_path = args.input or default_input_path(args.day, suffix=args.suffix)
    if not input_path.exists():
        raise SystemExit(f"Input file not found: {input_path}")

    parts = [1, 2] if args.part == "both" else [int(args.part)]
    results = run_puzzle(puzzle, input_path, parts)
    for part, value in results:
        print(f"Day {args.day:02d} - Part {part}: {value}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
