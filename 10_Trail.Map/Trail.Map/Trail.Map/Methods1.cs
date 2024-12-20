
using System.Collections.Generic;

namespace Trail.Map
{
	public class Metods1
	{
		public int searchPath(string[] input)
		{
			int addedScores = 0;
			string[] inputArray = input;
			int[,] directions = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } }; // moving up, rigth, down, left (y,x)

			for (int i = 0; i < inputArray.Length; i++)
			{
				for (int j = 0; j < inputArray[i].Length; j++)
				{
					if (inputArray[i][j] == '0')
					{
						var customComparer = Comparer<Tuple<int, int, int>>.Create((a, b) =>
						{
							return a.Item3.CompareTo(b.Item3);  // Compare based on Item3
						});

						HashSet<Tuple<int, int>> visitedCooridnates = new HashSet<Tuple<int, int>>();
						Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();

						queue.Enqueue(new Tuple<int, int, int>(i, j, 0));
						visitedCooridnates.Add(new Tuple<int, int>(i, j));

						while (queue.Count > 0)
						{
							var currentCoordinate = queue.Dequeue();
							int y = currentCoordinate.Item1;
							int x = currentCoordinate.Item2;
							int pathValue = currentCoordinate.Item3;

							for (int k = 0; k < directions.GetLength(0); k++)
							{
								int newRow = y + directions[k, 0];
								int newCol = x + directions[k, 1];

								if (newRow >= 0 && newRow < inputArray.Length && newCol >= 0 && newCol < inputArray[0].Length)
								{
									if (inputArray[newRow][newCol] == (pathValue + 1).ToString()[0])
									{
										var newCoord = new Tuple<int, int>(newRow, newCol);

										if (!visitedCooridnates.Contains(newCoord))
										{
											visitedCooridnates.Add(newCoord);
											queue.Enqueue(new Tuple<int, int, int>(newRow, newCol, pathValue + 1));
										}
									}
								}
							}
						}

						foreach (var tuple in visitedCooridnates)
						{
							// Convert (x, y) back to the path value by calculating it
							int pathValue = int.Parse(inputArray[tuple.Item1][tuple.Item2].ToString());

							if (pathValue == 9)
							{
								addedScores++;
							}
						}
					}
				}
			}
			return addedScores;
		}
	}
}
