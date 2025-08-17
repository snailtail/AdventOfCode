using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2015_08
{
    public class day08
    {
        public int CountChars(char[] orgChars, bool debug = false)
        {
            int counter = 0;
            for (int c = orgChars.Length - 1; c >= 0; c--)
            {
                // hit \"
                if (orgChars[c] == '"' && orgChars[c - 1] == '\\')
                {
                    counter += 1;
                    c--;
                    if (debug)
                        Console.WriteLine("Replaced \\\"" + " (orgChars[c] = {orgChars[c]}");

                    continue;
                }

                // hit \\
                if (orgChars[c] == '\\' && orgChars[c - 1] == '\\')
                {
                    counter += 1;
                    c--;
                    if (debug)
                        Console.WriteLine("Replaced \\" + " (orgChars[c] = {orgChars[c]}");

                    continue;
                }

                // use ascii codes to find \x4f and such.
                if (c >= 3)
                {

                    if (orgChars[c - 3] == '\\' && orgChars[c - 2] == 'x')
                    {
                        //possible hit for hex-code
                        //check the two last characters
                        if ((
                            (orgChars[c - 1] > 47 && orgChars[c - 1] < 58)
                            ||
                            (orgChars[c - 1] > 96 && orgChars[c - 1] < 103)
                            )
                            &&
                            (
                            (orgChars[c] > 47 && orgChars[c] < 58)
                            ||
                            (orgChars[c] > 96 && orgChars[c] < 103)
                            )
                            )
                        {
                            // convert the hex string to a char
                            string hex = new string(new char[] { orgChars[c - 1], orgChars[c] });
                            counter += 1;
                            c -= 3;
                            if (debug)
                                Console.WriteLine($"Replaced \\" + "x" + "NN" + " (orgChars[c] = {orgChars[c]}");

                            continue;
                        }
                    }
                }
                if (debug)
                    Console.WriteLine($"Replaced generic char {orgChars[c]}");

                counter++;
            }
            return counter;
        }


        public (int,int) ParseLine(string Line)
        {
            int stringcode = 0;
            int characters = 0;
            char[] temp = Line.Where(c => !Char.IsWhiteSpace(c)).ToArray();
            stringcode += temp.Length;
            char[] OrgChars = temp[1..(temp.Length - 1)];
            Console.WriteLine("***********");
            int tempChars = CountChars(OrgChars, false);
            characters += tempChars;
            Console.WriteLine($"{Line} = StringCode: {temp.Length}, Characters: {tempChars}");
            return (stringcode, characters);
        }


    }
}
