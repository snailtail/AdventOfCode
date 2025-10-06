from aoc import inpututil as iu
from advent_of_code_ocr import convert_array_6
class CathodeRayTube():
    """
    A class representing a Cathode Ray Tube.

    This class has the following attributes:
    - cycles: An integer representing the current number of cycles the CRT has completed.
    - X: An integer representing the current X-coordinate of the CRT.
    - sum: An integer representing the current sum of signal strengths.
    - lines: A two-dimensional list of characters representing the current state of the CRT.

    This class has the following methods:
    - __init__: Initializes a new CRT with default values.
    - run: Executes a given instruction on the CRT.
    - noop: Does nothing for one cycle.
    - addV: Adds a given value to the X-coordinate of the CRT for two cycles.
    - check: Checks the current state of the CRT and updates its attributes accordingly.
    - drawsprite: Draws a sprite on the CRT at the current position of the X-coordinate.
    - displayPicture: Displays the current state of the CRT.
    """

    def __init__(self):
        self.cycles = 1
        self.X = 1
        self.sum = 0
        self.lines = [['.' for x in range(40)] for x in range(6)]

    def run(self, instruction):
        """
        Executes a given instruction on the CRT.

        This method takes in a list of strings representing the instruction to be executed on the CRT.
        The instruction can either be 'addx' or 'noop', followed by a value (if 'addx' is used).
        This method updates the attributes of the CRT accordingly.

        Example:
            tube = CathodeRayTube()
            tube.run(['addx', '10'])
        """
        self.check()
        if instruction[0] == 'addx':
            self.addV(int(instruction[1]))
        elif instruction[0] == 'noop':
            self.noop()

    def noop(self):
        """
        Does nothing for one cycle.

        Example:
            tube = CathodeRayTube()
            tube.noop()
        """
        self.cycles += 1

    def addV(self, val):
        """
        Adds a given value to the X-coordinate of the CRT for two cycles.

        This method takes in an integer representing the value to be added to the X-coordinate of the CRT.
        This method increments the `cycles` attribute by 2, adds the given value to the `X` attribute,
        and calls the `check` method in between cycleupdates, to update the state of the CRT.

        Example:
            tube = CathodeRayTube()
            tube.addV(10)
        """
        self.cycles += 1
        self.check()
        self.cycles += 1
        self.X += val

    def check(self):
        """
        Checks the current state of the CRT and updates its attributes accordingly.

        This method checks the current value of the `cycles` attribute and updates the `sum` and `lines` attributes
        of the CRT accordingly. If the value of `cycles` is in the range [20, 60, 100, 140, 180, 220], then the `sum` attribute
        is updated by adding the product of `cycles` and `X` to it. 
        Then a check is made to see which of the lines on the CRT to draw on, an then the `drawsprite` method is called to draw on that line.

        Example:
            tube = CathodeRayTube()
            tube.check()
        """
        if self.cycles in [20, 60, 100, 140, 180, 220]:
            signalstrength = self.cycles * self.X
            self.sum += signalstrength

        line = self.cycles // 40
        self.drawsprite(line)

        if self.cycles == 220:
            print(f"Step 1: {self.sum}")

    def drawsprite(self, line):
        """
        Draws the sprite on the line at the position of (cycles mod 40 -1), 
        if any part of the sprite is located at this pixel.
        """
        currpos = (self.cycles % 40) - 1
        if self.X == currpos or self.X - 1 == currpos or self.X + 1 == currpos:
            self.lines[line][currpos] = 'X'

    def displayPicture(self):
        print(convert_array_6(self.lines, fill_pixel='X', empty_pixel='.'))

util = iu()
commands = util.GetLines('10',False)

tube = CathodeRayTube()

for command in commands:
    command = command.split()
    tube.run(command)

print("Step 2: ", end="")
tube.displayPicture()
