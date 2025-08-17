using System;
using System.Collections.Generic;
using System.IO;
using AdventOfCode.Helpers;
namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Triangle> myTriangles = new List<Triangle>();
            var inputData=File.ReadAllLines("input.txt");

            Console.WriteLine("*** Advent Of Code 2016 ***");
            Console.WriteLine("--- Day 3: Squares With Three Sides ---");
            
            
            foreach(var line in inputData)
            {
                var ASide= ExtractCol(1,line);
                var BSide = ExtractCol(2,line);
                var CSide = ExtractCol(3,line);
                var myTriangle = new Triangle(ASide, BSide, CSide);
                myTriangles.Add(myTriangle);
            } 
            int counter=0;
            foreach(var tri in myTriangles)
            {
                if(tri.IsPossible)
                {
                    counter++;
                }
            }
            
            System.Console.WriteLine($"Step 1 result: {counter}");

            // Get ready for Step 2:
            myTriangles.Clear();
            counter=0;
            for(int n = 0; n<=inputData.Length-3; n=n+3)
            {
                for(int col=1; col<=3; col++)
                {
                    var ASide=ExtractCol(col,inputData[n]);
                    var BSide=ExtractCol(col,inputData[n+1]);
                    var CSide=ExtractCol(col,inputData[n+2]);
                    var myTriangle = new Triangle(ASide, BSide, CSide);
                    myTriangles.Add(myTriangle);
                }
            }

            
            foreach(var tri in myTriangles)
            {
                if(tri.IsPossible)
                {
                    counter++;
                }
            }

            System.Console.WriteLine($"Step 2 result: {counter}");
                        
        }

        private static int ExtractCol(int columnNumber, string inputData)
        {
            return int.Parse(inputData.Substring(((columnNumber-1)*5),5).Trim());
        }
    }
}
