namespace day2
{
    internal class RunnerPart1
    {
        public void Run()
        {
            var inputFile = "input.txt";

            using FileStream fs = new(inputFile, FileMode.Open);
            using StreamReader sr = new(fs);

            var lines = new List<string>();
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine() ?? throw new ArgumentException("bad data");
                lines.Add(line);
            }

            var safeCount = 0;
            for (var i = 0; i < lines.Count(); i++)
            {
                var levels = lines[i].Split(' ').Select(x => Int32.Parse(x)).ToArray();
                var safe = true;
                bool? asc = null;
                for (var n = 1; n < levels.Count(); n++)
                {
                    var diff = levels[n] - levels[n - 1];
                    var thisAsc = diff > 0;

                    if (!asc.HasValue) asc = thisAsc;
                    if (asc != thisAsc)
                    {
                        safe = false;
                        break;
                    }

                    if (levels[n] == levels[n - 1]
                        || Math.Abs(levels[n] - levels[n - 1]) > 3)
                        safe = false;

                    if (!safe) break;
                }

                if (safe) safeCount++;
            }

            Console.WriteLine(safeCount);
            Console.WriteLine("done");
        }
    }
}
