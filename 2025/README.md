# Advent of Code 2025 (Python)

This folder contains a self-contained Python project for solving Advent of Code 2025.
The layout is intentionally lightweight and focuses on quick iteration for each day.

## Project layout

```
2025/
├── inputs/                 # Puzzle and sample inputs (e.g. day01_input.txt)
├── scripts/                # Helper utilities (e.g. create a new day scaffold)
├── src/aoc2025/            # Source code
│   ├── core.py             # Shared helpers such as input discovery
│   ├── loader.py           # Dynamic puzzle loader
│   ├── cli.py              # CLI entry point (python -m aoc2025 --help)
│   └── days/               # One module per day (day01.py, day02.py, ...)
└── tests/                  # Pytest-based test suite
```

Each puzzle lives in its own `dayXX.py` module inheriting from `aoc2025.core.Puzzle`.
The helper `default_input_path(day, suffix="input")` resolves input files like
`inputs/day01_input.txt` or `inputs/day01_sample.txt`.

## Running solutions

Install the project in editable mode (ideally inside a virtualenv):

```bash
cd 2025
python -m pip install -e .[dev]
```

Run a specific day via the CLI:

```bash
python -m aoc2025 1 --suffix sample  # Uses inputs/day01_sample.txt by default
python -m aoc2025 1 --part 2         # Only run part 2
```

## Creating a new day

Use the helper script to scaffold a new puzzle module, test, and input files:

```bash
python scripts/new_day.py 2
```

This will create:

- `src/aoc2025/days/day02.py` with a ready-to-edit class
- `tests/test_day02.py` with a placeholder test
- `inputs/day02_input.txt` and `inputs/day02_sample.txt`

Add your puzzle logic in `part1` and `part2`, drop example input into the sample file,
and expand the generated test with the expected answers.

## Testing

After installing the dev dependencies, run all tests from within the `2025` folder:

```bash
pytest
```
