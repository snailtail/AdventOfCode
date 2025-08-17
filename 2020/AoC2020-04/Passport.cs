using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.TwentyTwenty.Day04
{
    class Passport
    {
        public int byr { get; private set; } // Birth Year

        public int iyr { get; private set; } // Issue Year

        public int eyr { get; private set; } // Expiration Year

        public string hgt { get; private set; } // Height

        public string hcl { get; private set; } // Hair Color

        public string ecl { get; private set; } // Eye Color

        public string pid { get; private set; } // Passport ID

        public int cid { get; private set; }    // Country ID

        public bool isvalid { get; private set; }

        
        public bool ParsePassPortString(string passPortData)
        {
            bool returnValue = false;
            bool hasByr = false;
            bool hasIyr = false;
            bool hasEyr = false;
            bool hasHgt = false;
            bool hasHcl = false;
            bool hasEcl = false;
            bool hasPid = false;
            bool hasCid = false;
            var validEyeColors = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            string[] arrPassportData = passPortData.Split('|');
            if(hasCid)
            {
                //;
            }
            foreach (var line in arrPassportData)
            {
                var key = line.Split(':')[0];
                var val = line.Split(':')[1];
                switch (key)
                {
                    case "byr":
                        byr = int.Parse(val);
                        if (byr >= 1920 && byr <= 2002)
                            hasByr = true;
                        else
                            hasByr = false;
                        break;

                    case "iyr":
                        iyr = int.Parse(val);
                        if (iyr >= 2010 && iyr <= 2020)
                            hasIyr = true;
                        else
                            hasIyr = false;
                        break;


                    case "eyr":
                        eyr = int.Parse(val);
                        if (eyr >= 2020 && eyr <= 2030)
                            hasEyr = true;
                        else
                            hasEyr = false;
                        break;

                    case "hgt":
                        hgt = val;
                        if (hgt.Length > 3)
                        {
                            var heightUnit = hgt.Substring(hgt.Length - 2, 2);
                            int heightVal = int.Parse(hgt.Substring(0, hgt.Length - 2));
                            if (heightUnit.ToLower() == "cm" && heightVal >= 150 && heightVal <= 193)
                            {
                                hasHgt = true;
                            }
                            else if (heightUnit.ToLower() == "in" && heightVal >= 59 && heightVal <= 76)
                            {
                                hasHgt = true;
                            }
                            else
                            {
                                hasHgt = false;
                            }
                        }
                        else
                        {
                            hasHgt = false;
                        }
                        break;

                    case "hcl":
                        hcl = val;
                        Regex rgx = new Regex(@"#[A-Za-z0-9]{6}");
                        if (rgx.IsMatch(hcl))
                        {
                            hasHcl = true;
                        }
                        else
                        {
                            hasHcl = false;
                        }
                        break;
                    case "ecl":
                        ecl = val;
                        if (validEyeColors.Contains(ecl))
                            hasEcl = true;
                        else
                            hasEcl = false;
                        break;
                    case "pid":
                        pid = val;
                        if (pid.Length == 9)
                        {
                            bool testval;
                            int testint = 0;
                            testval = int.TryParse(pid, out testint);
                            if (testval == true)
                            {
                                hasPid = true;
                            }
                            else
                            {
                                hasPid = false;
                            }
                            
                        }
                        else
                        {
                            hasPid = false;
                        }
                            
                        break;
                    case "cid":
                        cid = int.Parse(val);
                        hasCid = true;
                        break;

                    default:
                        Console.WriteLine("Unknown key {0}", key);
                        break;
                }

            }
            if (hasByr && hasIyr && hasEyr && hasHgt && hasHcl && hasEcl && hasPid)
            {
                returnValue = true;
                this.isvalid = true;
            }
            return returnValue;


        }

    }
}
