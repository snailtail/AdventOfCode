"""
--- Day 4: Printing Department ---
"""

def setup(path):
    """
        Parses input and returns a list of lists / 2 dimensional list, representing a grid
        Example: [['.', '.', '@', '@', '.', '@', '@', '@', '@', '.'], ['@', '@', '@', '.', '@', '.', '@', '.', '@', '@'], ['@', '@', '@', '@', '@', '.', '@', '.', '@', '@'], ['@', '.', '@', '@', '@', '@', '.', '.', '@', '.'], ['@', '@', '.', '@', '@', '@', '@', '.', '@', '@'], ['.', '@', '@', '@', '@', '@', '@', '@', '.', '@'], ['.', '@', '.', '@', '.', '@', '.', '@', '@', '@'], ['@', '.', '@', '@', '@', '.', '@', '@', '@', '@'], ['.', '@', '@', '@', '@', '@', '@', '@', '@', '.'], ['@', '.', '@', '.', '@', '@', '@', '.', '@', '.']]
    """
    with open(path,"r") as f:
        input = [[v for v in f.strip()] for f in f.readlines()]
        #print(input)
        return input

def adjacent_rolls(grid, row, col):
    """
        Takes in a grid, a row index, and a column index.
        Returns the count of rolls in the adjacent potential 8 grids.
    """
    
    grid_width=len(grid[0])
    grid_height = len(grid)
    adjacent_count=0
    directions = [(-1,0),(1,0),(0,-1),(0,1),(-1,1),(-1,-1),(1,-1),(1,1)]
    for r, c in directions:
        rindex = r + row
        cindex = c + col
        if rindex >= 0 and rindex < grid_height and cindex >= 0 and cindex < grid_width:
            if grid[rindex][cindex]=='@':
                adjacent_count += 1
    return adjacent_count

def part1(data):
    #adjacent_rolls(data,4,4)
    
    count = 0
    for r in range(len(data)):
        for c in range(len(data[0])):
            if data[r][c]=='@':
                amount = adjacent_rolls(data,r,c)
                if amount < 4:
                    print(f"row: {r} col: {c}")
                    count += 1
    return count

if __name__ == "__main__":
    data = setup("input_day04.dat")
    part1_result = part1(data)
    print("Part 1:", part1_result)
