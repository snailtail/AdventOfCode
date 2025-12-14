"""
    Day 3: Perfectly Spherical Houses in a Vacuum
"""
class Santa:
    Id = 0

    def __init__(self,x:int=0,y:int=0):
        self.x = x
        self.y = y
        self.visited = set()
        self.visit(self.y,self.x)
        self.id = Santa.Id+1
        Santa.Id += 1
    
    def visit(self,y,x):
        self.visited.add((y,x))

    def move_one_step(self,char: str) -> None:
        if char == '^':
            self.y -= 1
        elif char == "v":
            self.y += 1
        elif char == "<":
            self.x -= 1
        elif char == '>':
            self.x += 1
        self.visit(self.y,self.x)
    
    def move_multiple_steps(self, steps: str) -> None:
        for step in steps:
            self.move_one_step(step)


    def __repr__(self):
        return f"I'm Santa with Id: {self.id} and i've visited these houses: {self.visited}"

def setup(path="input_day03.dat"):
    with open(path,'r') as f:
        instructions = f.read().strip()
        return instructions

if __name__ == "__main__":
    instructions = setup()
    p1_santa = Santa()
    p1_santa.move_multiple_steps(instructions)
    p1_number_of_houses = len(p1_santa.visited)
    print("Part 1:",p1_number_of_houses)

    # part 2 - two santas:
    # just make a list of santas, and iterate over them taking turns to process each instruction.
    santas = [Santa(),Santa()]
    for i in range(len(instructions)):
        santa_index = i % 2 # we only have two santas so we'll flip between index 0 and index 1 here.
        santas[santa_index].move_one_step(instructions[i])

    p2_houses_visited = set()
    for i in range(len(santas)):
        p2_houses_visited = p2_houses_visited.union(santas[i].visited)
    print("Part 2:", len(p2_houses_visited))