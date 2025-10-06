with open('./data/01.dat', 'r') as f:
    calories = f.read()

# List will store the sums of each elfs calories
elfs=[]
for elf in calories.split('\n\n'):
    elfs.append(sum(list(map(int,elf.split()))))

# Sort the list in descending order
elfs.sort(reverse=True)

# Step 1 - The max calorie count for an elf
print(elfs[0])

# Step 2 - The sum of the top three calorie counts
print(sum(elfs[0:3]))