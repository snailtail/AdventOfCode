def step1(grid):
    visible = 0
    for row in range(len(grid)):
        for col in range(len(grid[0])):
            treeheight = grid[row][col]

            # outer edges
            if row == 0 or row == len(grid) - 1 or col == 0 or col == len(grid[0]) - 1:
                visible += 1
                continue

            # Left view
            for n in range(0, col):
                if grid[row][n] >= treeheight:
                    break
            else:
                visible += 1
                continue

            # Right view
            for n in range(col + 1, len(grid[0])):
                if grid[row][n] >= treeheight:
                    break
            else:
                visible += 1
                continue

            # Top view
            for n in range(0, row):
                if grid[n][col] >= treeheight:
                    break
            else:
                visible += 1
                continue

            # Bottom view
            for n in range(row + 1, len(grid)):
                if grid[n][col] >= treeheight:
                    break
            else:
                visible += 1
                continue

    print(f"Step 1: {visible}")


def step2(grid):
    best_treescore = 0
    for row in range(len(grid)):
        for col in range(len(grid[0])):
            treeheight = grid[row][col]

            # outer edges
            if row == 0 or row == len(grid) - 1 or col == 0 or col == len(grid[0]) - 1:
                continue
            score = 1

            # Right view
            visible_count = 0
            for n in range(col + 1, len(grid[0])):
                visible_count += 1
                if grid[row][n] >= treeheight:
                    break
            score *= visible_count

            # Left view
            visible_count = 0
            for n in reversed(range(0, col)):
                visible_count += 1
                if grid[row][n] >= treeheight:
                    break
            score *= visible_count

            # Top view
            visible_count = 0
            for n in reversed(range(0, row)):
                visible_count += 1
                if grid[n][col] >= treeheight:
                    break
            score *= visible_count

            # Bottom view
            visible_count = 0
            for n in range(row + 1, len(grid)):
                visible_count += 1
                if grid[n][col] >= treeheight:
                    break
            score *= visible_count


            if score > best_treescore:
                best_treescore = score

    print(f"Step 2: {best_treescore}")

def main():
    with open('./data/08.dat', 'r') as f:
        data = [[int(height) for height in str.strip(l)] for l in f.readlines()]
    step1(data)
    step2(data)


if __name__=="__main__":
    main()