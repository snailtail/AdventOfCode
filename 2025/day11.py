"""
Day 10: Reactor
"""


def setup(path="testinput_day11.dat") -> list[str]:
    """
    Parses input and returns a ...
    """
    input = []
    with open(path, "r") as f:
        for row in f:
            input.append(row.strip())

    return input

if __name__ == "__main__":
    result = setup("testinput_day11.dat")
    print(result)
    
    #print("Part 1:", nnn1)
    #print("Part 2:", nnn2)
