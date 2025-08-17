

class Password:
    
    Passwordstring=""
    ValidRange=[]
    def __init__(self,passwordstring,validrange):
        self.Passwordstring=passwordstring
        self.ValidRange=validrange

    def IsValid(self, StepTwo=False):
        pairfound=False
        pwd=self.Passwordstring
        pwdlength=len(pwd)
        if pwdlength != 6:
            return False
        
        if int(pwd) > self.ValidRange[1]:
            return False
        
        if int(pwd) < self.ValidRange[0]:
            return False
       
        # No decreasing numbers
        for idx in range(pwdlength-1):
            if int(pwd[idx+1])<int(pwd[idx]):
                return False
        
        # check for a pair
        for idx in range(pwdlength-1):
            if pwd[idx+1]==pwd[idx]:
                if StepTwo:
                    if not pwd[idx]*3 in pwd:
                        pairfound=True
                else:
                    pairfound=True
                    break
        if pairfound==False:
            return False
        
        
        return True        

def main():
    with open("input_day04.txt") as f:
        validrange=list((map(int,f.read().split("-"))))
        #validrange=[112233,112233]
        testnumber=validrange[0]
        sumvalid=0
        sumvalid_step2=0
        while testnumber <= validrange[1]:
            if Password(str(testnumber),validrange).IsValid(StepTwo=False) == True:
                sumvalid+=1
            if Password(str(testnumber),validrange).IsValid(StepTwo=True) == True:
                sumvalid_step2+=1
                
            testnumber+=1
        print(f"Step 1: {sumvalid}")
        print(f"Step 2: {sumvalid_step2}")

    
if __name__=="__main__":
    main()    