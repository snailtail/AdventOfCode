using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode.TwentyTwenty.Day13{
    public class Day13Step2
    {

        /**
            Loopa framåt med första bussens intervall (id't)
            När andra bussen är i rätt position (jämfört med den första, offset beroende på vilken plats i listan)-> multiplicera första bussens intervall med andra bussens intervall.
            Detta är nu ditt nya intervall, loopa framåt i listan tills nästa buss hamnar i rätt offset.
            Multiplicera ditt framräknade intervall med den bussens intervall och loopa fram med det nya intervallet
            Upprepa tills alla bussjävlar är i rätt offset. Kan ta lite tid.
            

        **/
        public Tuple<Decimal, Decimal, Decimal> pgcd(Decimal a, Decimal b)
        {
            Decimal q, r;

            q = Decimal.Truncate(a / b);
            r = a % b;
            if (r == 0)
            {
                return new Tuple<Decimal, Decimal, Decimal>(b, 0, 1);
            }

            var d = pgcd(b, r);
            return new Tuple<Decimal, Decimal, Decimal>(d.Item1, d.Item3, d.Item2 - q * d.Item3);
        }

        public Decimal Normalize(Decimal a, Decimal m)
        {
            return ((a % m) + m) % m;
        }

        public Tuple<Decimal, Decimal> Diophant(Decimal a, Decimal m1, Decimal b, Decimal m2)
        {
            Decimal M2 = m2 * -1;
            Decimal M1 = m1;
            Decimal C = b - a;
            var _pgcd = pgcd(M1, M2);

            Decimal X0 = Decimal.Truncate(C / _pgcd.Item1) * _pgcd.Item2;
            Decimal Y0 = Decimal.Truncate(C / _pgcd.Item1) * _pgcd.Item3;

            Decimal A0 = a + m1 * X0;
            Decimal M0 = m1 * m2;

            A0 = Normalize(A0,M0);

            var t = new Tuple<Decimal, Decimal>(A0, M0);

            return t;
        }

        public Decimal Compute(string data)
        {
            Dictionary<int, int> busTimes = new Dictionary<int, int>();
            var bus = data.Split(',');
            for (int i = 0; i < bus.Length; i++)
            {
                if (bus[i] != "x")
                {
                    busTimes[Int32.Parse(bus[i])] = -i;
                }
            }

            int[] buses = busTimes.Keys.ToArray();
            Tuple<Decimal, Decimal> t = new Tuple<Decimal, Decimal>(busTimes[buses[0]], buses[0]);
            for (int i = 1; i < buses.Length; i++)
            {
                Decimal a0 = t.Item1;
                Decimal m0 = t.Item2;
                Decimal m1 = buses[i];
                Decimal a1 = Normalize(busTimes[buses[i]],m1);
                t = Diophant(a0, m0, a1, m1);

            }

            return t.Item1;
        }

        public string[] Tests = new string[] { "7,13,x,x,59,x,31,19", "17,x,13,19", "67,7,59,61", "67,x,7,59,61", "67,7,x,59,61", "1789,37,47,1889" };
        public long[] resTests = new long[] { 1068781, 3417, 754018, 779210, 1261476, 1202161486 };

    }
}