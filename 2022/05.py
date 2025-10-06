import re
from copy import deepcopy
def process(): 
    with open('./data/05.dat') as f:
        schema, crates = f.read().split('\n\n')
        schema = schema.split('\n')
        crates = crates.split('\n')

    order = []
    stacks_step1 = {}
    location = {}

    # Using the stack-like functionality of List pop the last line and extract data for the stacks
    k = schema.pop()
    for pos in range(len(k)):
        if k[pos] != ' ':
            stacks_step1[k[pos]] = []
            location[k[pos]] = pos
            order.append(k[pos])

    # Take what is left in the schema for stacks, and go backwards through it to fill the stacks with crates.
    for line in reversed(schema):
        for key in location.keys():
            if line[location[key]] != ' ':
                stacks_step1[key].append(line[location[key]])

    # Get a separate copy of the stacks for use in step 2
    stacks_step2 = deepcopy(stacks_step1)

    for line in crates:
        # use regex to extract numeric values from the instruction line, those are all we need.
        values = re.findall(r"(\d+)", line)
        count = int(values[0])
        fromstack = values[1]
        tostack = values[2]

        # Step 1, move one crate at a time
        for n in range(count):
            item = stacks_step1[fromstack].pop()
            stacks_step1[tostack].append(item)

        # Step 2, move all the crates at the same time
        stacks_step2[tostack] += stacks_step2[fromstack][-count:]
        stacks_step2[fromstack] = stacks_step2[fromstack][:-count]

    step1="".join([stacks_step1[n][-1] for n in order])
    print(f"Step 1: {step1}")
    step2="".join([stacks_step2[n][-1] for n in order])
    print(f"Step 2: {step2}")
  
    
def main():
    process()
    
    
if __name__=="__main__":
    main()