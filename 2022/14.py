from collections import defaultdict
import time
from aoc import inpututil as iu
import os

class Cavesystem:
    def __init__(self, rockpointdata: list) -> None:
        self.points=defaultdict(lambda: '.')
        for line in rockpointdata:
            # Get the different points for the paths of rock
            self.addpath(line.split(' -> '))
        self.getmaprange()
        self.sandrested=0

    
    def addpath(self, points: list):
        lastx, lasty = -1, -1
        for i, point in enumerate(points):
            px, py = map(int, point.split(','))
            if lastx == -1:
                lastx = px
            if lasty == -1:
                lasty = py
            for x in range(min(lastx,px), max(lastx,px) + 1):
                for y in range(min(lasty,py), max(lasty,py) + 1):
                    self.points[(x,y)] = '#'
            lastx = px
            lasty = py
    
    def addsand(self, startingpoint: tuple = (500,0), step2=False):
        x,y = startingpoint
        falling=True
        curpoint = startingpoint
        self.points[curpoint] = "+"
        while(falling):
            x,y = curpoint
            if step2:
                
                self.points[x,self.maxY+2]='#'
                self.points[x-1,self.maxY+2]='#'
                self.points[x+1,self.maxY+2]='#'
                
                if x - 1 < self.minX:
                    self.minX = x-1
                if x > self.maxX:
                    self.maxX = x + 1
            directions = {
                "s":(x,y+1),
                "sw":(x-1,y+1),
                "se":(x+1, y+1)
            }
            moved=False
            for dir in directions:
                if self.points[directions[dir]] == ".":
                    self.points[directions[dir]] = "+"
                    self.points[curpoint] = "."
                    curpoint=directions[dir]
                    #self.printmap(step2)
                    #print("-"*10)
                    moved = True
                    break
                # no direction was possible to move in
            falling = moved
            x,y = curpoint
            
            # Check if we're outside the map area
            if not step2 and (x < self.minX or x > self.maxX or y > self.maxY):
                return False
        self.points[curpoint] = "o"
        self.sandrested+=1
        if step2 and curpoint==(500,0):
            return False
        #self.printmap(step2)
        #print("-"*10)
        return True
            
    def printmap(self, step2=False):
        if step2:
            rowrange=self.maxY+3
        else:
            rowrange=self.maxY+1
            
        for y in range(0, rowrange):
            line=""
            for x in range(self.minX,self.maxX+1):
                p=(x,y)
                line += self.points[p]
            print(line)
        time.sleep(0.1)

    def getmaprange(self):
        coords = list(self.points.keys())
        minx = 10000000
        miny = 10000000
        maxx = 0
        maxy = 0
        for coord in coords:
            (x,y) = coord
            if x < minx:
                minx = x
            if x > maxx:
                maxx = x
            if y < miny:
                miny = y
            if y > maxy:
                maxy = y
        
        self.minX = minx
        self.minY = miny
        self.maxX = maxx
        self.maxY = maxy
            

file=os.path.basename(__file__).replace('.py','')
util = iu()

lines = util.GetLines(file, test=False)
cave = Cavesystem(lines)
cave2 = Cavesystem(lines)

while(cave.addsand(step2=False)):
    pass

print(f"Step 1: {cave.sandrested}")

while(cave2.addsand(step2=True)):
    pass
#cave2.printmap()

print(f"Step 2: {cave2.sandrested}")