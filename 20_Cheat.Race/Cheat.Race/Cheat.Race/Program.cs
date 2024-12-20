
using System.Diagnostics;
using Cheat.Race;

public class Program
{
	public static int shortesPath;
	public static void Main(string[] args)
	{
		Part1();
		Part2();
	}

	private static void Part1()
	{
		string path = "path\\Input.txt";
		string[] lines = File.ReadAllLines(path);

		var totalShorctus = 0;
		var RacePath = new RacePath();
		var (normalDistance, normalPath) = RacePath.getFastestRacePath(lines);

		var RaceWithSplit = new RaceWithSplit();
		var BetterRaceWithSplit = new BetterRaceWithSplit();
		for (int y = 1; y < lines.Length - 1; y++)
		{
			for (int x = 1; x < lines[0].Length - 1; x++)
			{
				if (lines[y][x] != '#')
				{
					continue;
				}

				Console.WriteLine($"Replaced # on ({y}, {x})");

				var copyLines = lines.ToArray().Select(e => e.ToCharArray()).ToArray();
				copyLines[y][x] = '.';
				var stringCoppyLines = copyLines.Select(e => new string(e)).ToArray();

				// to slow xD
				//var shortcutDistance = RaceWithSplit.getFastestRacePath(stringCoppyLines, normalPath, new Tuple<int, int>(y, x));
				//if (shortcutDistance <= normalDistance - 20)
				//{
				//	totalShorctus++;
				//}

				// Better solution
				var shortcutDistance = BetterRaceWithSplit.getFastestRacePath(stringCoppyLines, normalPath, new Tuple<int, int>(y, x));
				if (shortcutDistance <= normalDistance - 100)
				{
					totalShorctus++;
				}
			}
		}


		Console.WriteLine("Total Shortcuts");
		Console.WriteLine(totalShorctus);
	}

	private static void Part2()
	{
		Stopwatch stopwatch = new Stopwatch();

		string path = "path\\Input.txt";
		string[] lines = File.ReadAllLines(path);

		var RacePath = new RacePath();

		stopwatch.Start();
		var (normalDistance, normalPath) = RacePath.getFastestRacePath(lines);

		var RaceForTask2 = new RaceForTask2();
		var totalShorctus = RaceForTask2.getFastestRacePathsCount(normalPath);
		stopwatch.Stop();

		Console.WriteLine("Total Shortcuts");
		Console.WriteLine(totalShorctus);
		Console.WriteLine($"Total time: {stopwatch.ElapsedMilliseconds} ms");
	}
}