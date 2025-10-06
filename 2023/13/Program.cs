var input = File.ReadAllLines($"../data/13.dat");

int Part1 = ParseReflectionPoints(input).Select(x => FindReflectionPoint(x, useSmudge: false)).Sum();
Console.WriteLine($"Part 1: {Part1}");

int Part2 = ParseReflectionPoints(input).Select(x => FindReflectionPoint(x, useSmudge: true)).Sum();
Console.WriteLine($"Part 2: {Part2}");

int FindReflectionPoint(string[] refPoint, bool useSmudge)
{
    var middlePoint = IsHorizontalReflectionPoint();
    if (middlePoint >= 0) return (middlePoint + 1) * 100;

    return IsVerticalReflectionPoint() + 1;

    int IsHorizontalReflectionPoint() =>
        ScanReflectionPoint(refPoint.Length, refPoint[0].Length,
            (int i, int i2) => Enumerable.Range(0, refPoint[0].Length).Count(x => refPoint[i][x] == refPoint[i2][x]));

    int IsVerticalReflectionPoint() =>
        ScanReflectionPoint(refPoint[0].Length, refPoint.Length,
            (i, i2) => refPoint.Count(l => l[i] == l[i2]));

    int ScanReflectionPoint(int imax, int dmax, Func<int, int, int> getSameCount)
    {
        for (var i = 0; i < imax - 1; i++)
            if (IsReflectionPoint(i, imax, dmax, getSameCount))
                return i;
        return -1;
    }

    bool IsReflectionPoint(int i, int imax, int length, Func<int, int, int> getSameCount)
    {
        var smudgedLength = useSmudge ? length - 1 : length;
        var wasSmudged = false;

        for (var i2 = i + 1; ; i--, i2++)
        {
            var sameCount = getSameCount(i, i2);

            if (sameCount != length && sameCount != smudgedLength)
                break;

            if (useSmudge && smudgedLength == sameCount)
            {
                // smudged may be used only once
                if (wasSmudged)
                    return false;

                wasSmudged = true;
            }

            // reached one of the ends?
            if (i == 0 || i2 == imax - 1)
                return !useSmudge || wasSmudged;
        }

        return false;
    }
}

IEnumerable<string[]> ParseReflectionPoints(string[] lines)
{
    var refPoint = new List<string>();

    foreach (var line in lines)
    {
        if (line == "")
        {
            yield return refPoint.ToArray();
            refPoint.Clear();
        }
        else
        {
            refPoint.Add(line);
        }
    }

    if (refPoint.Any())
    {
        yield return refPoint.ToArray();
    }
}
