# Day 10 (Joltage) – Explained Simply

This document explains the Part 2 solver in `codex_day10.py` without assuming much background in Python or higher math. The goal is to show what the problem is, how it turns into a small system of equations, and how the code finds the fewest button presses.

## High-Level Idea

- Each machine has some counters, all start at 0.
- Each button adds +1 to a specific set of counters.
- We need each counter to land on a given target number using the fewest total button presses.
- Pressing a button any number of times is allowed, but counts must end exactly on their targets (no overshoot).

Think of it like filling several buckets to exact heights:

- Buckets = counters.
- Cups = buttons. Pouring with cup A adds 1 unit to some buckets at once.
- We want the least total cup pours to get every bucket to its exact height.

## Turning the Problem Into a Table

We can describe everything with a simple 0/1 table (a matrix):

- Rows = counters (buckets).
- Columns = buttons (cups).
- A cell is 1 if that button affects that counter, else 0.

Example with 3 counters and 2 buttons:

```
Button list:
  B0 touches counters 0 and 2
  B1 touches counter 1

Targets: counter0=2, counter1=1, counter2=3

Matrix A (rows=counters, cols=buttons):
  counter0: [1, 0]   # B0 affects counter0, B1 does not
  counter1: [0, 1]   # B1 affects counter1
  counter2: [1, 0]   # B0 affects counter2

Unknowns (how many times to press each button):
  x0 = times we press B0
  x1 = times we press B1

Equations:
  1*x0 + 0*x1 = 2   (reach counter0=2)
  0*x0 + 1*x1 = 1   (reach counter1=1)
  1*x0 + 0*x1 = 3   (reach counter2=3)
```

This is written as `A * x = b`:

- `A` = the 0/1 table above.
- `x` = button press counts (must be non-negative integers).
- `b` = target counters.

## Why Not BFS?

Brute-force/BFS over counter states grows explosively because counters can be large (hundreds). Instead, solving the equations directly is tiny and fast because there are few buttons (≤ ~13).

## Core Steps in `codex_day10.py`

### 1) Parse the Line

- Extract button definitions `( … )` → turn into a list of indices per button.
- Extract targets `{…}` → list of integers.
- Build `A` (matrix) where `A[i][j]` is 1 if button `j` touches counter `i`.

### 2) Reduce the Matrix (RREF)

RREF (Row-Reduced Echelon Form) is a standardized way to simplify the table so solutions pop out clearly. The code:

- Uses exact fractions (`fractions.Fraction`) so there is no rounding.
- Swaps/normalizes rows to put a 1 “pivot” in each leading position.
- Clears above/below pivots so each pivot column has a single 1.

After RREF:

- If every column got a pivot, the solution is unique.
- If some columns lack pivots, there are “free variables” (multiple solutions).

### 3) Unique-Solution Case

If every button column is a pivot:

- Read off the single solution from the reduced matrix.
- Check all values are non-negative integers.
- Sum them to get the minimal presses (because there is only one solution).

### 4) Multiple-Solution Case (Free Variables)

Sometimes there are more buttons than independent constraints, so several press-combinations work. We must pick the one with the smallest total presses.

Approach:

- Identify free columns (no pivot).
- For each free column, set a small upper bound: it cannot exceed the smallest target among counters it affects (pressing more would overshoot that counter).
- Enumerate all combinations within these tiny ranges (rank deficit in the real input is at most 3, so this stays very small).
- For each combination:
  - Compute the required pivot-column presses to satisfy the equations.
  - Discard if any value is negative or non-integer.
  - Track the smallest total presses found.

Because the rank deficit is tiny, this exhaustive check is instant.

### 5) Sum Per-Machine Results

- For each input line (machine), compute its minimal presses.
- Sum them for the final answer.

## Walking Through a Small Example

Using the earlier 3-counter, 2-button setup:

```python
A = [[1,0],
     [0,1],
     [1,0]]
b = [2,1,3]
```

RREF gives pivots in both columns (unique solution):

- From rows 1 and 3, we learn `x0` must satisfy both 2 and 3 → this system is inconsistent as stated, so no solution. If the targets were `[2,1,2]`, we’d get `x0=2`, `x1=1` and total presses = 3.

In real puzzle lines, the input is crafted so a valid solution exists.

## Reading the Code (Key Functions)

- `parse_machine`: turns a text line into buttons and targets.
- `build_matrix`: builds the 0/1 incidence matrix.
- `rref`: converts `(A, b)` into reduced form, recording pivot columns.
- `_per_button_upper_bounds`: safe bounds for free-variable search.
- `min_presses_joltage`: main solver per machine (unique vs. search).
- `solve_file`: sums answers for all machines in a file.

## How to Run

```shell
python3 codex_day10.py            # solves input_day10.dat
python3 codex_day10.py myfile.txt # solves a custom file
```

## Why This Is Fast

- Button count is tiny, so RREF is trivial.
- Rank deficit ≤ 3, so free-variable search is tiny.
- No floating-point errors: exact Fractions.
- No giant state spaces: avoids BFS entirely.

## Mental Model Recap

- Picture counters as buckets and buttons as multi-spout cups.
- Build a yes/no table of which cup pours into which bucket.
- Solve the small set of equations; if there’s flexibility, try small non-negative choices and pick the cheapest.

That’s all `codex_day10.py` does—just written down in code. :)
