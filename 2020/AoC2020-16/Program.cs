using System;
using System.IO;

namespace AdventOfCode.TwentyTwenty.Day16
{
    class Program
    {
        private static string Path = "input.txt";

        //private static string Path = "step2inputsmall.txt";
        
        static void Main(string[] args)
        {
            System.Console.WriteLine("--- Day 16: Ticket Translation ---");
            var myInput = File.ReadAllLines(Path);
            var myTranslator = new TicketTranslation();
            System.Console.WriteLine($"Step 1 Result: {myTranslator.ComputeStep1(myInput)}");
            
            System.Console.WriteLine("DEBUG: Engaging Step 2...");
            System.Console.WriteLine($"DEBUG: Removing invalid NearBy Tickets...");
            System.Console.WriteLine($"DEBUG: Discarded {myTranslator.DiscardInvalidTickets()} faulty tickets. {myTranslator.NearbyTickets.Count} remains.");
            System.Console.WriteLine($"DEBUG: Matching...");
            System.Console.WriteLine($"DEBUG: TicketNumberCount:");
            myTranslator.ShowRawArrayLength();
            //myTranslator.MatchTicketFieldsAgainstTickets();
        }
    }
}
