"""
    Day 6: 
"""

def setup(path = "testinput_day06.dat"):
    """
        Parses input and ...
        Example: 
    """
    with open(path,"r") as f:
        input = f.read().splitlines()
    
    return input

if __name__ == "__main__":
    data = setup("testinput_day06.dat")
    print(data)