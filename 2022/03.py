

def pairs(line):
    # Find the item type that appears in both compartments
    middle=int(len(line)/2)
    comp1=line[0:middle]
    comp2=line[middle:]
    for character in comp1:
        if character in comp2:
            return character

def in_all_three(l1, l2, l3):
    # Checks each character in l1 and returns it, if it's present in l2 and l3 as well.
    for character in l1:
        if character in l2 and character in l3:
            return character

def getValue(n):
    # Get the value for each item type, using ord to retrieve the ASCII value
    # and just subtracting so we end up in the specified ranges:
    # Lowercase item types a through z have priorities 1 through 26.
    # Uppercase item types A through Z have priorities 27 through 52.
    
    if n.islower():
        return ord(n)-96 # lowercase a is 97 and should be 1
    else:
        return ord(n)-38 # Uppercase A is 65 and should be 27
    


def main():
    data = [line.rstrip() for line in open('./data/03.dat','r')]
    step1_sum=0
    for item in data:
        step1_sum += getValue(pairs(item))
    print(step1_sum)
    
    step2_sum=0
    # Loop over the list in chuncks of three
    for index in range(2,len(data),3):
        step2_sum += getValue(in_all_three(data[index],data[index-1],data[index-2]))
    print(step2_sum)
    

if __name__=="__main__":
    main()