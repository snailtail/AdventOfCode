from __future__ import annotations

from dataclasses import dataclass
from pathlib import Path
from typing import Final

PROJECT_ROOT: Final[Path] = Path(__file__).resolve().parents[2]
INPUT_DIR: Final[Path] = PROJECT_ROOT / "inputs"


def default_input_path(day: int, *, suffix: str = "input") -> Path:
    """Return the default input path for the given day.

    The default layout stores files as ``inputs/dayXX_<suffix>.txt`` where
    ``suffix`` defaults to ``"input"`` for the real puzzle input. A common
    alternative is ``suffix="sample"`` for example input from the puzzle
    description.
    """

    return INPUT_DIR / f"day{day:02d}_{suffix}.txt"


@dataclass
class Puzzle:
    """Base class for Advent of Code puzzles."""

    day: int

    def part1(self, data: str):  # pragma: no cover - interface
        raise NotImplementedError

    def part2(self, data: str):  # pragma: no cover - interface
        raise NotImplementedError


def read_text(path: Path) -> str:
    """Read an input file and normalize trailing newlines."""

    content = path.read_text(encoding="utf-8")
    return content.rstrip("\n")
