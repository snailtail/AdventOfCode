using System;
using System.Linq;
using System.Collections.Generic;

namespace AoC2017_06
{
    public class AoC201706
    {
        public int balanceBlocks(string bankSetup, bool Step2 = false)
        {
            Dictionary<string, int> uniqueBankConfigs = new Dictionary<string, int>();
            int numRedistCycles = 1;
            int[] bankData = bankSetup.Split().Select(s => int.Parse(s)).ToArray();
            int numBanks = bankData.Length;
            try
            {
                string configString = getConfigString(bankData);
                uniqueBankConfigs.Add(configString, numRedistCycles);

                while (true)
                {
                    //First occurence (if more than 1) of the max value will be used.
                    int pos = 0;
                    int amountToDistribute = 0;
                    int maxValue = bankData.Max();
                    for (int n = 0; n < numBanks; n++)
                    {
                        if (bankData[n] == maxValue)
                        {
                            // we found the first occurence.
                            // remember the position
                            pos = n;
                            amountToDistribute = maxValue;
                            bankData[n] = 0;
                            break;
                        }
                    }
                    //now process all the occurences, from pos and forward. -> wrap around to the beginning if needed.
                    #region distribute
                    while (amountToDistribute > 0)
                    {
                        pos += 1;
                        if (pos >= numBanks)
                        {
                            pos -= numBanks;
                        }
                        bankData[pos] += 1;
                        amountToDistribute--;
                    }
                    configString = getConfigString(bankData);
                    uniqueBankConfigs.Add(configString, numRedistCycles);
                    numRedistCycles++;
                    #endregion
                }
            }
            catch (System.Exception)
            {
                if (Step2)
                {
                    var lastSeen = uniqueBankConfigs[getConfigString(bankData)];
                    return numRedistCycles - lastSeen;
                }
                else
                {
                    return numRedistCycles;
                }
            }

            string getConfigString(int[] bankData)
            {
                // Make a string to remember the config by, store it in the Dict.
                // This will raise an exception if the config has been seen already.
                return string.Join(",", bankData.Select(bd => $"{bd}").ToArray());
            }
        }
    }
}
