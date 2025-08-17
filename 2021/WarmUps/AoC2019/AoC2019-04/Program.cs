namespace AoC2019
{
    class day04
    {
        public static void Main(string[] args)
        {
            int counter = 0;
            string input = File.ReadAllText("input.txt");
            string lownum = input.Split("-")[0];
            int highnum = int.Parse(input.Split("-")[1]);
            Console.WriteLine("Hejsan");
            Number number = new Number(lownum);
            while(number.AsNumber <= highnum)
            {
                if(number.IsValid)
                {
                    counter++;
                }
                number.Increase();
            }
            Console.WriteLine(counter);
        }
    }

    public class Number
    {
        public string AsText
        {
            get;
            set;
        }
        public int AsNumber
        {
            get
            {
                return int.Parse(AsText);
            }
        }

        public bool IsValid
        {
            get
            {
                if (this.hasAdjacentTwin() && this.noDecreasing())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Increase()
        {
            int newvalue = this.AsNumber + 1;
            this.AsText = newvalue.ToString();
        }
        public Number(string NumberAsString)
        {
            AsText = NumberAsString;
        }
        public bool hasAdjacentTwin()
        {
            for (int n = 1; n < AsText.Length; n++)
            {
                if (AsText[n] == AsText[n - 1])
                {
                    return true;
                }
            }
            return false;
        }

        public bool noDecreasing()
        {
            for (int n = 1; n < AsText.Length; n++)
            {
                if (int.Parse(AsText[n].ToString()) < int.Parse(AsText[n - 1].ToString()))
                {
                    return false;
                }
            }
            return true;
        }


    }
}