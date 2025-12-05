"""
--- Day 4: Printing Department ---
"""

def setup(path):
    """
        Parses input and returns a list of lists / 2 dimensional list, representing a grid
        Example: [['.', '.', '@', '@', '.', '@', '@', '@', '@', '.'], ['@', '@', '@', '.', '@', '.', '@', '.', '@', '@'], ['@', '@', '@', '@', '@', '.', '@', '.', '@', '@'], ['@', '.', '@', '@', '@', '@', '.', '.', '@', '.'], ['@', '@', '.', '@', '@', '@', '@', '.', '@', '@'], ['.', '@', '@', '@', '@', '@', '@', '@', '.', '@'], ['.', '@', '.', '@', '.', '@', '.', '@', '@', '@'], ['@', '.', '@', '@', '@', '.', '@', '@', '@', '@'], ['.', '@', '@', '@', '@', '@', '@', '@', '@', '.'], ['@', '.', '@', '.', '@', '@', '@', '.', '@', '.']]
    """
    with open(path,"r") as f:
        input = [list(f.strip()) for f in f.readlines()]
        return input

def get_adjacent_rolls(grid, row, col):
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

def get_removable_rolls(grid):
    """
    Input: a grid of paper rolls
    Return a list of grid coordinates which have less than 4 adjacent rolls
    """

    removable_rolls = []
    for r in range(len(grid)):
        for c in range(len(grid[0])):
            if grid[r][c]=='@':
                amount = get_adjacent_rolls(grid,r,c)
                if amount < 4:
                    removable_rolls.append((r,c))

    return removable_rolls


def part1(data):
    """
    Solve part 1 by checking how many "rolls" that have less than 4 adjacent rolls.
    """
    
    count = 0
    for r in range(len(data)):
        for c in range(len(data[0])):
            if data[r][c]=='@':
                amount = get_adjacent_rolls(data,r,c)
                if amount < 4:
                    count += 1
    return count




def part2(data):
    """
    Solve part 2 by removing all rolls that have less than 4 adjacent rolls, until none are left.
    Returns: Count of the total removable rolls.
    """
    
    removable = get_removable_rolls(data)
    count = len(removable)
    while removable:
        for (r,c) in removable:
            data[r][c]='x'
        removable = get_removable_rolls(data)
        count += len(removable)

    return count

def print_grid(grid):
    for r in range(len(grid)):
        print("| ", end="")
        for c in range(len(grid[0])):
            print(grid[r][c], end=" | ")
        
        print("\n" + "-"*41)
    
    print()


if __name__ == "__main__":
    data = setup("testinput_day04.dat")
    part1_result = len(get_removable_rolls(data))
    print("Part 1:", part1_result)
    part2_result = part2(data)
    print("Part 2:", part2_result)

