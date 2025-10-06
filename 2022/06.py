with open('./data/06.dat','r') as f:
    data = f.read().rstrip()


def hasunique(input_string):
    if len(set(input_string)) == len(input_string):
        return True
    else:
        return False

# Step 1
for n in range (len(data)-3):
    if hasunique(data[n:n+4]):
        print(data[n:n+4])
        print(n+4)
        break

# Step 2
for n in range (len(data)-13):
    if hasunique(data[n:n+14]):
        print(data[n:n+14])
        print(n+14)
        break

    
