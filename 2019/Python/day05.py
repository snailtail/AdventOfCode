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
            memdata=str(self.Memory[pointer])
            OpCode=int(memdata[-2:])
            paramscount=len(memdata)-2
            params=list(map(int,[memdata[n] for n in range(paramscount-1,-1,-1)]))
            match OpCode:
                case 99:
                    return
                case 1:
                    value1=0
                    value2=0
                    if params[0]==0:
                        value1=self.GetMem(pointer+1)
                    elif params[0]==1:
                        value1=self.GetPointer(pointer+1)
                    
                    if params[1]==0:
                        value2=self.GetMem(pointer+2)
                    elif params[1]==1:
                        value2=self.GetPointer(pointer+2)
                                        
                    sum=value1+value2
                    self.SetMem(pointer+3,sum)
                    pointer+=4
                case 2:
                    value1=0
                    value2=0
                    
                    if params[0]==0:
                        value1=self.GetMem(pointer+1)
                    elif params[0]==1:
                        value1=self.GetPointer(pointer+1)
                    
                    if params[1]==0:
                        value2=self.GetMem(pointer+2)
                    elif params[1]==1:
                        value2=self.GetPointer(pointer+2)
                    sum=value1*value2
                    self.SetMem(pointer+3,sum)
                    pointer+=4
        

def main():
    #with open("input_day05.txt") as f:
    with open("test_day05.txt") as f:
        programdata=f.read()
    program=Intcode(programdata.rstrip())
    #program.SetPointer(1,12)
    #program.SetPointer(2,2)
    program.Execute(0)
    print(program.Memory)
    print(f"Step 1: {program.GetPointer(0)}")
    """
    for a in range(0,99):
        for b in range(0,99):
            program=Intcode(programdata.rstrip())
            program.SetPointer(1,a)
            program.SetPointer(2,b)
            program.Execute(0)
            if(program.GetPointer(0)==19690720):
                print(f"Step 2: {(100 * a) + b}")
                break
    
    """
if __name__=="__main__":
    main()