class Intcode:
    Memory=[]
    def __init__(self, program):
        self.Memory = list(map(int,program.split(",")))
    
    def GetPointer(self, pointer):
        return self.Memory[pointer]
    
    def SetPointer(self, pointer, data):
        self.Memory[pointer]=data
    
    def GetMem(self, pos):
        pointer=self.GetPointer(pos)
        return self.Memory[pointer]

    def SetMem(self,pos,data):
        pointer=self.GetPointer(pos)
        self.SetPointer(pointer,data)
        
    def Execute(self, pointer):
        while True:
            OpCode=self.Memory[pointer]
            match OpCode:
                case 99:
                    return
                case 1:
                    sum=self.GetMem(pointer+1) + self.GetMem(pointer+2)
                    self.SetMem(pointer+3,sum)
                    pointer+=4
                case 2:
                    sum=self.GetMem(pointer+1) * self.GetMem(pointer+2)
                    self.SetMem(pointer+3,sum)
                    pointer+=4
        

def main():
    #with open("input_day02.txt") as f:
    with open("input_day02.txt") as f:
        programdata=f.read()
    program=Intcode(programdata.rstrip())
    program.SetPointer(1,12)
    program.SetPointer(2,2)
    program.Execute(0)
    print(f"Step 1: {program.GetPointer(0)}")
    for a in range(0,99):
        for b in range(0,99):
            program=Intcode(programdata.rstrip())
            program.SetPointer(1,a)
            program.SetPointer(2,b)
            program.Execute(0)
            if(program.GetPointer(0)==19690720):
                print(f"Step 2: {(100 * a) + b}")
                break
    
if __name__=="__main__":
    main()