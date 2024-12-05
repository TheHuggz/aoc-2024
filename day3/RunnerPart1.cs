using System.Text.RegularExpressions;

namespace day3;

public class RunnerPart1
{
    private const string REGEX_TEMPLATE = "do\\(\\)|don\'t\\(\\)|mul\\((?<n1>\\d+),(?<n2>\\d+)\\)";

    public void Run()
    {
        var inputFile = "input.txt";

        using FileStream fs = new(inputFile, FileMode.Open);
        using StreamReader sr = new(fs);

        var sum = 0;
        var doMultiply = true;

        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine() ?? throw new ArgumentException("bad data");

            var regex = new Regex(REGEX_TEMPLATE);

            var matches = regex.Matches(line);

            foreach (Match x in matches)
            {
                if (x.Value.StartsWith("don't"))
                    doMultiply = false;
                else if (x.Value.StartsWith("do"))
                    doMultiply = true;
                else if (x.Value.StartsWith("mul") && doMultiply)
                {
                    int num1, num2;

                    if (Int32.TryParse(x.Groups["n1"].Value, out num1)
                        && Int32.TryParse(x.Groups["n2"].Value, out num2))
                    {
                        Console.WriteLine($"mul({num1},{num2})");
                        sum += (num1 * num2);
                    }
                }
            }

        }

        Console.WriteLine(sum);
        Console.WriteLine("done");
    }
}