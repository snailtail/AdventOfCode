# Advent of Code 2023 Day11  

## Part 1  

Not that complicated. Parse the data, today I used a string for the data, and calculated column and row positions using indexes. This (in my opinion) made adding columns and rows kind of easier.
After extending the map, it was just a matter of scanning for the galaxies coordinates, calculating the manhattan distances between all possible pairs and printing the sum of those distances.  

## Part 2

Oh well. Shouldn't I have known. In part 1 I spent a decemt amount of time building the logic for extending the map. Which, although it was a fun and interesting exercise, came to be a complete waste of time.   
For Part 2 we needed to extend each empty row 1 million times instead of just duplicating them, so we couldn't be doing that with the actual in-memory-map. At least I did not feel like doing that.  
So what I did was I reverted back to using the non extended map, and instead just checking which rows and columns were supposed to be extended. Then I added a parameter which let me specify how many copies of the rows and columns should be made. And then I modified the Manhattan distance calculator to account for any rows and columns in between the two points that were supposed to be extended, and used that to calculate a correct distance.  

Much due to TDD I could do these modifications quite fast and easy since I immediately knew if my Part 1 solution still held up with the new code, and it was easy to add a few checks for the new testcases for part 2.  