"""
Day 12: ???
"""

def setup(path="testinput_day12.dat"):
    """
    Parses input and returns ....?
    """
    input = []
    
    with open(path, "r") as f:
        for row in f:
            rowdata = row.strip()
            input.append(rowdata)
    
    return input


if __name__ == "__main__":
    parseresult = setup()
    print(parseresult)
    

    
