import itertools
 
happiness = {}
people = set()
 
data = open('input.txt').read().splitlines()
data = [d.split(' ') for d in data]
 
for d in data:
    #d = d.split()
    person1 = d[0]
    direction = d[2]
    amount = int(d[3])
    person2 = d[10][:-1]
    #print(person1, direction, amount, person2)
    people.add(person1)
    people.add(person2)
    if direction == 'lose':
        happiness[person1+person2] = -amount
    else:
        assert direction == 'gain'
        happiness[person1+person2] = amount
#print(people)
#print(happiness)
 
 
def find_maximum_happiness(people, happiness):
    maximum_happiness = 0
    for arrangement in itertools.permutations(people):
        happiness_gained = 0
        for person1, person2 in zip(arrangement[:-1], arrangement[1:]):
            happiness_gained += happiness[person1 + person2]
            happiness_gained += happiness[person2 + person1]
        # add happiness for first and last pair
        person1 = arrangement[0]
        person2 = arrangement[-1]
        happiness_gained += happiness[person1 + person2]
        happiness_gained += happiness[person2 + person1]
        maximum_happiness = max(maximum_happiness, happiness_gained)
        #print(arrangement, happiness_gained)
    return maximum_happiness
 
print(find_maximum_happiness(people, happiness))
 
# part b
for person in people:
    happiness['Self' + person] = 0
    happiness[person + 'Self'] = 0
people.add('Self')
print(find_maximum_happiness(people, happiness))