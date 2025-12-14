from pathlib import Path
from day05 import setup, NiceString
import pytest

def parse_testdata(path="testinput_day04.dat"):
    base_path = Path(__file__).parent.parent
    input = setup(base_path / path)
    return input

@pytest.mark.parametrize("text, expected_result",
                         [
                             ('haegwjzuvuyypxyu',True),
                             ('dvszwmarrgswjxmb',False)
                         ])
def test_forbidden_strings(text:str, expected_result: bool):
    ns = NiceString(text)
    assert ns.contains_forbidden_strings() == expected_result

@pytest.mark.parametrize(
        "text, expected_count",
        [
            ("ugknbfddgicrmopn",3),
            ("yyyypctry",0),
            ("dvszwmarrgswjxmb",1),
        ]
)
def test_count_legal_vowels(text:str, expected_count:int):
    ns = NiceString(text)
    assert ns.count_legal_vowels() == expected_count


@pytest.mark.parametrize(
        "text, expected_outcome",
        [
            ("aabbccdd",True),
            ("abcd",False),
            ("",False),
            ("abbe",True),
        ]
)
def test_contains_double_letters(text:str, expected_outcome:bool) -> None:
    ns = NiceString(text)
    assert ns.contains_double_letters() == expected_outcome

@pytest.mark.parametrize(
        "text, expected_outcome",
        [
            ('ugknbfddgicrmopn',True),
            ('aaa',True),
            ('jchzalrnumimnmhp',False),
            ('haegwjzuvuyypxyu',False),
            ('dvszwmarrgswjxmb',False),
        ]
)
def test_is_nice_part1(text:str, expected_outcome:bool) -> None:
    ns = NiceString(text)
    assert ns.is_nice() == expected_outcome


@pytest.mark.parametrize(
        "text, expected_outcome",
        [
            ('qjhvhtzxzqqjkmpb',True),
            ('xxyxx',True),
            ('uurcxstgmygtbstg',False),
            ('ieodomkazucvgmuy',False),
        ]
)
def test_is_nice_part2(text:str, expected_outcome:bool) -> None:
    ns = NiceString(text)
    assert ns.is_nice(part2=True) == expected_outcome