from aoc import inpututil as iu
from collections import deque
import os
import re

class Monkey():
    
    def __init__(self, monkeyinput) -> None:
        input = [l.strip() for l in monkeyinput.split('\n')]
        self.id = input[0].split(' ')[1].replace(':','')
        self.items = deque(list(map(int, input[1].split(':')[1].split(','))))
        self.operation = input[2].split()
        self.testdiv = int(re.findall(r"\d+", input[3])[0])
        self.truerecipient = re.findall(r"\d+", input[4])[0]
        self.falserecipient = re.findall(r"\d+", input[5])[0]
        self.inspections = 0
    
    def do_operation(self, worrylevel, lcm=1):
        value1 = int(self.operation[3].replace('old',str(worrylevel)))
        value2 = int(self.operation[5].replace('old',str(worrylevel)))
        result=0
        operator = self.operation[4].strip()
        self.inspections+=1
        if operator =='+':
            return (value1 + value2) % lcm
        elif operator =='*':
            return (value1 * value2) % lcm
        
        


file=os.path.basename(__file__).replace('.py','')
util = iu()

data = util.GetContents(file, test=False)
#lines = util.GetLines(file, test=True)
#iarr = util.GetIntArray(file, test=True)

def Process(Step2=False):
    monkeys = data.split('\n\n')
    monkeycollection ={}
    LCM = 1
    for monkey in monkeys:
        monkeyobj = Monkey(monkey)
        monkeycollection[monkeyobj.id]=monkeyobj
        LCM *= monkeyobj.testdiv
    

    if Step2:
        roundcount=10000
    else:
        roundcount=20
        
    for round in range(roundcount):
        for id in monkeycollection:
            monkey = monkeycollection[id]
            while monkey.items:
                item = monkey.items.popleft()
                if not Step2:
                    worrylevel = monkey.do_operation(item)
                    worrylevel = int(worrylevel / 3)
                else:
                    worrylevel = monkey.do_operation(item,LCM)
                
                test = worrylevel % monkey.testdiv == 0
                if test:
                    recipient=monkey.truerecipient
                else:
                    recipient = monkey.falserecipient
                monkeycollection[recipient].items.append(worrylevel)

    inspections = []
    for id in monkeycollection:
        inspections.append(monkeycollection[id].inspections)

    inspections.sort(reverse=True)
    return inspections[0] * inspections[1]

print(f"Step 1: {Process(False)}")
print(f"Step 2: {Process(True)}")
print("")



#print(monkeycollection)