

class day01:
    
    def __init__(self):
        pass
    
    def get_fuel(self, mass, StepTwo=False):
        fuel=0
        if not StepTwo:
            return int(((mass/3) // 1) - 2)
        else:
            fuel=int(((mass/3) // 1) - 2)
            if fuel <= 0:
                return 0
            else:
                return fuel+self.get_fuel(fuel,True)
    
    def step1(self,masses):
        totalfuel=0
        for mass in masses:
            totalfuel+=self.get_fuel(mass,False)
        
        return totalfuel
    
    def step2(self,masses):
        totalfuel=0
        for mass in masses:
            totalfuel+=self.get_fuel(mass,True)
        
        return totalfuel
    
def main():
    with open("input_day01.txt") as f:
        massdata=list(map(int,f.readlines()))
    
    day = day01()
    print(f"Step 1: {day.step1(massdata)}")
    print(f"Step 2: {day.step2(massdata)}")
    
    
if __name__ == "__main__":
    main()