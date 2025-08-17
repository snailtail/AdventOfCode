using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.TwentyTwenty.Day16
{

    public class TicketTranslation
    {
        public List<TicketField> TicketFields = new List<TicketField>();
        public Ticket YourTicket;

        public List<Ticket> NearbyTickets = new List<Ticket>();

        #region Step1_Code
        public void ExtractTicketFields(string[] inputData)
        {
            // take a string array, and loop over it until the first blank line then exit.
            // extract all the field data from it until it exits
            bool ticketdata=true;
            int n =0;
            while(ticketdata)
            {
                //System.Console.WriteLine($"Ticket data: {inputData[n]}");
                TicketFields.Add(new TicketField(inputData[n]));
                n++;
                if(inputData[n]==string.Empty)
                {
                    ticketdata=false;
                }
            }
        }

        public void LoadYourTicket(string [] inputData)
        {
            for(int n = 0; n< inputData.Length; n++)
            {
                if(inputData[n].Length > 3 && inputData[n].Substring(0,4).ToLower()=="your")
                {
                    YourTicket= new Ticket(inputData[n+1], TicketFields);
                    break;
                }
            }
        }

        public void LoadNearbyTickets(string [] inputData)
        {
            for(int n = 0; n< inputData.Length; n++)
            {
                if(inputData[n].Length > 3 && inputData[n].Substring(0,4).ToLower()=="near")
                {
                    for(int x = n+1; x<inputData.Length; x++)
                    {
                        NearbyTickets.Add(new Ticket(inputData[x],TicketFields));
                    }
                }
            }
        }

        public int TicketScanningErrorRate()
        {
            int sum=0;
            foreach(var nTick in NearbyTickets)
            {
                foreach(KeyValuePair<int, bool> nNum in nTick.TicketNumbers)
                {
                    if(nNum.Value==false)
                    {
                        sum+= nNum.Key;
                    }
                }
            }
            return sum;
        }

        public int ComputeStep1(string[] myInput)
        {
            ExtractTicketFields(myInput);
            //ListAllTicketFields();
            LoadYourTicket(myInput);
            LoadNearbyTickets(myInput);
            return TicketScanningErrorRate();
        }
            


        public void ListAllTicketFields()
        {
            foreach(var f in TicketFields)
            {
                System.Console.WriteLine($"Field name: {f.Name}\t Range 1: {f.Range1.Low}-{f.Range1.High}\t Range 2: {f.Range2.Low}-{f.Range2.High}");
            }
        }

        public void ShowTicketNumberLength()
        {
            foreach(var nbt in NearbyTickets.Where(l => l.IsValid==true))
            {
                System.Console.WriteLine(nbt.TicketNumbers.Count);
            }
        }

        public void ShowRawArrayLength()
        {
            foreach(var nbt in NearbyTickets.Where(l => l.IsValid==true))
            {
                System.Console.WriteLine(nbt.RawNumberArray.Length);
            }
        }
    #endregion
        
        #region Step2_Code

        public int DiscardInvalidTickets()
        {
            var counter=0;
            for(int n = NearbyTickets.Count-1; n>=0; n--)
            {
                if(NearbyTickets[n].IsValid==false)
                {
                    NearbyTickets.RemoveAt(n);
                    counter++;
                }
            }
            return counter;
        }

        public void MatchTicketFieldsAgainstTickets()
        {
            for(int n=0; n< TicketFields.Count; n++)
            {
                TicketFields[n].MatchAgainstTickets(NearbyTickets);
                System.Console.WriteLine($"{TicketFields[n].Name}:{TicketFields[n].MatchedColumn}");
            }
            
        }
        #endregion
    }
}