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
            var word = "XMAS";

            using FileStream fs = new(inputFile, FileMode.Open);
            using StreamReader sr = new(fs);

            var lines = new List<string>();
            var startPoints = new List<(int row, int col)>();

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine() ?? throw new ArgumentException("bad data");

                lines.Add(line);
            }

            //index the first characters
            for (var r = 0; r < lines.Count(); r++)
            {
                for (var c = 0; c < lines[r].Length; c++)
                {
                    if (lines[r][c] == word[0])
                    {
                        startPoints.Add((r, c));
                    }
                }
            }

            var sum = 0;
            foreach (var point in startPoints)
            {
                // we know first character already matches so start at 1
                var pointDir = new Dictionary<string, (int row, int col)>
                    {
                        { "upPoint", default },
                        { "dnPoint", default },
                        { "lePoint", default },
                        { "riPoint", default },
                        { "ulPoint", default },
                        { "urPoint", default },
                        { "dlPoint", default },
                        { "drPoint", default }
                    };

                for (var i = 1; i < word.Length; i++)
                {
                    if(pointDir.ContainsKey("upPoint")) pointDir["upPoint"] = (row: point.row - i, col: point.col);
                    if(pointDir.ContainsKey("dnPoint")) pointDir["dnPoint"] = (row: point.row + i, col: point.col);
                    if(pointDir.ContainsKey("lePoint")) pointDir["lePoint"] = (row: point.row, col: point.col - i);
                    if(pointDir.ContainsKey("riPoint")) pointDir["riPoint"] = (row: point.row, col: point.col + i);
                    if(pointDir.ContainsKey("ulPoint")) pointDir["ulPoint"] = (row: point.row - i, col: point.col - i);
                    if(pointDir.ContainsKey("urPoint")) pointDir["urPoint"] = (row: point.row - i, col: point.col + i);
                    if(pointDir.ContainsKey("dlPoint")) pointDir["dlPoint"] = (row: point.row + i, col: point.col - i);
                    if(pointDir.ContainsKey("drPoint")) pointDir["drPoint"] = (row: point.row + i, col: point.col + i);

                    var rmList = new List<string>();
                    foreach (var p in pointDir)
                    {
                        if (p.Value.row < 0
                            || p.Value.col < 0
                            || p.Value.row >= lines.Count
                            || p.Value.col >= lines[0].Length
                            || word[i] != lines[p.Value.row][p.Value.col])
                        {
                            rmList.Add(p.Key);
                        }
                    }

                    foreach (var r in rmList)
                        pointDir.Remove(r);
                }

                //Console.WriteLine($"({point.row},{point.col})");
                //foreach(var p in pointDir)
                //{
                //    Console.WriteLine(" - " + p.Key);
                //}

                sum += pointDir.Count;

            }

            Console.WriteLine(sum);
            Console.WriteLine("done");
        }
    }
}
