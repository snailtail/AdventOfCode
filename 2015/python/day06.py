"""
    Day 6: Probably a Fire Hazard
"""

import re


class Coordinate:
    def __init__(self, x, y):
        # x == column
        # y == row
        self.x = x
        self.y = y

    def __repr__(self):
        return f"Coordinate x:{self.x}, y:{self.y}"



class Rectangle:
    def __init__(self, corner1: Coordinate, corner2: Coordinate):
        self.xmin = min(corner1.x, corner2.x)
        self.xmax = max(corner1.x, corner2.x)
        self.ymin = min(corner1.y, corner2.y)
        self.ymax = max(corner1.y, corner2.y)        

    def get_rectangle_coordinates(self):
        coordinates = []
        for x in range (self.xmin,self.xmax+1):
            for y in range(self.ymin,self.ymax+1):
                coordinates.append(Coordinate(x,y))

        return coordinates

    def __repr__(self):
        return f"Rectangle with corners {self.ymin,self.xmin},{self.ymin,self.xmax},{self.ymax,self.xmin},{self.ymax,self.xmax}"

    def as_tupe(self):
        return (self.x,self.y)
    
    


class LightGrid:
    def __init__(self):
        self.coordinates = [[0 for _ in range(1000)] for _ in range(1000)] # init zeroes to the 1000x1000 grid

    def process_instruction(self, action:str, from_coord: Coordinate, to_coordinate: Coordinate, use_brightness: bool=False):
        rect = Rectangle(from_coord,to_coordinate)
        if not use_brightness:
            for coordinate in rect.get_rectangle_coordinates():
                if action=='toggle':
                    self.toggle_coordinate(coordinate)
                elif action=='on':
                    self.set_coordinate_value(coordinate,1)
                elif action=='off':
                    self.set_coordinate_value(coordinate,0)
                else:
                    raise NotImplementedError(f"This state is not implemented: {action}")
        else:
            for coordinate in rect.get_rectangle_coordinates():
                if action=='toggle':
                    self.increase_coordinate(coordinate,2)
                elif action=='on':
                    self.increase_coordinate(coordinate,1)
                elif action=='off':
                    self.decrease_coordinate(coordinate)
                else:
                    raise NotImplementedError(f"This state is not implemented: {action}")
        
    def toggle_coordinate(self,coordinate: Coordinate):
        if self.coordinates[coordinate.y][coordinate.x] == 0:
            self.coordinates[coordinate.y][coordinate.x] = 1
        else:
            self.coordinates[coordinate.y][coordinate.x] = 0
    
    def increase_coordinate(self,coordinate: Coordinate, value: int=1):
        self.coordinates[coordinate.y][coordinate.x] += value
    
    def decrease_coordinate(self,coordinate: Coordinate):
        self.coordinates[coordinate.y][coordinate.x] -= 1
        if self.coordinates[coordinate.y][coordinate.x] < 0:
            self.coordinates[coordinate.y][coordinate.x] = 0

    def set_coordinate_value(self,coordinate: Coordinate, value: int):
        self.coordinates[coordinate.y][coordinate.x] = value

    def gridsum(self):
        total_sum = 0
        for y in range(1000):
            total_sum += sum(self.coordinates[y])
        return total_sum

        

class Instruction:
    def __init__(self, text: str):
        #matches = re.match(r"turn\s(on|off)\s(\d*,\d*)\sthrough\s(\d*.\d*)", text)
        if "toggle" in text:
            groups = re.match(r"toggle\s(\d*,\d*)\sthrough\s(\d*.\d*)", text).groups()
            self.action = 'toggle'
            c1 = tuple(map(int,groups[0].split(",")))
            self.coordinate1 = Coordinate(c1[0],c1[1])
            
            c2 = tuple(map(int,groups[1].split(",")))
            self.coordinate2 = Coordinate(c2[0],c2[1])
        elif "turn" in text:
            groups = re.match(r"turn\s(on|off)\s(\d*,\d*)\sthrough\s(\d*.\d*)", text).groups()
            self.action = groups[0]
            c1 = tuple(map(int,groups[1].split(",")))
            self.coordinate1 = Coordinate(c1[0],c1[1])
            c2 = tuple(map(int,groups[2].split(",")))
            self.coordinate2 = Coordinate(c2[0],c2[1])

    def __repr__(self):
        return f"Instruction: Action: '{self.action}' for coordinates: {self.coordinate1}, {self.coordinate2}"

def setup(path="input_day06.dat"):
    with open(path,'r') as f:
        return [Instruction(line.strip()) for line in f.readlines()]
    


if __name__=="__main__":
    data = setup()
    p1_lightgrid = LightGrid()
    p2_lightgrid = LightGrid()
    for instr in data:
        p1_lightgrid.process_instruction(instr.action,instr.coordinate1,instr.coordinate2,False)
        p2_lightgrid.process_instruction(instr.action,instr.coordinate1,instr.coordinate2,True)
    p1_result = p1_lightgrid.gridsum()
    print("Part 1:", p1_result)

    p2_result = p2_lightgrid.gridsum()
    print("Part 2:", p2_result)