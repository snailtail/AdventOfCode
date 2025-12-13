using System.Linq;

namespace AdventOfCode.TwentyFifteen.Day02
{
    public class Elf
    {
        public int[] ParsePackageDimensions(string Dimensions)
        {
            int[] returnValue = Dimensions.Split('x').Select(v => int.Parse(v)).ToArray();
            return returnValue;
        }

        public int CalculateWrapping(int[] Dimensions)
        {
            int Amount=0;
            Package myPackage = new Package(Dimensions);
            Amount= myPackage.PaperNeeded;
            return Amount;
        }

        public int Calculate_Bow_And_Ribbon(int[] Dimensions)
        {
            int Amount = 0;
            Package myPackage = new Package(Dimensions);
            Amount = myPackage.BowLength + myPackage.RibbonLength;
            return Amount;
        }

        public int PackageListToSquareFeet(string[] PackageList)
        {
            var sum=0;
            foreach(var line in PackageList)
            {
                sum+=CalculateWrapping(ParsePackageDimensions(line));
            }
            return sum;
        }

        public int PackageListToRibbonLength(string[] PackageList)
        {
            var sum=0;
            foreach(var line in PackageList)
            {
                sum+=Calculate_Bow_And_Ribbon(ParsePackageDimensions(line));
            }
            return sum;

        }
    }
}