using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.TwentyNineteen.Day01
{
    class Day1
    {
        
        public void Go()
        {
            /*                         
            Fuel required to launch a given module is based on its mass. Specifically, to find the fuel required for a module, take its mass, divide by three, round down, and subtract 2.

            For example:

            For a mass of 12, divide by 3 and round down to get 4, then subtract 2 to get 2.
            For a mass of 14, dividing by 3 and rounding down still yields 4, so the fuel required is also 2.
            For a mass of 1969, the fuel required is 654.
            For a mass of 100756, the fuel required is 33583.
            The Fuel Counter - Upper needs to know the total fuel requirement.To find it, individually calculate the fuel needed for the mass of each module(your puzzle input), then add together all the fuel values.

            What is the sum of the fuel requirements for all of the modules on your spacecraft ?
            */
            int fuel;
            int sum = 0;
            //int[] Values = {1969};
            var Values = GetValues();
            foreach (var val in Values)
            {
                fuel = fuelForMass(val);
                sum += fuel;
                // calculate extra fuel needed for this fuel
                while (fuel > 0)
                {
                    fuel = fuelForMass(fuel);
                    sum += fuel;
                }
            }
            Console.WriteLine("Sum of fuel: {0} ", sum);
        }
        int fuelForMass(int mass)
        {
            int fuel = 0;
            fuel = mass / 3;
            fuel -= 2;
            if (fuel < 0)
            {
                fuel = 0;
            }
            Console.WriteLine("Mass received: {0}, Fuel calculated: {1}", mass, fuel);
            return fuel;
        }

        int[] GetValues()
        {
            int[] iValues = { 128398, 118177, 139790, 84818, 75859, 139920, 90212, 74975, 120844, 85533, 77851, 127044, 128094, 77724, 81951, 115804, 60506, 65055, 52549, 108749, 92367, 53974, 52896, 66403, 93539, 118392, 78768, 128172, 85643, 109508, 104742, 71305, 84558, 68640, 58328, 58404, 70131, 73745, 149553, 57511, 119045, 90210, 129537, 114869, 113353, 114181, 130737, 134877, 90983, 84361, 62750, 114532, 139233, 139804, 130391, 144731, 84309, 137050, 79866, 121266, 93502, 132060, 109190, 61326, 58826, 129305, 141059, 143017, 56552, 102142, 110604, 136052, 93872, 71951, 72954, 70701, 137381, 76580, 62535, 62666, 126366, 66361, 109076, 126230, 73367, 94459, 126314, 133327, 143771, 50752, 75607, 117606, 142366, 59068, 75574, 149836, 57058, 77622, 83276, 82734 };

            foreach (var val in iValues)
            {
                Console.WriteLine("Value: {0}", val);
            }
            return iValues;
        }
    }
}
