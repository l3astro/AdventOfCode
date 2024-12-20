namespace Guards.Path
{
	internal class Methods2
	{
		public int CountWithObstacles()
		{
			int count = 0;
			char[,] grid = GetData();

			for (int i = 0;i < grid.GetLength(0); i++)
			{
				for (int j = 0; j < grid.GetLength(1); j++)
				{
					grid = GetData();
					if (grid[i,j] != '^' && grid[i,j] != '#')
					{
						grid[i, j] = '#';
						count += CountPositions(grid);
					}
				}
			}
			return count;

		}

		private char[,] GetData()
		{
			var path = "path\\input.txt";
			string[] lines = File.ReadAllLines(path);
			int maxColumns = lines.Max(line => line.Length);
			char[,] data = new char[lines.Length, maxColumns];

			for (int i = 0; i < lines.Length; i++)
			{
				for (int j = 0; j < lines[i].Length; j++)
				{
					data[i, j] = lines[i][j];
				}
			}
			return data;
		}

		private int CountPositions(char[,] grid)
		{
			int iterationCount = 0;
			int x = 0, y = 0; //current position of guard

			for (int i = 0; i < grid.GetLength(0); i++) // number of rows
			{
				for (int j = 0; j < grid.GetLength(1); j++) // number of columns
				{
					if (grid[i, j] == '^')
					{
						x = i;
						y = j;
					}
				}
			}

			// counting starting position
			grid[x, y] = 'X';

			while (iterationCount < 7000)
			{
				if (!(StillInGrid(grid, x, y - 1)))
				{
					break;
				}

				while (StillInGrid(grid, x - 1, y) && grid[x - 1, y] != '#')
				{
					x--;
					iterationCount++;
					if (grid[x, y] != 'X')
					{
						grid[x, y] = 'X';
					}

				}

				if (!(StillInGrid(grid, x - 1, y)))
				{
					break;
				}

				while (StillInGrid(grid, x, y + 1) && grid[x, y + 1] != '#')
				{
					y++;
					iterationCount++;
					if (grid[x, y] != 'X')
					{
						grid[x, y] = 'X';
					}
				}

				if (!(StillInGrid(grid, x, y + 1)))
				{
					break;
				}

				while (StillInGrid(grid, x + 1, y) && grid[x + 1, y] != '#')
				{
					x++;
					iterationCount++;
					if (grid[x, y] != 'X')
					{
						grid[x, y] = 'X';
					}
				}

				if (!(StillInGrid(grid, x + 1, y)))
				{
					break;
				}

				while (StillInGrid(grid, x, y - 1) && grid[x, y - 1] != '#')
				{
					y--;
					iterationCount++;
					if (grid[x, y] != 'X')
					{
						grid[x, y] = 'X';
					}
				}
			}
			Console.WriteLine(iterationCount);
			if (iterationCount >= 7000)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}

		private bool StillInGrid(char[,] grid, int x, int y)
		{
			int xmax = grid.GetLength(0);
			int ymax = grid.GetLength(1);

			if (x < 0 || y < 0 || x >= xmax || y >= ymax)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
