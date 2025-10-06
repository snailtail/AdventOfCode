from collections import defaultdict
import re

def extract_sizes(command):
    pattern = '\d+'
    sizes = [int(x) for x in re.findall(pattern, command)]
    return sizes

with open('./data/07.dat', 'r') as file:
    lines = file.read()

# Using defaultdict for ease of use - if the key does not exist, we will not get a key-error, but instead add a new item with default value 0.
dir_sizes = defaultdict(lambda : 0)
dir_tree = []

# Split by "$ cd" to find all actions after changing the current workdir. Then split on newlines, and find all numeric values within.
for directory, size in [(command.split('\n')[0], sum(extract_sizes(command))) for command in lines.split('$ cd') if command != '']: 
    directory = directory.strip()
    if directory == '..':
        dir_tree.pop()
    else:
        dir_tree.append(directory)
    cur_dir = ''
    for sub_directory in dir_tree:
        cur_dir += (sub_directory + '/')
        dir_sizes[cur_dir] += size

# Step 1
# Sum of all which are below the threshold 100000
step1_sum=sum([size for directory, size in dir_sizes.items() if size < 100000])
print('Step 1: ', step1_sum)



# Step 2
# Find the smallest of those who are big enough to free up the desired space
space_used = dir_sizes['//']
space_to_delete = 30000000 - (70000000 - space_used)
step2=min([size for directory, size in dir_sizes.items() if size >= space_to_delete])
print('Step 2: ', step2)