# Advent of Code 2023 Day14  

## Part 1  

This was fun, an easier day but still an exercise for the brain.  
Rolling rocks on a platform. Not much deviousness to be found in this part.  

## Part 2  

Oh here we go again... Run the solution for 1 billion cycles, where 1 cycle is tilting North, South, East, West.
First extending the solution to be able to tilt the platform in all four directions - not to hard, just a few differences - or so I thought. One tricky bit was remembering to roll the correct rock first depending on the direction of the tilt. This was easily solved when I encountered it.   

Okay, so it would seem that I have two problems with part 2.  
1. My tilting works for the example input, and after 1, 2, and 3 cycles of tilting in all four directions everything looks good. But after running the cycles longer, something is off - there is something I have not accounted for.  
2. Running 1 billion cycles - that will take forever. Or at least too long for comfort. It shouldn't need to run for more than a couple of seconds. I'm guessing there is some way to mod the amount of cycles down - some repeating pattern at some point in the cycles. But since I can't quite figure out the first issue - this is not on my priority list.  