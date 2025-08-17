using System.Linq;

namespace AdventOfCode.Helpers
{
    /// <summary>
    /// A helper class for Triangles, implements such things as you would expect from Triangles.
    /// 3 sides, the possibility to check if the triangle is possible (from the length of the sides)
    /// And more.
    /// </summary>
    public class Triangle
    {
        public int ASide { get; set; }
        public int BSide { get; set; }
        public int CSide { get; set; }

        /// <summary>
        /// Checks all the implemented rules for a Triangle, and if no rules are violated returns True.
        /// If any rule is violated, returns False.
        /// </summary>
        public bool IsPossible
        {
            get
            {
                // Check if the side measurements are within the rules
                // That the sum of the length of any of the two sides must
                // be bigger than the length of the remaining side

                if (!((ASide + BSide) > CSide))
                {
                    return false;
                }
                else if (!((ASide + CSide) > BSide))
                {
                    return false;
                }
                else if (!((CSide + BSide) > ASide))
                {
                    return false;
                }
                else 
                {
                    return true;
                }
                
            }
        
        }

        public Triangle()
        {
            //
        }
        public Triangle(int aside, int bside, int cside)
        {
            ASide=aside;
            BSide=bside;
            CSide=cside;
        }
    }
}