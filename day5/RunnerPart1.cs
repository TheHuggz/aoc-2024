using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day5;
public class RunnerPart1
{
    public void Run()
    {
        var inputFile = "input.txt";

        using FileStream fs = new(inputFile, FileMode.Open);
        using StreamReader sr = new(fs);

        Dictionary<int, List<int>> afterList = new Dictionary<int, List<int>>();
        Dictionary<int, List<int>> beforeList = new Dictionary<int, List<int>>();
        var orgPhase = true;
        var sum = 0;

        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine() ?? throw new ArgumentException("bad data");

            if (string.IsNullOrWhiteSpace(line))
            {
                orgPhase = false;
                continue;
            }

            if(orgPhase)
            {
                var lineParts = 
                    line.Split("|", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToList();

                if(!afterList.ContainsKey(lineParts[0]))
                    afterList.Add(lineParts[0], new List<int>());

                afterList[lineParts[0]].Add(lineParts[1]);

                if (!beforeList.ContainsKey(lineParts[1]))
                    beforeList.Add(lineParts[1], new List<int>());

                beforeList[lineParts[1]].Add(lineParts[1]);
            }
            else
            {
                var lineParts = 
                    line.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToList();

                var isGood = true;
                for(var x = 1; x < lineParts.Count; x++)
                {
                    if (afterList.ContainsKey(lineParts[x - 1]))
                    {
                        if (!afterList[lineParts[x - 1]].Contains(lineParts[x]))
                        {
                            isGood = false;
                            break;
                        }
                    }
                    else if (beforeList.ContainsKey(lineParts[x]))
                    {
                        isGood = false;
                        break;
                    }

                }

                if(isGood)
                {
                    var thisNum = lineParts[(lineParts.Count - 1) / 2];
                    Console.WriteLine(thisNum);
                    sum += thisNum;
                }
            }
        }

        Console.WriteLine(sum);
        Console.WriteLine("done");
    }
}

