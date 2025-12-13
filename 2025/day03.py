"""Day 3: Lobby"""


def setup(path):
    """
        Parses input into a list of lists containing integers.
        Example: [[9, 8, 7, 6, 5, 4, 3, 2, 1, 1, 1, 1, 1, 1, 1], [8, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9], [2, 3, 4, 2, 3, 4, 2, 3, 4, 2, 3, 4, 2, 7, 8], [8, 1, 8, 1, 8, 1, 9, 1, 1, 1, 1, 2, 1, 1, 1]]
    """
    with open(path, "r") as f:
        input = [[int(x) for x in line.strip()] for line in f.readlines()]
        return input


def solve(data, length):
    """
        Maximize "joltage" by removing numbers until length digits remain, forming the largest possible number.
        Logic:
        Uses a stack (actually a list but used as a stack w pop and append)
        Adds numbers to the stack while going through the sequence of numbers from left to right. (Most significant to least significant)
        If the last added number in the stack is smaller than the current number in the sequence, remove that last number from the stack,
        Until we have removed as many as needed.
    """
    sum = 0
    for numbers in data:
        digits_to_remove = len(numbers) - length
        stack = []

        for current_digit in numbers:
            while stack and digits_to_remove > 0 and stack[-1] < current_digit:
                stack.pop()
                digits_to_remove -= 1
            stack.append(current_digit)

        # If we still have numbers to remove - for example in a sequence with descending order 9,8,7,6,5,4,3,2,1,1,1,1,1,1,1
        # remove the remaining amount of digits from the end.
        if digits_to_remove > 0:
            stack = stack[:-digits_to_remove]

        # join the stack into a string, and convert it into an integer.
        iteration_value = int("".join(str(x) for x in stack))
        sum += iteration_value

    return sum


if __name__ == "__main__":
    data = setup("testinput_day03.dat")
    p1_result = solve(data, 2)
    print("Part 1:", p1_result)
    p2_result = solve(data, 12)
    print("Part 2:", p2_result)
