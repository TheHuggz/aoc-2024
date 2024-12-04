using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4
{
    internal class RunnerPart1
    {
        public void Run()
        {
            var inputFile = "input.txt";

            using FileStream fs = new(inputFile, FileMode.Open);
            using StreamReader sr = new(fs);

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine() ?? throw new ArgumentException("bad data");
                var lineParts = line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            }

            Console.WriteLine("done");
        }
    }
}
