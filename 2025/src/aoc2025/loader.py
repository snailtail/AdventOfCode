from __future__ import annotations

from importlib import import_module

from aoc2025.core import Puzzle


class PuzzleNotFound(Exception):
    """Raised when a puzzle module cannot be loaded."""


def load_puzzle(day: int) -> Puzzle:
    """Dynamically import and instantiate a puzzle for the given day."""

    module_name = f"aoc2025.days.day{day:02d}"
    try:
        module = import_module(module_name)
    except ModuleNotFoundError as exc:  # pragma: no cover - direct import feedback
        raise PuzzleNotFound(f"Puzzle module '{module_name}' not found") from exc

    if not hasattr(module, "get_puzzle"):
        raise PuzzleNotFound(
            f"Puzzle module '{module_name}' does not expose a 'get_puzzle' factory"
        )

    puzzle = module.get_puzzle()
    if not isinstance(puzzle, Puzzle):
        raise PuzzleNotFound(
            f"Puzzle module '{module_name}' returned unexpected type {type(puzzle)!r}"
        )

    if puzzle.day != day:
        raise PuzzleNotFound(
            f"Puzzle module '{module_name}' reports day {puzzle.day} instead of {day}"
        )

    return puzzle
