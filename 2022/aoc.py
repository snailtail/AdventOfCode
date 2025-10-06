import re

class inpututil():
    
    def GetLines(self,day, test=False):
        if test:
            filename=f"./data/{day}test.dat"
        else:
            filename=f"./data/{day}.dat"
            
        with open(filename,'r') as f:
            lines = [l.rstrip() for l in f.readlines()]
        
        return lines

    def GetContents(self, day, test=False):
        if test:
            filename=f"./data/{day}test.dat"
        else:
            filename=f"./data/{day}.dat"
            
        with open(filename,'r') as f:
            data = f.read().rstrip()
        
        return data

    def GetCharMap(self, day, test=False):
        if test:
            filename=f"./data/{day}test.dat"
        else:
            filename=f"./data/{day}.dat"
            
        with open(filename,'r') as f:
            data = [[c for c in line.strip()] for line in f.readlines()]
        
        return data

    def GetIntArray(self, day, test=False, splitat=','):
        if test:
            filename=f"./data/{day}test.dat"
        else:
            filename=f"./data/{day}.dat"
        
        with open(filename,'r') as f:
            data = list(map(int, f.read().rstrip().split(splitat)))

        return data

class FourWayMap():
        
        def coordinate(self):
            return f"{self.x}:{self.y}"
        

        def __init__(self, X=0, Y=0):
            self.visitedCoordinates = set()
            self.originCoordinate=""
            self.x = X
            self.y = Y
            self.originCoordinate = f"{self.x}:{self.y}"

        #region move_around

        def MoveUp(self, Steps):
            for i  in range(Steps):
                self.y+=1
                self.visitedCoordinates.add(f"{self.x}:{self.y}")
        
        def MoveDown(self, Steps):
            for i  in range(Steps):
                self.y-=1
                self.visitedCoordinates.add(f"{self.x}:{self.y}")

        def MoveRight(self, Steps):
            for i  in range(Steps):
                self.x+=1
                self.visitedCoordinates.add(f"{self.x}:{self.y}")

        def MoveLeft(self, Steps):
            for i  in range(Steps):
                self.x-=1
                self.visitedCoordinates.add(f"{self.x}:{self.y}")

        #endregion

        #region parse input
        def Move(self, MoveInstruction):
            if type(MoveInstruction)==list:
                moves = MoveInstruction
            else:
                moves = [MoveInstruction]
            
            for move in moves:
                direction = '?'
                steps = 0
                match = re.match(r"(\D+)(\d+)", move.lower())
                if match != None:
                    direction = match[1].rstrip()
                    steps = int(match[2])

                
                if direction in ["n","u","up","north"]:
                    direction = "n"
                elif direction in ["s","d","down","south"]:
                    direction = "s"
                elif direction in ["e","r","east","right"]:
                    direction = "e"
                elif direction in ["w","l","west","left"]:
                    direction = "w"
                
                self.DoMove(direction, steps)

        def DoMove(self, Direction, Steps):
            
                if Direction=="?":
                    print("Unknown Direction...!")
                elif Direction=="n":
                    self.MoveUp(Steps)
                elif Direction=="s":
                    self.MoveDown(Steps)
                elif Direction=="e":
                    self.MoveRight(Steps)
                elif Direction=="w":
                    self.MoveLeft(Steps)
                    
        def CalculateManhattanDistance(self, coord1, coord2="0:0"):
            coordData1 = coord1.split(":")
            coordData2 = coord2.split(":")
            retX = abs(int(coordData1[0]) - int(coordData2[0]))
            retY = abs(int(coordData1[1]) - int(coordData2[1]))
            return retX + retY
        #endregion