using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        string json = File.ReadAllText("input.txt");
        dynamic o = JsonConvert.DeserializeObject(json);

        Console.WriteLine(GetSum(o));
        Console.WriteLine(GetSum(o, "red"));



    }
    private static long GetSum(JObject o, string avoid = null)
    {
        bool shouldAvoid = o.Properties()
            .Select(a => a.Value).OfType<JValue>()
            .Select(v => v.Value).Contains(avoid);
        if (shouldAvoid) return 0;

        var someshit = o.Properties().Sum((dynamic a) => (long)GetSum(a.Value, avoid));
        return (long)someshit;
    }

    private static long GetSum(JArray arr, string avoid)
    {
        return Convert.ToInt64(arr.Sum((dynamic a) => (long)GetSum(a, avoid)));
    }

    private static long GetSum(JValue val, string avoid)
    {
        return val.Type == JTokenType.Integer ? Convert.ToInt64(val.Value) : 0;
    }
}