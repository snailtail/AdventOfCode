using System.Linq;

namespace AoC2017_05
{
    public class AoC201705
    {
        public int ProcessList(string[] jumps, bool Step2=false)
        {
            int[] jumpList = jumps.Select(s => int.Parse(s)).ToArray();
            int currentPosition = 0;
            int currentOffset = 0;
            int jumpTo = 0;
            int jumpCount = 0;
            while (true)
            {
                try
                {
                    currentOffset = jumpList[currentPosition];
                    jumpTo = currentOffset + currentPosition;
                    if(Step2==true && currentOffset>=3)
                    {
                        jumpList[currentPosition]--;
                    }
                    else
                    {
                        jumpList[currentPosition]++;
                    }
                    //make the jump
                    currentPosition = jumpTo;
                    jumpCount++;
                }
                catch (System.Exception)
                {
                    return jumpCount;
                }
            }
        }
    }
}