from collections import deque
from aoc import inpututil as iu
import os


# map is 7 units wide
# rock starts left edge 2 units away from left wall, and bottom three units above the highest rock
# (or the bottom if there are no rocks)
class Tetris:
    def __init__(self) -> None:
        self.rocktops = set()
        self.rocks_stopped=0
        self.highground = 0
        self.tetrismap = [['-','-','-','-','-','-','-'],['.','.','.','.','.','.','.'],['.','.','.','.','.','.','.'],['.','.','.','.','.','.','.']]
        self.shapes = []
        self.moves = []
        self.checkpoints = []
        self.moves_made=0
        #self.load_moves()

    def load_moves(self, TestMode:bool = True):
        
        ## gör om moves till en lista och använd modulo för att loopa runt listan med moves...
        
        data = util.GetContents(file, test=TestMode)
        self.moves = [x.strip() for x in data]
        self.checkpoints = [int(x.rstrip()) for x in util.GetLines('17chk',False)]

    def append_empty_row(self):
        self.tetrismap.append(['.','.','.','.','.','.','.'])

    def play_shape(self, shapenum: int):
        # append top lines if needed
        #print(shapenum, end="")
        shapenum = shapenum % 5
        shape = self.shapes[shapenum]
        while self.highground + (3 + len(shape)) > (len(self.tetrismap)-1):
            self.append_empty_row()
            
        #space_to_top_row = (len(self.tetrismap)-1) - (3 + len(shape))
        #space_to_add = self.highground - space_to_top_row
        #for n in range(space_to_add):
        #    self.append_empty_row()
        
        #draw the sprite
        topY=self.highground + len(shape) + 3 # remember where our top row of the sprite should be
        topX = 2
        for row in range(len(shape)):
            for col in range(len(shape[row])):
                self.tetrismap[topY - row][col+topX] = shape[row][col]
        
        # now we need to move the shape first according to the move, and then down until it touches something
        while True:
            movetomake= self.moves_made % len(self.moves)
            move = self.moves[movetomake]
            self.moves_made += 1
            if move=='>':
                if self.can_move_right(shape,topY, topX):
                    self.move_right(shape,topY,topX)
                    topX += 1
            elif move =='<':
                if self.can_move_left(shape,topY, topX):
                    self.move_left(shape,topY,topX)
                    topX -= 1
            else:
                print(f"Incorrect move input: {move}")
            #move 1 step down if possible
            if self.can_move_down(shape, topY, topX):
                self.move_down(shape, topY, topX)
                topY -=1
            else:
                self.rocktops.add(topY)
                if topY > self.highground:
                    self.highground = topY
                    
                #assert self.highground == self.checkpoints[self.rocks_stopped]
                self.rocks_stopped += 1
                #print(f" : {topY}")
                return False
            

    def move_down(self, shape: list, top_y: int, top_x: int):
        for col in range(len(shape[0])):
            #  för varje rad i shape - baklänges
            for row in range(len(shape)-1,-1,-1):
                if self.tetrismap[top_y-row][top_x+col] == '#':
                    self.tetrismap[top_y-row-1][top_x+col] = '#'
                    self.tetrismap[top_y-row][top_x+col] = '.'

    def can_move_down(self, shape: list, top_y: int, top_x: int):
        if top_y - (len(shape)) - 1 < 0:
            return False
        
        # för varje kolumn i shape:
        for col in range(len(shape[0])):
            #  för varje rad i shape - baklänges
            for row in range(len(shape)-1,-1,-1):
                if shape[row][col] == '#':
                    if self.tetrismap[top_y - row - 1][top_x + col] == '#':
                        return False
                    else:
                        break
                else:
                    continue
        return True
                

    def move_left(self, shape: list, top_y: int, top_x):
        for row in range(len(shape)):
            for col in range(len(shape[row])):
                if self.tetrismap[top_y-row][top_x+col] == '#':
                    self.tetrismap[top_y-row][top_x+col-1] = '#'
                    self.tetrismap[top_y-row][top_x+col] = '.'

    def move_right(self, shape: list, top_y: int, top_x):
        for row in range(len(shape)):
            for col in range(len(shape[row])-1, -1, -1):
                if self.tetrismap[top_y-row][top_x+col] == '#':
                    self.tetrismap[top_y-row][top_x+col+1] = '#'
                    self.tetrismap[top_y-row][top_x+col] = '.'

    def can_move_left(self, shape: list, top_y: int, top_x):
        # check if anything o the left side of the shape blocks it from moving left
        canmove = True
        for row in range(len(shape)):
            for col in range(len(shape[row])):
                if top_x + col - 1 < 0:
                    #touches the left edge
                    return False
                elif shape[row][col]=='#': # this will determine the move for this row.
                    if self.tetrismap[top_y-row][top_x+col-1]=='#':
                        return False
                    else:
                        break
                else:
                    continue
        return True

    def can_move_right(self, shape: list, top_y: int, top_x):
        # check if anything o the right side of the shape blocks it from moving left
        canmove = True
        for row in range(len(shape)):
            for col in range(len(shape[row])-1,-1,-1):
                if len(self.tetrismap[0])-1 < top_x + col +1:
                    # touches the right edge
                    return False
                elif shape[row][col]=='#': # this will determine the move for this row.
                    if self.tetrismap[top_y-row][top_x+col+1]=='#':
                        return False
                    else:
                        break
                else:
                    continue
        return True

    def create_shapes(self):
        self.shapes.append([['#','#','#','#']])
        self.shapes.append([['.','#','.'],['#','#','#'],['.','#','.']])
        self.shapes.append([['.','.','#'],['.','.','#'],['#','#','#']])
        self.shapes.append([['#'],['#'],['#'],['#']])
        self.shapes.append([['#','#'],['#','#']])

    def print_shapes(self):
        for shape in self.shapes:
            for line in shape:
                print(''.join(line))
            print("")

    def print_map(self):
        for n in range(len(self.tetrismap)-1,-1,-1):
            print(''.join(self.tetrismap[n]), end="")
            print(f" {n}")
                

file=os.path.basename(__file__).replace('.py','')
util = iu()


testgame = Tetris()
realgame = Tetris()
testgame.create_shapes()
realgame.create_shapes()
testgame.load_moves(TestMode=True)
realgame.load_moves(TestMode=False)
for n in range(2022):
    testgame.play_shape(n)
    realgame.play_shape(n)
    #game.print_map()


sortresult = sorted(realgame.rocktops,reverse=True)
print(sortresult[5]-1)
