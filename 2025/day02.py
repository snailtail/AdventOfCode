""" Day 2: Gift Shop """

def setup(path):
    data = []
    with open(path, "r") as f:
        input = f.readlines()[0].split(",")
        for v in input:
            parts = v.split("-")
            v = (int(parts[0]), int(parts[1]))
            data.append(v)
    return data



def part1(data):
    invalid_ids = []
    for r in data:
        seq = range(r[0],r[1]+1)
        for v in seq:
            s = str(v)
            if s[:len(s)//2] == s[len(s)//2:]:
                invalid_ids.append(v)
    return invalid_ids

def part2(data):
    invalid_ids = []
    for r in data:
        seq = range(r[0],r[1]+1)
        for v in seq:
            s = str(v)
            for le in range(1,len(s)):
                part = s[:le]
                if len(part) * s.count(part) == len(s):
                    invalid_ids.append(v)
                    #print(v)
                    break
    return invalid_ids

if __name__ == "__main__":
    
    data = setup("testinput_day02.dat")
    p1_result = sum(part1(data))
    print(p1_result)
    p2_result = sum(part2(data))
    print(p2_result)