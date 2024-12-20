
using System.Text.RegularExpressions;
using Ram.Run;

public class Program
{
	static void Main(string[] args)
	{
		string path = "path\\Input.txt";
		string input = File.ReadAllText(path);

		string pattern = @"\d+";
		var regex = new Regex(pattern);
		MatchCollection matches = regex.Matches(input);

		int gridSize = 71;
		int count = 2048;

		var corruptedCord = new char[gridSize, gridSize];

		for (int i = 0; i < gridSize; i++)
		{
			for (int j = 0; j < gridSize; j++)
			{
				corruptedCord[i, j] = '.'; // Initialize as free space
			}
		}

		for (int i = 0; i < count; i += 2)
		{
			int x = int.Parse(matches[i].Value);
			int y = int.Parse(matches[i + 1].Value);

			corruptedCord[x, y] = '#';          // Initialize as blocked space
		}

		OutrunningRam outrunningRam = new OutrunningRam();

		while (outrunningRam.Running(corruptedCord, gridSize) != -2)
		{
			if (count >= matches.Count - 1)
			{
				Console.WriteLine("break");
				break;  
			}

			count += 2;
			int x = int.Parse(matches[count].Value);
			int y = int.Parse(matches[count + 1].Value);
			corruptedCord[x, y] = '#';  // Mark the new blocked space
		}

		Console.WriteLine(matches[count] + "," + matches[count + 1]);
	}

	static void PrintGrid(char[,] grid, int gridSize)
	{
		for (int i = 0; i < gridSize; i++)
		{
			for (int j = 0; j < gridSize; j++)
			{
				Console.Write(grid[i, j] + " ");
			}
			Console.WriteLine();
		}
	}
}