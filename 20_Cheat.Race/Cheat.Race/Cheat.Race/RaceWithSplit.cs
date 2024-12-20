using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheat.Race
{
	internal class RaceWithSplit
	{
		static int[,] directions = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } }; // moving up, rigth, down, left (y,x)
		public int getFastestRacePath(string[] map, List<Tuple<int ,int>> normalPath, Tuple<int,int> replacedBorder)
		{
			var startPosition = findStartPosition(map);
			var endPosition = findEndPosition(map);
			//Console.WriteLine(startPosition.ToString());
			//Console.WriteLine(endPosition.ToString());

			int distance = 0;

			var currentDirection = new Tuple<int, int>(0, 0);
			var currentPosition = startPosition;
			var visited = new List<Tuple<int, int>>();
			visited.Add(currentPosition);

			while (!currentPosition.Equals(endPosition))
			{
				var replacedDirection = getReplacedDirection(map, currentPosition, replacedBorder);
				if (replacedDirection != null)
				{
					//Console.WriteLine("reached replace");

					visited.Add(replacedBorder);
					currentPosition = replacedBorder;
					//Console.WriteLine(currentPosition.ToString());
					currentDirection = replacedDirection;
					//Console.WriteLine(currentDirection.ToString());
					distance++;

					//move second time
					currentPosition = new Tuple<int, int>(replacedBorder.Item1 + currentDirection.Item1, replacedBorder.Item2 + currentDirection.Item2);
					visited.Add(currentPosition);
					// no direction has changed
					distance++;

					if (normalPath.Contains(currentPosition))
					{
						distance += normalPath.Skip(normalPath.IndexOf(currentPosition)).Count() - 1;
						return distance;
					} 
					else
					{
						return normalPath.Count;
					}
				}

				for (int k = 0; k < directions.GetLength(0); k++)
				{
					int newRow = currentPosition.Item1 + directions[k, 0];
					int newCol = currentPosition.Item2 + directions[k, 1];

					var newCurrentPosition = new Tuple<int, int>(newRow, newCol);

					if (visited.Contains(newCurrentPosition)) // preventing infinit loop
					{
						continue;
					}

					if (map[newRow][newCol] != '#') // only checking for # because we have border
					{
						//Console.WriteLine("reached");

						visited.Add(newCurrentPosition);
						//Console.WriteLine(newCurrentPosition.ToString());
						currentDirection = new Tuple<int, int>(directions[k, 0], directions[k, 1]);
						//Console.WriteLine(currentDirection.ToString());
						currentPosition = newCurrentPosition;
						distance++;
						break;
					}
				}
			}
			return distance;
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

		private Tuple<int, int>? getReplacedDirection(string[] map, Tuple<int, int> currentPosition, Tuple<int,int> replaced)
		{
			for (int k = 0; k < directions.GetLength(0); k++)
			{
				int newRow = currentPosition.Item1 + directions[k, 0];
				int newCol = currentPosition.Item2 + directions[k, 1];

				var tuple = new Tuple<int, int>(newRow, newCol);

				if (replaced.Equals(tuple))
				{
					return new Tuple<int, int>(directions[k, 0], directions[k, 1]);
				}
			}
			return null;
		}
}
}
