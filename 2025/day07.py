"""
Day 7: Laboratories
"""


def setup(path="testinput_day07.dat"):
    """
    Parses input and returns a 2-dimensional grid
    Example:
           [['.', '.', '.', '.', '.', '.', '.', 'S', '.', '.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.', '.', '^', '.', '.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.', '^', '.', '^', '.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '^', '.', '^', '.', '^', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '^', '.', '^', '.', '.', '.', '^', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '^', '.', '^', '.', '.', '.', '^', '.', '^', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'],
            ['.', '.', '^', '.', '.', '.', '^', '.', '.', '.', '.', '.', '^', '.', '.'],
            ['.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'],
            ['.', '^', '.', '^', '.', '^', '.', '^', '.', '^', '.', '.', '.', '^', '.'],
            ['.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.']]
    """
    input = []
    with open(path, "r") as f:
        for row in f:
            v = list(row.strip())
            input.append(v)

    return input


def get_start_position(grid):
    """
       Takes in a 2-dimensional grid and returns the position for the 'S' marking the starting position
       In this case we just assume the start is on row 0
       Returns: Tuple with index: (row,col)
    """
    start_index = grid[0].index("S")
    return (0, start_index)


def get_splitter_indexes(grid, row):
    splitter_indexes = set()
    for pos, v in enumerate(grid[row]):
        if v == '^':
            splitter_indexes.add(pos)

    return splitter_indexes

def part1(grid):
    grid_width = len(grid[0])
    (s_row,s_col) = get_start_position(grid)
    beams = set()
    beams.add(s_col)
    cur_row = s_row + 1
    split_count = 0
    while cur_row < len(grid):
        # håll koll på alla beams i ett set med col-värden
        # vi behöver eg. bara ha c eftersom vi alltid vet vilken rad vi kollar på
        # för varje beam c, checka om c kolliderar med c för någon ^ i get_splitter_indexes() för den raden,  så ska denna beam splittas (tas bort och ersättas
        # med två nya på c-1 och c+1 jämfört med ^)
        updated_beams = set()
        for beam in beams:
            splitters = get_splitter_indexes(grid,cur_row)
            if beam in splitters:
                split_count += 1
                newbeam_left = beam - 1
                newbeam_right = beam + 1
                if newbeam_left >=0:
                    updated_beams.add(newbeam_left) # add index to left
                if newbeam_right < grid_width:
                    updated_beams.add(beam+1) # add index to right
            else:
                # add back in the original beam
                updated_beams.add(beam)
        beams = updated_beams
        cur_row +=1
    return split_count


def part2(grid):
    """
        Counts number of ways one tachyon particle will take via the quantum tachyon manifolds (splitters)
        Returns the total count of these ways
    """
    # Håll en grid med antal gånger man kommer hamna i den cellen
    # för varje rad, kolla cellerna på kolumn-index där antal inkommande vägar uppifrån är större än 0
    # varje gång man stöter på en splitter ska man ta inkommande antal från raden ovan, och plussa på det på nuvarande rad fast vid col-1 och col+1 jämfört med splittern
    # om man inte stöter på en splitter så ska det inkommande värdet plussas på i nuvarande kolumnindex bara.
    # lite koll på att man befinner sig innanför gridden osv. 
    # sen är det bara att summera antalet vägar på sista raden - det blir totala antalet kombinationer

    (s_row,s_col) = get_start_position(grid)
    grid_width = len(grid[0])
    grid_height = len(grid)
    ways = [[0 for x in range(grid_width)] for y in range(grid_height)] # här håller vi "räkningen" på hur många gånger en stråle kan passera en viss grid (tror jag)
    ways[s_row][s_col]=1 # 
    cur_row = s_row + 1
    while cur_row < grid_height:
        for cur_col in range(grid_width):
            # om vi hittar en splitter här så ska vi plussa på +1 på cur_col-1 och cur_col +1
            incoming = ways[cur_row-1][cur_col]
            if incoming == 0:
                continue
            if grid[cur_row][cur_col]=='^':
                lvalue = cur_col - 1
                rvalue = cur_col + 1
                if lvalue >= 0:
                    ways[cur_row][lvalue] += incoming
                if rvalue < grid_width:
                    ways[cur_row][rvalue] += incoming
            elif ways[cur_row-1][cur_col]>0:
                ways[cur_row][cur_col] += incoming
        cur_row += 1

    # och när vi är färdiga så borde totala antalet vägar bli summan av "sista raden"
    total_ways = sum(ways[-1])

    return total_ways

if __name__ == "__main__":
    data = setup("input_day07.dat")
    p1_result = part1(data)
    print("Part 1:", p1_result)
    p2_result = part2(data)
    print("Part 2:", p2_result)
