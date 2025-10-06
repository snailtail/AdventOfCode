# Advent of Code 2023 Day05  

## Part 1  
Wow, I may have overworked my solution for this. But I kind of just went with the flow once I got started. Not too complex, but a challenge to get all the "wiring" correct. Used testcases a bit, not as much as I would have liked. Might come back and make more of those later.  

## Part 2  
Oh dear... If i were to bruteforce part 2 with the methods from part 1 it would take a lot more memory than my machine has, and more time than I have on this earth probably.  Had to find a better way. Got some ideas from people talking about reversing the method, so I went for that. Built a reverse lookup from location number to seed number.  
Had some really bad ideas about generating real ranges for step 2 at first, but that took a lot of processing power. So I eventually reused the MapperRange type, and just checked if a seed number was within a range using them. In the end the solution ran part 2 in roughly 9 seconds on my Windows laptop.  
Got some feedback about using "Union Find Path Compression" - which I have to look into, I have no idea what that is. :D  