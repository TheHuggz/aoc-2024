using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4
{
    internal class RunnerPart2
    {
        public void Run()
        {
            // notes for later.  Simlar to part 1, but index the As and look on either side for S and M

            var inputFile = "input.txt";

            using FileStream fs = new(inputFile, FileMode.Open);
            using StreamReader sr = new(fs);

            var lines = new List<string>();
            var startPoints = new List<(int row, int col)>();

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine() ?? throw new ArgumentException("bad data");

                lines.Add(line);
            }

            var sum = 0;

            //index the first characters
            for (var r = 1; r < lines.Count() - 1; r++)
            {
                for (var c = 1; c < lines[r].Length - 1; c++)
                {
                    if (lines[r][c] == 'A')
                    {
                        var tlbr = "MS";
                        var topPoint = (row: r - 1, col: c - 1);
                        var botPoint = (row: r + 1, col: c + 1);

                        if (tlbr.Contains(lines[topPoint.row][topPoint.col]))
                            tlbr = tlbr.Replace(lines[topPoint.row][topPoint.col], '.');

                        if (tlbr.Contains(lines[botPoint.row][botPoint.col]))
                            tlbr = tlbr.Replace(lines[botPoint.row][botPoint.col], '.');
                         
                        var trbl = "MS";
                        topPoint = (row: r - 1, col: c + 1);
                        botPoint = (row: r + 1, col: c - 1);

                        if (trbl.Contains(lines[topPoint.row][topPoint.col]))
                            trbl = trbl.Replace(lines[topPoint.row][topPoint.col], '.');

                        if (trbl.Contains(lines[botPoint.row][botPoint.col]))
                            trbl = trbl.Replace(lines[botPoint.row][botPoint.col], '.');

                        if (trbl == ".." && tlbr == "..") sum++;
                    }
                }
            }

            Console.WriteLine(sum);



        }
    }
}
