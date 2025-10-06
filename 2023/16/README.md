# Advent of Code 2023 Day16  

## Part 1  

Not overly complicated, simulate a beam of light bouncing around in a maze of mirrors and splitters.  
Took a while to get the logic correct, but nothing to hairy.

## Part 2  

Check all the possible starting points around the edges of the grid, which one gives the highest amount of lit up pixels.  
I had a off by one error, which I should have caught. But I didn't for some time.  
I'm not proud of my solution, it bruteforces the solution - which takes time. And I have used som arbitrary number of repetitions in the code - where I try to check that a grid has exhausted it's options and become stuck in an infinite loop so to speak.  This number could possibly be quite inappropriate for someone elses input. It worked for mine, but I bet if I used a smaller number, at some point I could begin to experience wrong answers.  