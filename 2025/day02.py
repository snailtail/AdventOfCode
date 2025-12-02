""" Day 2: Gift Shop """

def setup(path):
    with open(path, "r") as f:
        input = f.readline().strip().split(",")
        return [tuple(int(x) for x in s.split("-")) for s in input]
        

def part1(data):
    """finds the invalid IDs by looking for any ID which is made only of some sequence of digits repeated twice"""
    invalid_ids = []
    for r in data:
        seq = range(r[0],r[1]+1)
        for v in seq:
            s = str(v)
            if len(s) % 2 != 0:
                continue
            if s[:len(s)//2] == s[len(s)//2:]:
                invalid_ids.append(v)
    return invalid_ids

def part2(data):
    """Looking for invalid IDs by checking if it is made only of some sequence of digits repeated at least twice"""
    invalid_ids = []
    for r in data:
        seq = range(r[0],r[1]+1)
        for v in seq:
            s = str(v)
            for le in range(1,len(s)):
                part = s[:le]
                if len(part) * s.count(part) == len(s):
                    invalid_ids.append(v)
                    break
    return invalid_ids

if __name__ == "__main__":
    
    data = setup("input_day02.dat")
    p1_result = sum(part1(data))
    print(p1_result)
    p2_result = sum(part2(data))
    print(p2_result)