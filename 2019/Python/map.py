import re
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
                    
        def CalculateManhattanDistance(self, coord):
            coordData = coord.split(":")
            retX = abs(int(coordData[0]))
            retY = abs(int(coordData[1]))
            return retX + retY
        #end