# create a dictionary to store the orbits
orbits = {}

# read in the map data
with open("input_day06.txt") as f:
    for line in f:
        # split the line on the ")" character to get the objects in orbit
        a, b = line.strip().split(")")
        
        # add the orbit to the dictionary
        orbits[b] = a

# initialize the total number of orbits to 0
total_orbits = 0

# iterate over each object in the dictionary
for obj in orbits:
    # add the number of orbits that this object has to the total count
    # (we will calculate this by starting at the object and following its
    # "orbits" links until we reach the COM object)
    cur = obj
    while cur != "COM":
        cur = orbits[cur]
        total_orbits += 1

# print the total number of orbits
print(total_orbits)



# Step 2
# create a dictionary to store the orbits
orbits = {}

# read in the map data
with open("input_day06.txt") as f:
    for line in f:
        # split the line on the ")" character to get the objects in orbit
        a, b = line.strip().split(")")
        
        # add the orbit to the dictionary
        orbits[b] = a

# initialize the lists of objects that we will traverse
you_path = []
san_path = []

# start at the object that YOU are orbiting and follow its "orbits" links
# until we reach the COM object, adding each object to the list
cur = "YOU"
while cur != "COM":
    cur = orbits[cur]
    you_path.append(cur)

# start at the object that SAN is orbiting and follow its "orbits" links
# until we reach the COM object, adding each object to the list
cur = "SAN"
while cur != "COM":
    cur = orbits[cur]
    san_path.append(cur)

# find the first object that is common to both lists
for obj in you_path:
    if obj in san_path:
        # this is the common object
        common = obj
        break

# the minimum number of orbital transfers required is equal to the number
# of objects in the list from the object that YOU are orbiting to the common
# object, plus the number of objects in the list from the object that SAN is
# orbiting to the common object
min_transfers = you_path.index(common) + san_path.index(common)

# print the minimum number of orbital transfers
print(min_transfers)
