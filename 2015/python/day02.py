"""
    Day 2: I Was Told There Would Be No Math
"""

import math

class Present:
    def __init__(self, dimensions:list[int]):
        self.dimensions = dimensions[:]
        self.dimensions.sort()
    
    def area(self):
        side1 = self.dimensions[0] *self.dimensions[1]
        side2 = self.dimensions[1] * self.dimensions[2]
        side3 = self.dimensions[2] *self.dimensions[0]
        return (2 * side1) + (2 * side2) + (2 * side3)

    def paper_requirements(self):
        slack = self.dimensions[0] * self.dimensions[1]
        return self.area() + slack
    
    def ribbon_requirements(self):
        # 2 * the smallest sidelength + 2 * the second smallest sidelength
            bow = math.prod(self.dimensions)
            ribbon = (2 * self.dimensions[0]) + (2 * self.dimensions[1])
            return bow + ribbon
        
    def __repr__(self):
        return f"Present: {self.dimensions[0]}x{self.dimensions[1]}x{self.dimensions[2]}"

def setup(path="input_day02.dat"):
    parsed = []
    with open(path,'r') as f:
        for r in f.read().splitlines():
            dimensions = list(map(int, r.split("x")))
            parsed.append(Present(dimensions))

        return parsed

if __name__ == "__main__":
    data = setup()
    p1 = sum(present.paper_requirements() for present in data)
    p2 = sum(present.ribbon_requirements() for present in data)
    print("Part 1:", p1)
    print("Part 2:", p2)
    
 