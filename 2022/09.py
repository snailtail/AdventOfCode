from rope import PlanckRope

with open("./data/09.dat",'r') as f:
    moves = [m.split() for m in f.readlines()]

rope = PlanckRope()
step1 = rope.count_visited_coordinates(moves)
print(f"Step 1: {step1}")

step2 = rope.count_visited_coordinates(moves, 9)
print(f"Step 2: {step2}")