"""
Day 10: Factory
"""

class Machine:
    def __init__(self,data: str):
        self.data = data


    def __repr__(self):
        return f"Machine({self.data})"

def setup(path="testinput_day10.dat") -> list[Machine]:
    """
    Parses input and returns a list of Machine
    """
    input = []
    with open(path, "r") as f:
        for row in f:
            input.append(Machine(row.strip()))

    return input

if __name__ == "__main__":
    machines = setup("testinput_day10.dat")
    print(machines)