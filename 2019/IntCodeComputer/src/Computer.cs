using System.ComponentModel;
using System.Diagnostics;

namespace intCode;
public enum opCode
{
    ADD = 1,
    MULTIPLY = 2,
    INPUT = 3,
    OUTPUT = 4,
    HALT = 99
}

public class Computer
{


    private int _input;
    public int Input
    {
        get { return _input; }
        set { _input = value; }
    }

    private int _output;
    public int Output
    {
        get { return _output; }
        set { _output = value; }
    }
    
    
    public int Noun
    {
        get
        {
            return this._program[1];
        }
        set
        {
            this._program[1] = value;
        }
    }

    public int Verb
    {
        get
        {
            return this._program[2];
        }
        set
        {
            this._program[2] = value;
        }
    }

    private int[] _program;

    // position in the program []
    private int _programCounter = 0;

    // Constructor
    public int[] Program
    {
        get { return _program; }
        private set { _program = value; }
    }

    public Computer(int[] Program)
    {
        _program = Program;
        _lastError = "";
    }
    private string _lastError;
    public string LastError => _lastError;


    public bool Run(out int result)
    {
        result = int.MinValue;
        while (true)
        {
            if (_programCounter >= _program.Length)
            {
                Console.WriteLine("Out of bounds. Exiting run.");
                result = int.MinValue;
                return false;
            }
            int instruction = _program[_programCounter++];
            (intCode.opCode opCode, bool[] parameterModes) = ExtractOpCode(instruction);
            switch (opCode)
            {
                case opCode.ADD:
                    if (!ADD(parameterModes))
                    {
                        return false;
                    }
                    break;
                case opCode.MULTIPLY:
                    if (!MULTIPLY(parameterModes))
                    {
                        return false;
                    }
                    break;
                case opCode.INPUT:
                    if (!INPUT(parameterModes))
                    {
                        return false;
                    }
                    break;
                case opCode.OUTPUT:
                    if (!OUTPUT(parameterModes))
                    {
                        return false;
                    }
                    break;
                case opCode.HALT:
                    result = _program[0];
                    return true;
                default:
                    throw new NotImplementedException($"opCode {opCode.ToString()} is not implemented");
            }
        }
    }

    private bool ADD(bool[] parameterModes)
    {
        int paramA; 
        int paramB;
        int destination;
        bool[] modes = new bool[]{false,false};
        // We need two parametermodes, they are false by default if not otherwise specified
        for(int i = 0; i < parameterModes.Length && i < 2; i++)
        {
            modes[i]=parameterModes[i];
        }

        if (readValue(_programCounter++, modes[0], out paramA)
                    &&
                    readValue(_programCounter++, modes[1], out paramB)
                    &&
                    readValue(_programCounter++, true, out destination)
                    &&
                    writeDestination(destination, paramA + paramB)
                    )
        {
            return true;
        }
        else
        {
            _lastError = "ADD() => Could not read values, probably out of bounds memory error. Exiting.";
            return false;
        }
    }

    private bool MULTIPLY(bool[] parameterModes)
    {
        int paramA; 
        int paramB;
        int destination;
        bool[] modes = new bool[]{false,false};
        // We need two parametermodes, they are false by default if not otherwise specified1
        // We need two parametermodes, they are false by default if not otherwise specified
        for(int i = 0; i < parameterModes.Length && i < 2; i++)
        {
            modes[i]=parameterModes[i];
        }

        if (readValue(_programCounter++, modes[0], out paramA)
                    &&
                    readValue(_programCounter++, modes[1], out paramB)
                    &&
                    readValue(_programCounter++, true, out destination)
                    &&
                    writeDestination(destination, paramA * paramB)
                    )
        {
            return true;
        }
        else
        {
            _lastError = "MULTIPLY() => Probably out of bounds memory error. Exiting.";
            return false;
        }
    }

    private bool INPUT(bool[] parameterModes)
    {
        int destination;
        if (readValue(_programCounter++, true, out destination)
                    &&
                    writeDestination(destination, this._input)
                    )
        {
            return true;
        }
        else
        {
            _lastError = "INPUT() => Probably out of bounds memory error. Exiting.";
            return false;
        }
    }

    private bool OUTPUT(bool[] parameterModes)
    {
        int value;
        bool mode=false;
        if(parameterModes.Length > 0)
        {
            mode=parameterModes[0];
        }
        if (readValue(_programCounter++, mode, out value))
        {
            this._output=value;
            if(value!=0)
            {
                Console.WriteLine($"OUTPUT: {value}");
                return false;
            }
            return true;
        }
        else
        {
            _lastError = "OUTPUT() => Probably out of bounds memory error. Exiting.";
            return false;
        }
    }



    private bool writeDestination(int destination, int value)
    {
        if (destination >= this._program.Length)
        {
            return false;
        }
        else
        {
            _program[destination] = value;
            return true;
        }
    }

    private bool readValue(int position, bool direct, out int value)
    {
        //if direct is set to true => return the value from this position
        // else return the value from _progarm[_program[position]]
        if (position >= this._program.Length || _program[position] >= this._program.Length)
        {
            value = 0;
            return false;
        }
        value = direct == true ? _program[position] : _program[_program[position]];
        return true;
    }

    private (intCode.opCode, bool[]) ExtractOpCode(int instruction)
    {
        //For example, consider the program 1002,4,3,4,33.
        // The first instruction, 1002,4,3,4, is a multiply instruction 
        // The rightmost two digits of the first value, 02, indicate opcode 2, multiplication. 
        // Then, going right to left, the parameter modes are:
        // 0 (hundreds digit)
        // 1 (thousands digit), and:
        // 0 (ten-thousands digit, not present and therefore zero):
        string baseInstruction = instruction.ToString();
        int opcode;
        if(baseInstruction.Length <=2)
        {
            opcode=int.Parse(baseInstruction);
            return((intCode.opCode)opcode, new bool[]{});
        }

        opcode= int.Parse(baseInstruction[^2..]);
        char[] modeChars = baseInstruction[..^2].ToCharArray();
        bool[] parameterModes = new bool[modeChars.Length];
        for(int i = modeChars.Length-1; i >=0; i--)
        {
            parameterModes[modeChars.Length - 1 - i] = modeChars[i] == '1';// Immediate mode = 1
        }
        return ((intCode.opCode)opcode,parameterModes);
    }

    public (intCode.opCode, bool[]) CheckOpCode(int instruction)
    {
        return this.ExtractOpCode(instruction);
    }
}
