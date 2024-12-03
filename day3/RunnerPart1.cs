using System.Text.RegularExpressions;

namespace day3;

public class RunnerPart1
{
    private const string REGEX_TEMPLATE = "mul\\((?<num1>\\d+),(?<num2>\\d+)\\)";

    public void Run()
    {
        var inputFile = "input.txt";

        using FileStream fs = new(inputFile, FileMode.Open);
        using StreamReader sr = new(fs);

        var sum = 0;

        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine() ?? throw new ArgumentException("bad data");

            var regex = new Regex(REGEX_TEMPLATE);

            foreach(Match x in regex.Matches(line))
            {
                var num1 = Int32.Parse(x.Groups["num1"].Value);
                var num2 = Int32.Parse(x.Groups["num2"].Value);

                sum += (num1* num2);
            }

        }

        Console.WriteLine(sum);
        Console.WriteLine("done");
    }
}