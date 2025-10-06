# Advent of Code 2023 Day01  

## Step 1  
Started with using LINQ for extracting only the digits into an array, and choosing the first and last elements. Quick and dirty, and it worked fine for step 1. But as per usual...  

## Step 2  
Holy moly, for the first day this was unusually tricky!  
I realized that Regex should be the way to go instead, so I rewrote the solution so I could use the same method for step 1 and 2.  
However...! Some number overlapping issue had me almost rage-quitting for a much too long while.  

The solution for me was realizing that I could make the Regex matching go from right to left instead of left to right, to avoid the issues due to overlapping numbers.  I think that "eightwo" was the culprit in my input data.  

As somewhat of a Regex newbie this was a good learning experience.