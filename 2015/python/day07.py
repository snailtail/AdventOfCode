"""
    Day 7: Some Assembly Required
"""

import re


class SmartWires:

    # We need to reimplement this - i have misinterpreted what I was supposed to do.
    # I need to build a complete wiring schema, some of the inputs will be of unknown value.
    # Once I know the value of some input/wire it can be stored in the wires list
    # until then they need to be stored together with their respective commands and parameters in some sort of cache
    # when a wires value is defined it can be updated in the list, and once all the known values are defined for a wire in that cache, it can be computed and moved to the wires list
    # this would probably become recursive
    # since we want to find the value for a, and that is dependent on other wires, we need to look up those that it is dependant on, until we've resolved enough to be able to set a value - 
    # as long as there are still things in the cache, we need to keep going also.
    # so good luck to me.  :D
    

    def __init__(self):
        self.wires = {}

    def __repr__(self):

        return f"SmartWires: {self.generate_printable_wire_schema()}"
    
    def generate_printable_wire_schema(self):
        output = ''
        for key in self.wires:
            output += f"{key}:{self.wires[key]}\n"
        return output
    
    def set_value(self, wire_key: str, wire_value: int):
        value = self.ensure_u16int(wire_value)
        self.wires[wire_key] = value

    def ensure_u16int(self,value):
        u16value = value & 0xFFFF
        return u16value


    def parse_command(self, text: str):
        
        active_command = None
        print(text)
        command = re.search(r"(AND|OR|NOT|LSHIFT|RSHIFT)",text)
        if command:
            active_command = command.groups()[0]
            print(f"{command.groups()=}")

            # depending on the active_command we will attack the input differently:
            if active_command == 'NOT':
                # NOT always comes before the values/keys
                values_search = re.search(r"NOT\s(\w+)\s->\s(\w+)",text)
                if values_search:
                    value_groups = values_search.groups()
                    
                    
                    value = value_groups[0]
                    if value.isalpha():
                        value = int(self.wires[value])
                    else:
                        value = int(value)
                    value = ~value                    
                    
                    target_key = value_groups[1]
                    self.set_value(target_key,value)
            else:
                # the other commands have the same structure.
                # param1 COMMAND param2 -> output_key
                param1 = 0
                param2 = 0
                param_search = re.search(r"([a-z0-9]+)\s(?:AND|OR|LSHIFT|RSHIFT)\s([a-z0-9]+)\s->\s(\w+)",text)
                if param_search:
                    param_groups = param_search.groups()
                    param1 = param_groups[0]
                    if param1.isalpha():
                        # translate key to the corresponding wires value
                        param1 = self.wires[param1]
                    else:
                        param1 = int(param1)
                    param2 = param_groups[1]

                    if param2.isalpha():
                        # translate key to the corresponding wires value
                        param2 = self.wires[param2]
                    else:
                        param2 = int(param2)

                    target_key = param_groups[2]

                    # now we have 2 parameters, param1, and param2. And also the target key for the wire we want to store the result in.
                    # time to do the operation depending on the active_command

                    if active_command == 'AND':
                        self.set_value(target_key, param1 & param2)
                    elif active_command == 'OR':
                        self.set_value(target_key, param1 | param2)
                    elif active_command == 'LSHIFT':
                        self.set_value(target_key, param1 << param2)
                    elif active_command == 'RSHIFT':
                        self.set_value(target_key, param1 >> param2)
                    else:
                        raise NotImplementedError(f"I don't know how we ended up here. {active_command=}")
        elif not command:
            # direct assignment.
            # something -> somewhere
            # something can be a value (int) or a key (string)
            params = re.search(r"(\w+)\s->\s(\w+)", text)
            if params:
                value_groups = params.groups()
                fromvalue=0
                if value_groups[0].isalpha():
                    # key
                    fromvalue = self.wires[value_groups[0]]
                elif value_groups[0].isdigit():
                    # value assignment
                    fromvalue = int(value_groups[0])

                to_key = value_groups[1]

                self.set_value(to_key,fromvalue)
                print(f"Instruction [{text}] direct set wire {to_key} to value {fromvalue}")

                    





def setup(path: str="input_day07.dat"):
    with open(path,'r') as f:
        return [line.strip() for line in f.readlines()]
    
if __name__=="__main__":

    instructions = setup()
    sw = SmartWires()
    print(sw)
    for i in instructions:
        sw.parse_command(i)
    print(sw)