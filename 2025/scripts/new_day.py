from __future__ import annotations

import argparse
from pathlib import Path
from textwrap import dedent

ROOT = Path(__file__).resolve().parents[1]
SRC_DIR = ROOT / "src" / "aoc2025" / "days"
TEST_DIR = ROOT / "tests"
INPUT_DIR = ROOT / "inputs"


def day_file(day: int) -> Path:
    return SRC_DIR / f"day{day:02d}.py"


def test_file(day: int) -> Path:
    return TEST_DIR / f"test_day{day:02d}.py"


def create_file(path: Path, content: str, overwrite: bool) -> None:
    if path.exists() and not overwrite:
        print(f"Skipping existing file: {path}")
        return

    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(content, encoding="utf-8")
    print(f"Created {path.relative_to(ROOT)}")


def puzzle_template(day: int) -> str:
    return dedent(
        f'''
        from __future__ import annotations

        from aoc2025.core import Puzzle


        class Day{day:02d}(Puzzle):
            """Solution for Advent of Code 2025 - Day {day:02d}."""

            day = {day}

            def __init__(self) -> None:
                super().__init__(day=self.day)

            def part1(self, data: str):
                """Solve part 1."""

                raise NotImplementedError

            def part2(self, data: str):
                """Solve part 2."""

                raise NotImplementedError


        def get_puzzle() -> Day{day:02d}:
            return Day{day:02d}()
        '''
    ).strip() + "\n"


def test_template(day: int) -> str:
    return dedent(
        f'''
        from pathlib import Path

        from aoc2025.loader import load_puzzle
        from aoc2025.core import default_input_path


        def test_day{day:02d}_example():
            puzzle = load_puzzle({day})
            sample_path = default_input_path({day}, suffix="sample")
            if not sample_path.exists():
                # Allows running the test suite even before the puzzle is solved.
                return
            data = sample_path.read_text(encoding="utf-8").rstrip("\n")
            # Replace these assertions with the real expected values.
            assert puzzle.part1(data) is not None
            assert puzzle.part2(data) is not None
        '''
    ).strip() + "\n"


def input_paths(day: int) -> list[Path]:
    return [
        INPUT_DIR / f"day{day:02d}_input.txt",
        INPUT_DIR / f"day{day:02d}_sample.txt",
    ]


def parse_args() -> argparse.Namespace:
    parser = argparse.ArgumentParser(description="Create scaffolding for a new Advent of Code day")
    parser.add_argument("day", type=int, help="Day number (1-25)")
    parser.add_argument(
        "--overwrite", action="store_true", help="Overwrite existing files instead of skipping"
    )
    return parser.parse_args()


def main() -> int:
    args = parse_args()
    day = args.day

    create_file(day_file(day), puzzle_template(day), overwrite=args.overwrite)
    create_file(test_file(day), test_template(day), overwrite=args.overwrite)
    for path in input_paths(day):
        if path.exists() and not args.overwrite:
            print(f"Skipping existing file: {path.relative_to(ROOT)}")
            continue
        path.parent.mkdir(parents=True, exist_ok=True)
        path.touch()
        print(f"Ensured {path.relative_to(ROOT)}")

    return 0


if __name__ == "__main__":
    raise SystemExit(main())
