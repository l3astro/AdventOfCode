namespace Guards.Path
{
	internal class Methods
	{
		public int CountPositions(char[,] grid)
		{
			int iterationCount = 0;
			int count = 0;
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
			count++;

			while (true)
			{
				if (!(StillInGrid(grid, x, y -1)))
				{
					break;
				}

				while (StillInGrid(grid, x - 1, y) && grid[x - 1, y] != '#')
				{
					x--;
					iterationCount++;
					if (grid[x, y] != 'X')
					{
						count++;
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
						count++;
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
						count++;
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
						count++;
						grid[x, y] = 'X';
					}
				}
			}

			for (int i = 0; i < grid.GetLength(0); i++)
			{
				for (int j = 0; j < grid.GetLength(1); j++)
				{
					Console.Write(grid[i, j]);
				}
				Console.WriteLine();
			}
			Console.WriteLine(iterationCount);
			return count;
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
