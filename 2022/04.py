from aoc import inpututil as iu

def Process(line):
    # Uses set intersect to check if one set contains the other - fully for step 1 and partially for step 2.
    step1=False
    step2=False
    pair=line.split(',')
    
    # Make ranges from the input, and turn them into sets.
    r1=list(map(int,pair[0].split('-')))
    r2=list(map(int,pair[1].split('-')))
    s1 = set(range(r1[0],r1[1]+1))
    s2 = set(range(r2[0],r2[1]+1))
    
    # Step 1 check using set intersect
    # If the result of intersect of both sets is equal to one of the sets we have full overlap
    if s1 & s2 == s1 or s1 & s2 == s2:
        step1= True
    else:
        step1= False
    
    # And for step 2, using intersect again - but this time for partial overlap.
    # If no overlap occurs then the result will be an empty set.
    if s1 & s2 != set():
        step2 = True
    else:
        step2 = False
    return (step1,step2)

def main():
    util = iu()
    data = util.GetLines('04')
    step1_count=0
    step2_count=0
    for line in data:
        s1,s2 =  Process(line)
        if s1:
            step1_count+=1
        if s2:
            step2_count+=1
        
    print(step1_count)
    print(step2_count)

if __name__=="__main__":
    main()