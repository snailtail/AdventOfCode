""" Day 2: Gift Shop """

def setup(path):
    """
    Parses input and returns a list of tuples. Each tuple represents a range (from,to) The to-value is to be treated as inclusive
    Example: [(11, 22), (95, 115), (998, 1012), (1188511880, 1188511890), (222220, 222224), (1698522, 1698528), (446443, 446449), (38593856, 38593862), (565653, 565659), (824824821, 824824827), (2121212118, 2121212124)]
    """
    with open(path, "r") as f:
        input = f.read().strip().split(",")
        return [tuple(int(value) for value in rangestring.split("-")) for rangestring in input]
        

def part1(data):
    """finds the invalid IDs by looking for any ID which is made only of some sequence of digits repeated twice"""
    invalid_ids = []
    for range_tuple in data:
        seq = range(range_tuple[0],range_tuple[1]+1)
        for number in seq:
            string_of_value = str(number)
            if len(string_of_value) % 2 != 0:
                continue
            if string_of_value[:len(string_of_value)//2] == string_of_value[len(string_of_value)//2:]:
                invalid_ids.append(number)
    return invalid_ids

def part2(data):
    """
    Looking for invalid IDs by checking if it is made only of some sequence of digits repeated at least twice
    """
    invalid_ids = []
    for range_tuple in data:
        seq = range(range_tuple[0],range_tuple[1]+1)
        for number in seq:
            string_of_value = str(number)
            for le in range(1,len(string_of_value)):
                part = string_of_value[:le]
                if len(part) * string_of_value.count(part) == len(string_of_value):
                    invalid_ids.append(number)
                    break
    return invalid_ids

if __name__ == "__main__":
    
    data = setup("testinput_day02.dat")
    p1_result = sum(part1(data))
    print("Part 1:", p1_result)
    p2_result = sum(part2(data))
    print("Part 2:", p2_result)