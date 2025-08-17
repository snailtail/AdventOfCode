namespace AoC2017_08
{
    public class Instruction
    {
        public string Register { get; private set; }
        public bool Increase  { get; private set; }
        public int Amount { get; private set; }
        public string CheckRegister  { get; private set; }

        public string CheckString  { get; private set; }
        public int CheckValue  { get; private set; }
        public Instruction(string instructionLine)
        {
            var parts = instructionLine.Split();
            Register = parts[0];
            if(parts[1]=="dec")
            {
                Increase = false;
            }
            else
            {
                Increase = true;
            }
            Amount = parseNegativeString(parts[2]);
            CheckRegister = parts[4];
            CheckString = parts[5];
            CheckValue = parseNegativeString(parts[6]);
        }

        private static int parseNegativeString(string numberString)
        {
            int returnValue = 0;
            if(numberString[0]=='-')
            {
                returnValue = int.Parse(numberString.Substring(1)); // numberString.Length-1));
                returnValue = returnValue * -1;
            }
            else
            {
                returnValue = int.Parse(numberString);
            }
            return returnValue;
        }

        public override string ToString()
        {
            return $"Register: {Register} Increase: {Increase} Amount: {Amount} CheckRegister: {CheckRegister} CheckString: {CheckString} CheckValue: {CheckValue}";
            //return base.ToString();
        }
    }
}
