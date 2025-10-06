class PlanckRope():

    def __init__(self):
        pass

    def move(self, cur_position, direction):
        """
            Takes a current position (a tuple of two integers) and a direction (a string) as arguments.
            Returns the new position of the rope's head after moving in the specified direction. 
            The possible directions are "R" for moving to the right, "L" for moving to the left, "U" for moving up, and "D" for moving down
        """
        match direction.upper():
            case "R":
                return (cur_position[0] + 1, cur_position[1])
            case "L":
                return (cur_position[0] - 1, cur_position[1])
            case "U":
                return (cur_position[0], cur_position[1] + 1)
            case "D":
                return (cur_position[0], cur_position[1] - 1)

    def move_knot(self, knot, neighbor):
        """
            Takes a knot (a tuple of two integers representing the knot's position) and a neighbor (a tuple of two integers representing the position of the knot directly adjacent to the knot being moved) as arguments. 
            It returns the new position of the knot after moving it towards its neighbor.
        """
        knot_x, knot_y = knot
        neighbor_x, neighbor_y = neighbor
        new_tail = knot

        tail_needsmove = abs(
            knot_x - neighbor_x) > 1 or abs(knot_y - neighbor_y) > 1

        if not tail_needsmove:
            return knot

        if neighbor_x > knot_x:
            new_tail = self.move(new_tail, "R")
        elif neighbor_x < knot_x:
            new_tail = self.move(new_tail, "L")

        if neighbor_y > knot_y:
            new_tail = self.move(new_tail, "U")
        elif neighbor_y < knot_y:
            new_tail = self.move(new_tail, "D")

        return new_tail

    def count_visited_coordinates(self, moves, tail_length=1):
        """
            Takes a list of moves (a list of tuples, where each tuple contains a direction and a count of how many times to move in that direction) and an optional tail_length parameter (an integer representing the length of the rope's tail) as arguments.
            It simulates the movement of the rope's head and tail according to the specified moves, and returns the number of unique coordinates visited by the rope during the simulation.
        """
        start_coordinate = (0, 0)
        visited_coordinates = set([start_coordinate])

        head = start_coordinate
        tail = [start_coordinate] * tail_length

        for (direction, count) in moves:
            for _ in range(int(count)):
                head = self.move(head, direction)

                prev = head
                # for each knot in the rest of the body/tail, follow the nearest "previous knot"
                for i, knot in enumerate(tail):
                    tail[i] = self.move_knot(knot, prev)
                    prev = tail[i]

                visited_coordinates.add(tail[-1])

        return len(visited_coordinates)
