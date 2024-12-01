var runner = new RunnerPart2();
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

public class RunnerPart2
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

        var groupedLeft = leftItems.GroupBy(x => x);
        var groupedRight = rightItems.GroupBy(x => x);

        foreach(var l in groupedLeft)
        {
            var r = groupedRight.Where(g => g.Key == l.Key).FirstOrDefault();

            if(r != null)
            {
                var amt = l.Key * l.Count() * r.Count();
                //Console.WriteLine($"({l.Key}){l.Key} * {l.Count()} * {r?.Count()}={amt}");
                sum += amt;
            }
            else
            {
                //Console.WriteLine($"({l.Key})no match");
            }
        }

        Console.WriteLine(sum);
    }
}
