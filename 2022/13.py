from functools import cmp_to_key

from aoc import inpututil as iu
import os

file=os.path.basename(__file__).replace('.py','')
util = iu()


def compare(part1,part2):
    """
        Compare two parts of a pair.
        Returns -1 if part 1 is smaller than part 2.
        Returns 0 if they are equal
        Returns 1 if part 2 is smaller than part 1
    """
    if isinstance(part1, int) and isinstance(part2,int):
        # Both are integers
        if part1 < part2:
            return -1
        elif part1 == part2:
            return 0
        else:
            return 1
    elif isinstance(part1, list) and isinstance(part2, list):
        # Both are lists
        i = 0
        while i<len(part1) and i<len(part2):
            c = compare(part1[i], part2[i])
            if c==-1:
                return -1
            if c==1:
                return 1
            i += 1
        if i==len(part1) and i<len(part2):
            return -1
        elif i<len(part1) and i==len(part2):
            return 1
        else:
            return 0
    elif isinstance(part1, int) and isinstance(part2, list):
        # Part 1 is int, make it a list and run compare again
        return compare([part1], part2)
    else:
        # Part 2 is int, make it a list and run compare again
        return compare(part1, [part2])



def step1(input):
    """
        Splits the data into pairs. And uses the compare() method to see if part1 of the pair is smaller than part2
        Prints out the sum of the 1-based indices for the list where part1 is smaller than part 2 (correctly sorted).
    """
    result = 0
    for i, group in enumerate(input.strip().split('\n\n')):
        pair1, pair2 = group.split('\n')
        pair1 = eval(pair1)
        pair2 = eval(pair2)    
        if compare(pair1,pair2)==-1:
            result += i+1 # 1-based index...

    print(f"Step 1 {result}")


def step2(input):
    
    """
        Splits the data, but ignores pairs and just adds all the packets to a large list.
        Additionally adds two divider packets to the list.
        Sorts the list using the compare() method, with the help of cmp_to_key() from functools.
        Prints the product of the (1-based) indices where the divider packets end up.
    """
    orderedpackets=[]

    # Append the special divider packets
    orderedpackets.append([[2]])
    orderedpackets.append([[6]])
    # Append the packets from the input
    for i, group in enumerate(input.strip().split('\n\n')):
        pair1, pair2 = group.split('\n')
        pair1 = eval(pair1)
        pair2 = eval(pair2)    
        orderedpackets.append(pair1)
        orderedpackets.append(pair2)

    # Sorting can apparently be done using the cmp_to_key function from functools
    # It compares each element with every other element until a sorted list is obtained
    # And calls a separate method which does the actual comparison, which is perfect since we already built the compare method!
    orderedpackets = sorted(orderedpackets,key=cmp_to_key(lambda p1,p2: compare(p1,p2)))
    #print(orderedpackets)

    # Last piece of the solution for step 2 is to find the divider packets
    result=1 # start at 1 to manage the multiplications
    for index,packet in enumerate(orderedpackets):
        if packet==[[2]] or packet==[[6]]: # we found a divider packet
            result = result * (index+1) # 1-based index
    
    print(f"Step 2: {result}")


def main():
    data = util.GetContents(file, test=False)
    step1(data)
    step2(data)

if __name__=="__main__":
    main()