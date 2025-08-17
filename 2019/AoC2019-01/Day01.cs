public class Day01
{
    /// <summary>
    /// Calculates fuel needed for a specific mass.
    /// </summary>
    /// <param name="mass">An integer representing the mass</param>
    /// <returns>an integer representing the amount of fuel needed for the mass</returns>
    public static int fuelForMass(int mass)
    {
        int result = mass / 3 - 2;
        return result;
    }

    /// <summary>
    /// Calculates fuel needed for fuel. Each amount of positive fuel also requres fuel to transport, so recursion is used to calculate fuel until we reach 0 or negative amount of needed fuel
    /// </summary>
    /// <param name="fuel">The initial amount (eg mass) of fuel to calculate fuel requrements for</param>
    /// <returns>A sum of the amount of fuel needed to transport the initial amount of fuel and all the recursive extra fuel needed to transport each new amount of fuel</returns>
    public static int fuelForFuel(int fuel)
    {
        int fuelFuel = fuel / 3 - 2;
        if(fuelFuel <=0)
        {
            return 0;
        }
        
        return fuelFuel + fuelForFuel(fuelFuel);
    }
}