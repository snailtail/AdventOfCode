"""
--- Day 4: Cafeteria ---
"""

def setup(path):
    """
        Parses input and returns a list of ranges (start, stop), and a list of id's (integers)
        Example: 
    """

    ranges=[]
    ids=[]
    past_ranges=False
    with open(path,"r") as f:
        for row in f.readlines():
            if row.strip() =="":
                past_ranges=True

            elif past_ranges:
                ids.append(int(row.strip()))
            else:
                (start, stop) = (int(x) for x in row.strip().split("-"))
                ranges.append((start,stop))
    #print(ranges, ids)
    return (ranges, ids)


def get_valid_ids(ids, ranges):
    """
        Finds all ids which exist inside any of the ranges (start, stop (inclusive))
        Returns: Set of valid id's.
    """
    valid = {
        x
        for x in ids
        for (start, stop) in ranges
        if start <= x <= stop
    }
    return valid

def get_invalid_ids(ids, ranges):
    """
        Finds all ids which are not within any of the ranges.
        Returns a set containing the invalid id's
    """

    invalid_ids = set(ids) - get_valid_ids(ids,ranges)
    return invalid_ids


def merge_ranges(ranges):
    """
        Merges overlapping ranges.
        Returns a list of the merged ranges.
    """
    if not ranges:
        return []

    ranges = sorted(ranges, key=lambda r: r[0])
    merged = []
    cur_start, cur_end = ranges[0]

    for start, stop in ranges[1:]:
        if start <= cur_end + 1:
            cur_end = max(cur_end, stop)
        else:
            merged.append((cur_start, cur_end))
            cur_start, cur_end = start, stop

    merged.append((cur_start, cur_end))
    return merged

def get_all_valid_id_count(ranges):
    """
        Finds the count of unique valid id's in the ranges.
    """
    merged = merge_ranges(ranges)
    total_count = sum(stop - start + 1 for start, stop in merged)
    return total_count


if __name__ == "__main__":
    (ranges, ids) = setup("testinput_day05.dat")

    valid = get_valid_ids(ids,ranges)
    print("Part 1:", len(valid))

    total_valid_count = get_all_valid_id_count(ranges)
    print("Part 2:", total_valid_count)

