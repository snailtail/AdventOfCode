from day10 import Machine
import pytest

def test_machine_parse_example1():
    line = "[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}"
    m = Machine(line)

    assert m.num_lights == 4
    # .##. -> 0 1 1 0  → bit 1 och 2 = 1
    assert m.target_mask == (1 << 1) | (1 << 2)

    # kolla första knappen (3)
    assert m.button_masks[0] == (1 << 3)
    # kolla andra knappen (1,3)
    assert m.button_masks[1] == (1 << 1) | (1 << 3)

    assert m.target_counters == (3, 5, 4, 7)



@pytest.mark.parametrize(
    "pattern, expected_mask",
    [
        (".##.", (1 << 1) | (1 << 2)),       # .##. → bit1 och bit2
        ("#...", (1 << 0)),                  # #... → bit0
        ("....", 0),                         # all off
        ("####", (1 << 0) | (1 << 1) | (1 << 2) | (1 << 3)),
    ],
)
def test_pattern_to_mask(pattern, expected_mask):
    line = f"[{pattern}]"  # no buttons, no joltages
    m = Machine(line)
    assert m.target_mask == expected_mask
    assert m.num_lights == len(pattern)


def test_button_masks_example1():
    line = "[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}"
    m = Machine(line)

    # expected bitmasks
    expected = [
        (1 << 3),                  # (3)
        (1 << 1) | (1 << 3),       # (1,3)
        (1 << 2),                  # (2)
        (1 << 2) | (1 << 3),       # (2,3)
        (1 << 0) | (1 << 2),       # (0,2)
        (1 << 0) | (1 << 1),       # (0,1)
    ]

    assert len(m.button_masks) == len(expected)
    for got, exp in zip(m.button_masks, expected):
        assert got == exp

def test_specific_button_combo_reaches_target_example1():
    line = "[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}"
    m = Machine(line)

    # last two buttons
    b_last_two = m.button_masks[-2:]
    state = 0
    for b in b_last_two:
        state ^= b

    assert state == m.target_mask

def test_min_presses_bruteforce_on_examples():
    line1 = "[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}"
    line2 = "[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}"
    line3 = "[.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}"

    m1 = Machine(line1)
    m2 = Machine(line2)
    m3 = Machine(line3)

    assert m1.min_presses_bruteforce() == 2
    assert m2.min_presses_bruteforce() == 3
    assert m3.min_presses_bruteforce() == 2


def test_min_presses_bruteforce_small_synthetic():
    # pattern [.#.] → bit1 = 1
    # buttons: (1) and (0,1,2)
    line = "[.#.] (1) (0,1,2) {1,2}"
    m = Machine(line)

    # target is the middle light: 0b010
    assert m.target_mask == (1 << 1)

    best = m.min_presses_bruteforce()
    assert best == 1


def test_min_presses_bruteforce_no_solution():
    # 1 light but no buttons
    line = "[#] () {1,2}"
    m = Machine(line)

    best = m.min_presses_bruteforce()
    assert best is None

def test_machine_joltages_and_deltas():
    line = "[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}"
    m = Machine(line)

    assert m.target_counters == (3,5,4,7)
    assert m.num_counters == 4

    # knapp (3)
    assert m.button_counter_deltas[0] == (0,0,0,1)
    # knapp (1,3)
    assert m.button_counter_deltas[1] == (0,1,0,1)

def test_joltage_bfs_examples():
    line1 = "[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}"
    line2 = "[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}"
    line3 = "[.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}"

    m1 = Machine(line1)
    m2 = Machine(line2)
    m3 = Machine(line3)

    assert m1.min_presses_joltage_bfs() == 10
    assert m2.min_presses_joltage_bfs() == 12
    assert m3.min_presses_joltage_bfs() == 11
