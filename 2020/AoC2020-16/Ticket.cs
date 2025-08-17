using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.TwentyTwenty.Day16
{
    public class Ticket
    {
        public Dictionary<int, bool> TicketNumbers = new Dictionary<int, bool>();
        public int[] RawNumberArray;
        public bool IsValid 
        { 
            get
            {
                foreach(KeyValuePair<int, bool> kvp in TicketNumbers)
                {
                    if(kvp.Value==false)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public Ticket(string TicketNumberString, List<TicketField> TicketFieldList)
        {
            var tempArray=TicketNumberString.Split(',').Select(v => int.Parse(v)).ToArray();
            RawNumberArray=tempArray;
            for(int n = 0; n < tempArray.Length; n++)
            {
                
                var thisNumber=tempArray[n];
                if(!TicketNumbers.ContainsKey(thisNumber)){
                    var bFoundMatch=false;
                    foreach(var _ticketField in TicketFieldList)
                    {
                        if((thisNumber <= _ticketField.Range1.High && thisNumber >= _ticketField.Range1.Low) || (thisNumber <= _ticketField.Range2.High && thisNumber >= _ticketField.Range2.Low))
                        {
                            bFoundMatch=true;
                            break;
                        }
                    }
                    TicketNumbers.Add(tempArray[n], bFoundMatch);
                }
            }
        }
    }
}