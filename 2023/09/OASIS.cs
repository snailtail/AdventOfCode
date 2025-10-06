// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Contracts;

public class OASIS
{
    public List<int[]> HistoryReadings = new();
    /// <summary>
    /// Extrapolates the next row from a sequence of history values
    /// </summary>
    /// <param name="row">the sequence values to extrapolate from</param>
    /// <returns>an integer array with the extrapolated values</returns>

    public OASIS(string[] input)
    {
        // 0 3 6 9 12 15
        // 1 3 6 10 15 21
        // 10 13 16 21 30 45
        foreach (var row in input)
        {
            int[] values = row.Split(" ").Select(v => int.Parse(v)).ToArray();
            HistoryReadings.Add(values);
        }
    }

    /// <summary>
    /// Supporting method, takes in a row of history value sequences and extrapolates the next row.
    /// </summary>
    /// <param name="row"></param>
    /// <returns></returns>
    public int[] extrapolateNextRow(int[] row)
    {
        int[] newrow = new int[row.Length - 1];
        for (int x = 0; x < row.Length - 1; x++)
        {
            newrow[x] = row[x + 1] - row[x];
        }
        return newrow;
    }

    /// <summary>
    /// Takes in a sequence or "row" of historydata, and extrapolates the next value in the sequence.
    /// </summary>
    /// <param name="historyData">the array of integers representing the history sequence</param>
    /// <returns>an integer representing the next value in the sequence</returns>
    public int extrapolateNextValue(int[] historyData, bool step2=false)
    {
        List<int[]> extrapoList = new();
        extrapoList.Add(historyData);
        List<int> newValues = new(); // holds the added value for each row, also the computed/extrapolated rows
        bool rowIsAllZeroes = historyData.All(v => v == 0);
        int listIndex = 0;
        while (!rowIsAllZeroes)
        {
            int[] newrow = extrapolateNextRow(extrapoList[listIndex]);
            extrapoList.Add(newrow);
            rowIsAllZeroes = newrow.All(v => v == 0);
            listIndex++;
        }

        // go backwards and calculate
        //if all = 0 - newvalue = 0
        //else newvalue= lastvalueinrow + previous newvalue
        int newvalue = 0;
        int prevnewvalue = 0;
        for (int i = extrapoList.Count - 2; i >= 0; i--)
        {
            if(step2)
            {
                newvalue = extrapoList[i].First() - prevnewvalue;
            }
            else
            {
                newvalue = prevnewvalue + extrapoList[i].Last();
            }
            prevnewvalue = newvalue;
        }
        return newvalue;
    }

    public int SumOfExtrapolatedValuesPart1
    {
        get
        {
            int sum = 0;
            foreach (var h in HistoryReadings)
            {
                int hResult = extrapolateNextValue(h);
                sum += hResult;
            }
            return sum;

        }
    }

    public int SumOfExtrapolatedValuesPart2
    {
        get
        {
            int sum = 0;
            foreach (var h in HistoryReadings)
            {
                int hResult = extrapolateNextValue(h,true);
                sum += hResult;
            }
            return sum;

        }
    }
}