"""
    Day 6: 
"""

import pprint
import math

def setup(path = "testinput_day06.dat", part2=False):
    """
        For Part 1:
        Parses input and returns a grid filled with numbers or + or * (strings)
        Example: [['123', '328', '51', '64'],
                 ['45', '64', '387', '23'],
                 ['6', '98', '215', '314'],
                 ['*', '+', '*', '+']]

        For Part 2:
        Parses input and returns a grid of characters - including whitespace, but excluding \n
        Example: [['1', '2', '3', ' ', '3', '2', '8', ' ', ' ', '5', '1', ' ', '6', '4', ' '],
                 [' ', '4', '5', ' ', '6', '4', ' ', ' ', '3', '8', '7', ' ', '2', '3', ' '],
                 [' ', ' ', '6', ' ', '9', '8', ' ', ' ', '2', '1', '5', ' ', '3', '1', '4'],
                 ['*', ' ', ' ', ' ', '+', ' ', ' ', ' ', '*', ' ', ' ', ' ', '+', ' ', ' ']]
    """
    with open(path,"r") as f:
        if part2:
            input = [list(row.rstrip("\n")) for row in f.readlines()]
        else:
            input = [[x for x in y.split()] for y in f.read().splitlines()]

    return input

def part1(data):
    """
        For each column in the "grid":
            Go down and collect the numbers in a list.
            When a + or a * is reached, perform calculation on the list and add to total
        Return total
    """
    p1_sum = 0

    width = len(data[0])
    height = len(data)
    
    # for each column
    for c in range(width):
        # go through each line, fetch number or operator
        column_numbers = []
        col_sum = 0
        col_product = 0
        for r in range(height):
            if data[r][c].isalnum():
                #print("Val:", int(data[r][c]))
                column_numbers.append(int(data[r][c]))
            else:
                if data[r][c]=='+':
                    col_sum = sum(column_numbers)
                    p1_sum += col_sum
                elif data[r][c]=='*':
                    col_product = math.prod(column_numbers)
                    p1_sum += col_product
    return p1_sum

def part2(data):
    """
        Starts at the top right in the "grid" of input and walks down, row by row.
        Skipping whitespace, concatenating digits into numbers,
        Adding numbers to a list
        When a + or * is found, calculate sum or product of numbers, empty out lists and stuff and continue with next "group" of numbers
        Returns: Sum of the calculations.
    """
    width = len(data[0])
    height = len(data)
    start_col = width - 1
    p2_sum = 0
    numbers = []
    for current_col in range(start_col,-1,-1): # loop from right to left col-wise
        colnum_as_string = ""
        for row in range(height):
            value = data[row][current_col]
            if value.isdigit():
                colnum_as_string += value
            elif value == '+':
                numbers.append(int(colnum_as_string))
                colnum_as_string=''
                this_sum = sum(numbers)
                p2_sum += this_sum
                numbers = []
            elif value == '*':
                numbers.append(int(colnum_as_string))
                colnum_as_string=''
                this_prod = math.prod(numbers)
                p2_sum += this_prod
                numbers = []

        if colnum_as_string != '':
            #print(colnum_as_string)
            numbers.append(int(colnum_as_string))
    return(p2_sum)

if __name__ == "__main__":
    data = setup("testinput_day06.dat")
    print("Part 1:", part1(data))
    data_p2 = setup("testinput_day06.dat", True)
    print("Part 2:", part2(data_p2))