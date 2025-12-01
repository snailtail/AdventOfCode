"""Day 01: Safe Combination Lock"""

def setup(input_file="testinput_day01.dat"):
    input_data = []
    with open("testinput_day01.dat", "r") as f:
        for line in f:
            direction,distance = line.strip()[0], int(line.strip()[1:])
            input_data.append((direction, distance))
    return input_data




def move(start_position, direction, distance):
    local_dial = start_position
    
    if direction == 'L':
        distance = distance * -1
    
    local_dial += distance

    while local_dial < 0:
        local_dial += 100
        
    while local_dial > 99:
        local_dial -= 100
        
    return (local_dial)


def move_part2(start_position, direction, distance):
    local_dial = start_position

    zero_clicks = 0
    move_direction = 1

    if direction == 'L':
        move_direction = -1
    
    for _ in range(distance):
        local_dial += move_direction
        if local_dial == 0:
            zero_clicks += 1
        elif local_dial == -1:
            local_dial = 99
        elif local_dial == 100:
            local_dial = 0
            zero_clicks += 1
        
    return (local_dial, zero_clicks)

def part1(data):
    dial = 50
    zero_counter = 0
    for direction, distance in data:
        dial = move(dial, direction, distance)
        if dial == 0:
            zero_counter += 1
    print("Part 1:", zero_counter)
    return zero_counter

def part2(data):
    dial = 50
    zero_counter = 0
    for direction, distance in data:
        dial, zeros = move_part2(dial, direction, distance)
        zero_counter += zeros
    print("Part 2:", zero_counter)
    return zero_counter

def main():
    data = setup()
    part1(data)
    part2(data)

if __name__ == "__main__":
    main()