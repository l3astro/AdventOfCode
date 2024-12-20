
namespace Cheat.Race
{
	public class RacePath
	{
		public (int, List<Tuple<int, int>>) getFastestRacePath(string[] map)
		{
			var startPosition = findStartPosition(map);
			var endPosition = findEndPosition(map);
			//Console.WriteLine(startPosition.ToString());
			//Console.WriteLine(endPosition.ToString());

			int distance = 0;

			int[,] directions = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } }; // moving up, rigth, down, left (y,x)
			var currentDirection = new Tuple<int, int>(0, 0);
			var currentPosition = startPosition;
			var visited = new List<Tuple<int, int>>();
			visited.Add(currentPosition);

			while (!currentPosition.Equals(endPosition))
			{
				for (int k = 0; k < directions.GetLength(0); k++)
				{
					int newRow = currentPosition.Item1 + directions[k, 0];
					int newCol = currentPosition.Item2 + directions[k, 1];

					if (visited.Contains(new Tuple<int, int>(newRow, newCol))) // preventing infinit loop
					{
						continue;
					}
					
					if (map[newRow][newCol] != '#') // only checking for # because we have border
					{
						//Console.WriteLine("reached");
						currentPosition = new Tuple<int, int>(newRow, newCol);
						visited.Add(currentPosition);
						//Console.WriteLine(currentPosition.ToString());
						currentDirection = new Tuple<int, int>(directions[k,0], directions[k,1]);
						//Console.WriteLine(currentDirection.ToString());
						distance++;

						// start new track
					}
				}

				while (map[currentPosition.Item1 + currentDirection.Item1][currentPosition.Item2 + currentDirection.Item2] != '#' && !currentPosition.Equals(endPosition))
				{
					currentPosition = new Tuple<int, int>(currentPosition.Item1 + currentDirection.Item1, currentPosition.Item2 + currentDirection.Item2);
					visited.Add(currentPosition);
					//Console.WriteLine(currentPosition.ToString());

					distance++;
				}
			}
			return (distance, visited);
		}

		private Tuple<int, int> findStartPosition(string[] map)
		{
			for (int i = 0; i < map.Count(); i++)
			{
				for (int j = 0; j < map[i].Length; j++)
				{
					if (map[i][j] == 'S')
					{
						return new Tuple<int, int>(i, j);
					}
				}
			}
			return null; // should not happen
		}

		private Tuple<int, int> findEndPosition(string[] map)
		{
			for (int i = 0; i < map.Count(); i++)
			{
				for (int j = 0; j < map[i].Length; j++)
				{
					if (map[i][j] == 'E')
					{
						return new Tuple<int, int>(i, j);
					}
				}
			}
			return null; // should not happen
		}
	}
}
