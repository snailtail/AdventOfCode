# Advent of Code 2023 Day02  

## Step 1  
Okay, so this is more parsing of inputs and calculating a few numbers. 
Nothing really troublesome about step 1. But as usual I suspected that step 2 would be something much more tricky, so I tried building for robustness and extendability from the start.  
Today I also did something that I usually skip. Tests! I tried to use TDD for this puzzle. 
I started by writing testcases for step 1, and from that generating my types and methods, and only then starting to work on making the tests run successfully.

## Step 2  
Aha! Just an easy addon from step 1. We need to calculate the max amount of cubes used for each color - or as the question was asked "For each game, find the minimum set of cubes that must have been present".
With my types for step 1 this was easy, just add a few properties and a few Max() calculations and we're home.  
Continued with the TDD philosophy of course, and it's quite handy having tests for step 1 making sure I didn't break anything.  