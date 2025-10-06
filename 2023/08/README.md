# Advent of Code 2023 Day08  

## Part 1  
This looked to be straightforward, traversing from node to node according to the directional input. And it would have been straightforward if only I read the instructions and actually thought about what they said.  
The instructions clearly stated to start from node AAA and keep moving until at node ZZZ. However, in the testinput AAA was node[0]. In the real input AAA was NOT node[0].  
This ended up causing an endless loop, I caught on after a while - only after wondering why this seemingly easy problem took so much processing, and starting to believe that my node-traversal-skills were seriously lacking somehow.

## Part 2  
This could easily have been too hard for me, but I remembered that at some point in one (or possibly more) of the previous years I had to calculate something similar using an LCM (least common multiple) algorithm.  
To be honest, I was not entirely confident that this would actually work for todays problem - since I was not sure if there were multiple stops ending in 'Z' for a starting point. That would probably have made things a lot more difficult. But the LCM method worked straight away. Just find all the starting points ending with 'A', and traverse them using the directions - save the amount of steps. Take this list of steps and find the LCM for them - which ended up being a quite large number :D  

