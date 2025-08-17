using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.TwentyTwenty.Day06
{
    public class Group
    {
        public Dictionary<char, int> Answers = new Dictionary<char, int>();
        public int MemberCount { get; set; }

        public int UniqueAnswersStep1
        {
            get
            {
                return Answers.Count;
            }
        }

        public int UnanimousAnswersStep2
        {
            get
            {
                var tmpSum = 0;
                foreach (KeyValuePair<char, int> entry in Answers)
                {
                    if (entry.Value == this.MemberCount)
                        tmpSum++;
                }
                return tmpSum;
            }
        }


        public void ProcessGroupString(string GroupString)
        {
            var tmpArr = GroupString.Split('|');
            this.MemberCount = tmpArr.Length;
            foreach (var member in tmpArr)
            {
                for (int n = 0; n <= member.Length - 1; n++)
                {
                    if (this.Answers.ContainsKey(member[n]))
                    {
                        this.Answers[member[n]] = this.Answers[member[n]] + 1;
                    }
                    else
                    {
                        this.Answers.Add(member[n], 1);
                    }
                }
            }
        }

    }
}
