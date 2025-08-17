namespace AoC2017_16
{
    public static class PermutationPromenade
    {
        /*
            The programs' dance consists of a sequence of dance moves:

            Spin, written sX, makes X programs move from the end to the front, but maintain their order otherwise. 
            (For example, s3 on abcde produces cdeab).
            Exchange, written xA/B, makes the programs at positions A and B swap places.
            Partner, written pA/B, makes the programs named A and B swap places.

            For example, with only five programs standing in a line (abcde), they could do the following dance:

                s1, a spin of size 1: eabcd.
                x3/4, swapping the last two programs: eabdc.
                pe/b, swapping programs e and b: baedc.

            After finishing their dance, the programs end up in order baedc.
        */

        public static string programs = "abcdefghijklmnop";
        public static char[] programCharArray => programs.ToCharArray();

        public static void Spin(int size)
        {
            // basically chop off size characters from the end, and put them in the beginning of the string
            string chop = programs.Substring(programs.Length - size, size);
            programs = chop + programs.Substring(0, programs.Length - size);
        }

        public static void Exchange(int indexA, int indexB)
        {
            var myCharArray = programCharArray;
            char charA = myCharArray[indexA];
            char charB = myCharArray[indexB];
            myCharArray[indexB] = charA;
            myCharArray[indexA] = charB;
            programs = string.Join("", myCharArray);
        }
        public static void Partner(char programA, char programB)
        {
            var myCharArray = programCharArray;
            int indexA = -1;
            int indexB = -1;
            for (int n = 0; n < myCharArray.Length; n++)
            {
                if (myCharArray[n] == programA)
                {
                    indexA = n;
                }
                else if (myCharArray[n] == programB)
                {
                    indexB = n;
                }
            }
            Exchange(indexA, indexB);
        }

        public static void ExecuteInstruction(string Instruction)
        {
            /*

            Spin, written sX, makes X programs move from the end to the front, but maintain their order otherwise. (For example, s3 on abcde produces cdeab).
            Exchange, written xA/B, makes the programs at positions A and B swap places.
            Partner, written pA/B, makes the programs named A and B swap places.

            */

            // First character decides what method to run
            char methodChar = Instruction[0];
            string[] programInformation;
            //if x or p, we need to split the rest on /
            if (methodChar == 'x' || methodChar == 'p')
            {
                programInformation = Instruction.Substring(1, Instruction.Length - 1).Split('/');
                if(methodChar=='x')
                {
                    Exchange(int.Parse(programInformation[0]), int.Parse(programInformation[1]));
                }
                else if(methodChar=='p')
                {
                    Partner(programInformation[0].ToCharArray()[0], programInformation[1].ToCharArray()[0]);
                }
            }
            else if(methodChar=='s')
            {
                int length = int.Parse(Instruction.Substring(1, Instruction.Length - 1));
                Spin(length);
            }
        }

    }
}