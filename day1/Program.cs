var runner = new RunnerPart1();
runner.Run();

public class RunnerPart1
{
    public void Run()
    {
        var inputFile = "input.txt";

        using FileStream fs = new(inputFile, FileMode.Open);
        using StreamReader sr = new(fs);

        var sum = 0;

        var leftItems = new List<int>();
        var rightItems = new List<int>();

        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine() ?? throw new ArgumentException("bad data");
            var lineParts = line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            leftItems.Add(int.Parse(lineParts[0]));
            rightItems.Add(int.Parse(lineParts[1]));
        }

        leftItems.Sort();
        rightItems.Sort();

        for (var x = 0; x < leftItems.Count(); x++)
        {
            var amt = Math.Abs(leftItems[x] - rightItems[x]);
            Console.WriteLine($"abs({leftItems[x]} - {rightItems[x]}) = {amt}");
            sum += amt;
        }

        Console.WriteLine(sum);
    }
}
