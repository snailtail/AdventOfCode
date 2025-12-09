def setup(path="testinput_day09.dat"):
    """
    Parses input and returns a list of coordinatex
    Example: [(1,2),(2,3),(0,8)]
           
    """
    input = []
    with open(path, "r") as f:
        for row in f:
            (x, y) = list(map(int, [x for x in row.strip().split(",")]))
            

            input.append((x,y))
    #sorted_points = sorted(input, key=lambda p: p.distance_from_origin)
    #input.sort(key = lambda p: p.distance_from_origin)

    #return sorted_points
    return input

if __name__ == "__main__":
    coordinates = setup("testinput_day09.dat")
    
    print(coordinates)
    for (x,y) in coordinates:
        print(x,y)
