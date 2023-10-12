using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public static class Program
{
    public static void Main(string[] args)
    {
        string[] searchArray = new string[10000000];
        string matchString = "Will be found";

        for (int i = 0; i < searchArray.Length; i++) 
        {
            searchArray[i] = "Won't be found";
        }

        searchArray[searchArray.Length - 1] = "Will be found";

        var stopWatch = Stopwatch.StartNew();
        int matchIndex = -1;

        for (int i = 0; i <= searchArray.Length; i++) 
        {
            if (searchArray[i] == matchString)
            {
                matchIndex = i;
                break;
            }
        }

        stopWatch.Stop();
        Console.WriteLine("Found via loop at index " + matchIndex + " in " + stopWatch.Elapsed);

        stopWatch.Restart();

        matchIndex = searchArray.Select((r, i) => new { value = r, index = i})
            .Where(t => t.value == matchString)
            .Select(s => s.index).First();
        stopWatch.Stop();

        Console.WriteLine("Found via linq at index " + matchIndex + " in " + stopWatch.Elapsed);
    }
}