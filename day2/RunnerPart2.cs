using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day2
{
    internal class RunnerPart2
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

            Console.WriteLine(lines.Count());

            var safeCount = 0;
            for (var i = 0; i < lines.Count(); i++)
            {
                var reportDelta = -Math.Abs(lines[i][0] - lines[i][4]);
                if (!(reportDelta > 2 && reportDelta < 11)) continue;

                safeCount++;
            }

            Console.WriteLine(safeCount);
            Console.WriteLine("done");
        }

        private bool report_safe(int[] line)
        {
            var safe = true;


            return safe;
        }
    }
}
