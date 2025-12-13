"""
    Day 1: Not Quite Lisp
"""

def setup(path="input_day01.dat"):
    with open(path,'r') as f:
        input = f.read().strip()
        return input

def parse_parenthesis(input: str) -> (int, int):
    value = 0
    part2_index = None
    for i, c in enumerate(input):
        if c == '(':
            value +=1
        elif c == ')':
            value -= 1
        
        if value == -1 and part2_index is None:
            part2_index = i

    if part2_index is None:
        part2_index = -1

    return (value, part2_index+1)

if __name__ == "__main__":
    data = setup()
    p1_result,p2_result = parse_parenthesis(data)
    print("Part 1:", p1_result)
    print("Part 2:", p2_result)