"""
    Day 4: The Ideal Stocking Stuffer
"""
import hashlib

def setup(test: bool = False):
    if test:
        return "abcdef"
    
    return "yzbqklnj"
    
if __name__=="__main__":
    data = setup(test=False)
    
    part1_found = False
    for i in range(0,100_000_000_000):
        s = f"{data}{i}"
        res = hashlib.md5(s.encode())
        res_hex = res.hexdigest()
        if res_hex.startswith("0"*5) and not part1_found:
            print("Part 1:", i)
            part1_found=True
        elif res_hex.startswith("0"*6):
            print("Part 2:", i)