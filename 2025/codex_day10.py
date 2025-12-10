"""
Alternative Day 10 solution with a direct solver for part 2.

The joltage problem can be written as a linear system A x = b where
 - A[i][j] is 1 if button j increments counter i, else 0
 - b is the desired counter levels
 - x_j is how many times button j is pressed (x_j >= 0, integer)

Since there are at most a handful of buttons (<= 13) and the matrix is
very small, we:
 1) Reduce A to row‑reduced echelon form (exact Fractions).
 2) If the system has full column rank, the solution is unique; return it.
 3) Otherwise, enumerate the small nullspace (rank deficit <= 3 in input)
    over safe per‑button bounds to find the minimal total presses.
"""

from __future__ import annotations

import re
from dataclasses import dataclass
from fractions import Fraction
from itertools import product
from typing import Iterable, List


@dataclass
class Machine:
    buttons: List[List[int]]
    target_counters: List[int]


def parse_machine(line: str) -> Machine:
    """Parse one input line into buttons and target counters."""
    button_parts = re.findall(r"\(([^)]*)\)", line)
    buttons = []
    for part in button_parts:
        if part.strip():
            buttons.append([int(x) for x in part.split(",")])
        else:
            buttons.append([])

    target_match = re.search(r"\{([^}]*)\}", line)
    if not target_match:
        raise ValueError(f"No target counters found in line: {line!r}")
    target_counters = [int(x) for x in target_match.group(1).split(",")]

    return Machine(buttons=buttons, target_counters=target_counters)


def build_matrix(machine: Machine) -> list[list[int]]:
    """Construct the 0/1 incidence matrix A for counters x buttons."""
    rows = len(machine.target_counters)
    cols = len(machine.buttons)
    matrix = [[0] * cols for _ in range(rows)]
    for j, indices in enumerate(machine.buttons):
        for i in indices:
            matrix[i][j] = 1
    return matrix


def rref(matrix: list[list[int]], rhs: list[int]):
    """Row-reduced echelon form with exact Fractions."""
    A = [list(map(Fraction, row)) for row in matrix]
    b = list(map(Fraction, rhs))

    rows, cols = len(A), len(A[0])
    pivot_cols: list[int] = []
    r = 0
    for c in range(cols):
        pivot = None
        for i in range(r, rows):
            if A[i][c]:
                pivot = i
                break
        if pivot is None:
            continue

        A[r], A[pivot] = A[pivot], A[r]
        b[r], b[pivot] = b[pivot], b[r]

        pivot_val = A[r][c]
        if pivot_val != 1:
            for j in range(c, cols):
                A[r][j] /= pivot_val
            b[r] /= pivot_val

        for i in range(rows):
            if i == r:
                continue
            factor = A[i][c]
            if not factor:
                continue
            for j in range(c, cols):
                A[i][j] -= factor * A[r][j]
            b[i] -= factor * b[r]

        pivot_cols.append(c)
        r += 1
        if r == rows:
            break

    return A, b, pivot_cols


def _per_button_upper_bounds(machine: Machine) -> list[int]:
    """Upper bound for each button from the counters it touches."""
    bounds = []
    for indices in machine.buttons:
        if not indices:
            bounds.append(0)
            continue
        bounds.append(min(machine.target_counters[i] for i in indices))
    return bounds


def min_presses_joltage(machine: Machine) -> int:
    """
    Fewest button presses to reach target counters.
    Returns an integer; raises if no solution exists.
    """
    A = build_matrix(machine)
    target = machine.target_counters
    rows, cols = len(A), len(A[0])

    A_red, b_red, pivots = rref(A, target)
    rank = len(pivots)

    # Full column rank => unique solution.
    if rank == cols:
        solution = [0] * cols
        for row_idx, col_idx in enumerate(pivots):
            val = b_red[row_idx]
            if val < 0 or val.denominator != 1:
                raise ValueError("No non-negative integer solution found")
            solution[col_idx] = int(val)
        return sum(solution)

    free_cols = [c for c in range(cols) if c not in pivots]
    per_button_bounds = _per_button_upper_bounds(machine)
    search_ranges: list[Iterable[int]] = [
        range(per_button_bounds[c] + 1) for c in free_cols
    ]

    best: int | None = None
    for free_values in product(*search_ranges):
        assignment = {c: v for c, v in zip(free_cols, free_values)}

        total = 0
        for row_idx, pivot_col in enumerate(pivots):
            val = b_red[row_idx]
            for free_col in free_cols:
                coeff = A_red[row_idx][free_col]
                if coeff:
                    val -= coeff * assignment[free_col]
            if val < 0 or val.denominator != 1:
                break
            total += int(val)
        else:
            total += sum(free_values)
            if best is None or total < best:
                best = total

    if best is None:
        raise ValueError("No solution satisfies the constraints")
    return best


def solve_file(path: str) -> int:
    """Sum the minimal presses for every machine in the file."""
    total = 0
    with open(path, "r") as f:
        for line in f:
            line = line.strip()
            if not line:
                continue
            machine = parse_machine(line)
            total += min_presses_joltage(machine)
    return total


if __name__ == "__main__":
    import argparse

    parser = argparse.ArgumentParser(description="Day 10 joltage solver (fast).")
    parser.add_argument(
        "path",
        nargs="?",
        default="input_day10.dat",
        help="Input file to solve (default: input_day10.dat)",
    )
    args = parser.parse_args()

    total = solve_file(args.path)
    print(total)
