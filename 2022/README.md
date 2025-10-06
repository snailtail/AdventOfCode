# :christmas_tree: Advent of Code 2022 :christmas_tree:
[Advent of Code](https://adventofcode.com/2022) by [Eric Wastl](http://was.tl)

For this years challenge I will attempt to solve as many pussles as possible using Python 3 :snake:

- [- Day 1: Calorie Counting -](./01.md)  
Quite an easy start. Made a few touch-ups to the code after completing the challenge.

- [- Day 2: Rock Paper Scissors -](./02.md)
Not very complicated, I didn't have to keep track of player 1 - but as usual I'm trying to think ahead in step 1 what might come in step 2, so I made the basis around keeping track of both scores. Decided to leave it in - and step 2 was just a small routine in front of step 1.

- [- Day 3: Rucksack Reorganization -](./03.md)
A fun little exercise, searching for characters apperaring in multiple strings or parts of strings.

- [- Day 4: Camp Cleanup -](./04.md)
Today we had to check for overlap in ranges. Using sets in Python made things very easy, due to the intersect functionality.

- [- Day 5: Supply Stacks -](./05.md)
This one was a bit trickier, but after I discovered that Lists in Python could be handled almost like stacks it became easier. Spent way too much time on the parsing of the input. Tried regex for picking out the moves for the crane instead of splitting as I usually do.

- [- Day 6: Tuning Trouble -](./06.md)
Parsing a string looking for the first chunk consisting of unique characters. Using the set functionality to check for uniqueness.

- [- Day 7: No Space Left On Device - ](./07.md)
Tricky...!  Parsing "commands", building and storing the paths and calculating their sizes. Parsing the input was a bit on the tricky side today.

- [- Day 8: Treetop Tree House -](./08.md)
Basically just traversing a grid and counting values above a threshold. But oh my goodness how I struggled with off-by-one errors on this one...

- [- Day9: Day 9: Rope Bridge -](./09.md)
Keeping track of knots on a rope. For some reason this is one of those puzzles that seems quite easy, but I struggle immensely with... Painful to solve for some reason. Had to rewrite everything for step 2. >.<

- [- Day 10: Cathode-Ray Tube -](./10.md)
A lot of fun! Seems easier today than yesterday... At least for me.
Simulating a cathode ray tube, from a list of instructions.

- [- Day 11: Monkey in the Middle -](./11.md)
Holy mathematics Batman! Step 1 was mainly about getting on par with the parsing of the input. But step 2 was a nightmare which required research in the mathematical field, since I don't have an infinite amount of time, and/or five trillion petabytes of RAM. LCM to the rescue after some serious googling.
Overworked the solution a bit, with the Monkey class, but at least I didn't start out too "cheap" ending up having to rewrite everything for step 2 this time. :stuck_out_tongue_closed_eyes:

- [- Day 12: Hill Climbing Algorithm -](./12.md)
So I woke up to Graphs this morning, and wanted to go straight back to bed. But a bit of googling, and slowly remembering day 15 of last year I convinced myself to go ahead anyway. Last year I used Dijkstra's algorithm, but BFS seems to be a viable option - So let's implement Breadth First Search in Python then eh?

- [- Day 13: Distress Signal -](./13.md)
Holy snailfish dejavu Batman! Oh no... Not this again, I gave up on this last year. But as the day passes I start thinking that perhaps Pythons `eval()` is my friend? Going to try for step 1 at least.
`eval()` really helped to parse the input into something manageable! For step 1 it was challenging to get the comparison logic correct. In the end it became some morphed recusion thingy of a method that performs the actual comparisons.
For step 2 it gets a lot worse, how the heck do you sort that entire list...? I wish I had some sort of way (hehe, pun intended) to use the `compare()` method for sorting..!
The documentation for `sorted()` actually pointed me towards the cmp_to_key function from functools which took me a while to figure out how to implement, since I'm not used to the whole lamdba thing yet.
In the end I spent a lot of time forgetting that multiplying a value by 0 doesn't do much for increasing the value... But after actually __using my eyes__ I found that error and it seems to work now both for the test input and for the actual puzzle input.

- [- Day 14: Regolith Reservoir -](./14.md)
Fun puzzle! Keep track of falling sand. Step 1 until the first grain of sand falls outside of the rock paths.  
Turns out Step 2 actually only needed an infinite rock floor below the rock paths, and then the rest was almost automatic.

- [- Day 15: Beacon Exclusion Zone -](./15.md)
Big grid. Step 1 was my lunch time exercise today, and was possible to do via "brute force". Step 2 however will need rethinking. There should be a better way. 
So I was storing all the positions, as they were being checked. Which took a few minutes to run for step 1. But then when we had to perform checks on a square of 4 million x 4 million it would not have been practically possible to store that in memory :dizzy_face:, and would have taken a good long while to run through... a couple of days maybe?
So instead of storing everything as a grid, I store only the actual sensors and beacons. And use a method to check if a point on the grid is valid for containing a beacon or not. That took the runtime for step 1 down from roughly 4 minutes to about 30 seconds by tuning the ranges a bit.
Step 2 was a nightmare, and I had to ask for advice - I was pretty close to giving up.  
The main key to solving step 2 (for me) was finding out that the beacon we search for has to be distance+1 from one of a sensor - and be a valid point. :signal_strength:

- [- Day 16: Proboscidea Volcanium -](./16.md)
Evacuate elephants :elephant: from a volcano :volcano:, using pressure release valves building the most pressure possible within a 30 minute time window. Just your typical friday in december eh? :satisfied: Yeah so I gave up on this day... :)

- [- Day 17: Pyroclastic Flow -](./day17.md)
It's Tetris time! :video_game:  
Let's give this a shot then.
Ohkay.. that was surprisingly difficult. I played around with this all day, and was apparently a little bit off all the time for the real input, but everything worked fine for the test input. :confused: I'm still not sure what the problem is that makes up that difference between running with test and real input. 