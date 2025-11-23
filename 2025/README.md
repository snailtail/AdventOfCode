# Advent of Code 2025

Detta är min mapp för Advent of Code 2025. Tanken är att jag ska försöka lösa årets pussel med Python.

Planen är enkel:
- Ladda ner dagens pussel från https://adventofcode.com/2025.
- Spara eventuella anteckningar eller lösningar här allt eftersom jag kommer igång.

Lycka till och god puzzling!

## Exempel (Day 00)

Ett minimalt exempel för struktur och tester:
- `day00.py` innehåller parser samt `part1`/`part2`.
- `input_day00.dat` är “riktig” input, `testinput_day00.dat` är testdata.
- `tests/test_day00.py` visar hur pytest kan användas mot delarna.

Kör exempel:
- `python3 day00.py` för att skriva ut lösning på inputfilen.
- `python3 -m pytest` för att köra testerna (kräver att `pytest` är installerat).
- GitHub Actions workflow `.github/workflows/2025-python.yml` kör pytest automatiskt för filer under `2025/` på push/PR.

Inputfiler:
- `input_dayXX.dat` ignoreras i git (se `.gitignore`), så lägg dina riktiga Advent of Code-inputs lokalt.
- `testinput_dayXX.dat` är whitelistan och kan checkas in som fixtures för pytest.
