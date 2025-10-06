# Advent of Code 2023 Day10  

## Part 1  

So I waited a long time before starting this challenge. I got demotivated when reading it on the 10th, and did not pick it up again until today on the 14th. It was not that hard, just traverse the grid from the starting point in all the possible directions (depending on the shape of the tile, and the adjacent tile). And then count the number of steps in the loop, divide that by 2 to get the farthest step.

## Part 2

Wow, I had to google how to google for this. I ended up reading spoilers from the subreddit. And even then I had to google a lot of stuff. I ended up using flood fill to determine what tiles were "inside". I found a few people who had recommended this method.
After almost giving up about 10 times, I finally got something running. I borrowed some ideas for this, the expansion of the map/grid for example.
