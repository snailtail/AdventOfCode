using System;

namespace AdventOfCode.TwentyFifteen.Day02
{
    public class Package
    {
        public int Length { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public int RibbonLength
        {
            get
            {
                int[] arrLengths= new int[3]{Length,Height,Width};
                Array.Sort(arrLengths);
                var Side1=arrLengths[0];
                var Side2=arrLengths[1];
                return Side1 + Side1 + Side2 + Side2;
            }
        }

        public int BowLength
        {
            get
            {
                return Length * Height * Width;
            }
        }
        public int Area_A
        {
            get{
                return Length * Width;
            }
        }
        public int Area_B
        {
            get{
                return Width * Height;
            }
        }
        public int Area_C
        {
            get{
                return Height * Length;
            }
        }
        public int SurfaceArea
        {
             get
             {
                return (2 * Area_A) + (2 * Area_B) + (2 * Area_C);
             }
             
        }
        public int ExtraArea{
            get{

                //int _extra;
                int[] Areas = new int[3]{Area_A, Area_B, Area_C};
                Array.Sort(Areas);
                /**System.Console.WriteLine($"Areas[0]:{Areas[0]}");
                System.Console.WriteLine($"Areas[1]:{Areas[1]}");
                System.Console.WriteLine($"Areas[2]:{Areas[2]}");**/
                
                /**if((Area_A < Area_B) && (Area_A < Area_C))
                {
                    _extra=Area_A;
                    System.Console.WriteLine($"Area_A: {Area_A}*\tArea_B: {Area_B}\tArea_C: {Area_C}");
                }
                else if((Area_B < Area_A) && (Area_B < Area_C))
                {
                    _extra=Area_B;
                    System.Console.WriteLine($"Area_A: {Area_A}\tArea_B: {Area_B}*\tArea_C: {Area_C}");
                }
                else
                {
                    _extra = Area_C;
                    System.Console.WriteLine($"Area_A: {Area_A}\tArea_B: {Area_B}\tArea_C: {Area_C}*");
                }**/
                return (Areas[0]);
            }
        }
        public int PaperNeeded
        {
            get
            {
                return (SurfaceArea + ExtraArea);
            }
        }

        public Package()
        {
            // empty constructor..
        }

        public Package(int[] Dimensions)
        {
            // l,w,h
            if(Dimensions.Length!=3)
            {
                throw new System.ArgumentException("Number of dimensions must be precisely 3.");
            }
            else
            {
                Length=Dimensions[0];
                Width=Dimensions[1];
                Height=Dimensions[2];
            }
        }
    }
}