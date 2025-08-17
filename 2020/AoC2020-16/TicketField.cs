using System.Collections.Generic;

namespace AdventOfCode.TwentyTwenty.Day16
{
    public class TicketField
    {
        public string Name { get; set; }
        public TicketFieldRange Range1 =new TicketFieldRange();
        public TicketFieldRange Range2 = new TicketFieldRange();
        public int MatchedColumn { get; set; } // the column that this TicketField matches full on.

        public TicketField(string ticketString)
        {
            // class: 1-3 or 5-7
            // row: 6-11 or 33-44
            // seat: 13-40 or 45-50
            var _name = ticketString.Split(':')[0];
            var tempRanges=ticketString.Split(':')[1].Split(" or ",System.StringSplitOptions.None);
            var _range1Low=int.Parse(tempRanges[0].Split('-')[0].ToString());
            var _range1High=int.Parse(tempRanges[0].Split('-')[1].ToString());
            var _range2Low=int.Parse(tempRanges[1].Split('-')[0].ToString());
            var _range2High=int.Parse(tempRanges[1].Split('-')[1].ToString());
            Name = _name;
            Range1.Low=_range1Low;
            Range1.High=_range1High;
            Range2.Low=_range2Low;
            Range2.High=_range2High;
            
        }
        public TicketField()
        {
            //
        }
        public bool CheckIntAgainstRanges(int theNumber)
        {
            if((theNumber <= this.Range1.High && theNumber >= this.Range1.Low) || (theNumber <= this.Range2.High && theNumber >= this.Range2.Low))
            {
                //System.Console.Write($"{theNumber} matches {this.Range1.Low}-{this.Range1.High} OR {this.Range2.Low}-{this.Range2.High}");
                return true;
                
            }
            else
            {
                //System.Console.Write($"{theNumber} does not match {this.Range1.Low}-{this.Range1.High} OR {this.Range2.Low}-{this.Range2.High}");
                return false;

            }
        }

        public void MatchAgainstTickets(List<Ticket> theTicketList)
        {
            // loop through the numbers in each column (careful.. they aren't always all the same length...!)
            // if all items in a column are valid for this Range1 or Range2 then this is the column that gets stored in MatchedColumn
            
            
            
            
            //bool bAllMatch;
            var maxCols=theTicketList[0].RawNumberArray.Length;
            var map= new int[maxCols,theTicketList.Count];

            for(int x = 0; x< maxCols;x++)
            {
                //bAllMatch=true;
                for(int y= 0;y< theTicketList.Count;y++)
                {
                    bool ticketNumberColumnMatchesRanges = CheckIntAgainstRanges(theTicketList[y].RawNumberArray[x]);
                    if(ticketNumberColumnMatchesRanges)
                    {
                        map[x,y]=1;
                    }
                    else
                    {
                        map[x,y]=0;
                    }
                }
            }
            
            for(int x=0; x<maxCols; x++)
            {
                var xSum=0;
                for(int y = 0; y< theTicketList.Count;y++)
                {
                    if(map[x,y]==1)
                    {
                        xSum++;
                    }
                    //System.Console.WriteLine($"{x},{y}={map[x,y]}");
                }
                System.Console.WriteLine($"x: {x} xSum: {xSum}");
                if(xSum==theTicketList.Count)
                {
                    System.Console.WriteLine($"Match for a column {x} - Name: {this.Name}");
                }
            }
            
        }

    }
}