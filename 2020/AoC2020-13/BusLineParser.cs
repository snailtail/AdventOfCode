using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.TwentyTwenty.Day13
{
    public class BusLineParser
    {

        public ulong[] BusLines;
        public ulong earliestDepartureTime;

        public BusLineParser(string BuslineData)
        {
            var arrBusLineData = BuslineData.Split(',').Where(row => !(row == "x")).ToArray();
            ulong[] arrBusLineInt = new ulong[arrBusLineData.Length];
            
            //Array.Sort(arrBusLineData);

            for(int n = 0; n< arrBusLineData.Length;n++)
            {
                arrBusLineInt[n] = ulong.Parse(arrBusLineData[n]);
            }
            Array.Sort(arrBusLineInt);
            foreach(var entry in arrBusLineInt)
            {
                //Console.WriteLine(entry);
            }
            BusLines = arrBusLineInt;
        }

        public ulong Step1ClosestDeparture()
        {
            System.Console.WriteLine("RAN!");
            var foundTimeStamp = ulong.MaxValue;
            ulong TimeStamp=earliestDepartureTime;
            // init departure time array.
            ulong[] departureTime = new ulong[BusLines.Length];
            for(int x = 0; x< departureTime.Length; x++)
            {
                departureTime[x] = 0;
            }

            //when all values in array are higher than timestamp, we can pers
            while (CheckAllHigherOrEqual(departureTime, TimeStamp) == false)
            {
                for (int n = 0; n < BusLines.Length; n++)
                {
                    if (departureTime[n] <= TimeStamp)
                    {
                        // add another round of timestampentity to each BusLines departureTime
                        departureTime[n] += BusLines[n];
                    }
                    
                }
            }

            // ok, now we should have an array with departure times, unsorted. If we sort it, the 0:th one should be the lowest
            //Console.WriteLine($"List of found departure times higher than or equal to the TimeStamp {TimeStamp}");


            var lowestIndex = ulong.MaxValue;
            
            for(int n = 0; n < departureTime.Length; n++)
            {
                //Console.WriteLine($"Departure time #{n}: {departureTime[n]}");
                if(departureTime[n]<foundTimeStamp)
                {
                    foundTimeStamp = departureTime[n];
                    lowestIndex = (ulong)n;
                }
            }


            var thebusLine = BusLines[lowestIndex];
            var result = thebusLine * (departureTime[lowestIndex] - TimeStamp);
            //Console.WriteLine($"Lowest DepartureTime found: {departureTime[lowestIndex]} (index: {lowestIndex}), for busline: {thebusLine}");
            //foundTimeStamp = departureTime[n];
            return result;
        }

        public bool CheckAllHigherOrEqual(ulong[] theArray, ulong theValue)
        {
            bool _response = true;
            //check if all values in theArray are >= theValue;
            foreach(var check in theArray)
            {
                if(check< theValue)
                {
                    _response = false;
                    break;
                }
            }
            return _response;

        }
        
    }
}
