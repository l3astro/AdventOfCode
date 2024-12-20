
using System.Collections.Generic;

namespace Trail.Map
{
	public class Metods2
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

						List<Tuple<int, int, int>> visitedCooridnates = new List<Tuple<int, int, int>>();
						Tuple<int, int, int> currentCordinate = new Tuple<int, int, int>(i, j, 0);

						visitedCooridnates.Add(currentCordinate);
						int index = 0;

						while (visitedCooridnates.Count > index)
						{
							currentCordinate = visitedCooridnates[index];
							index++;

							for (int k = 0; k < directions.GetLength(0); k++)
							{
								int newRow = currentCordinate.Item1 + directions[k, 0];
								int newCol = currentCordinate.Item2 + directions[k, 1];
								if (newRow >= 0 && newRow < inputArray.Length && newCol >= 0 && newCol < inputArray[0].Length)
								{
									if (inputArray[newRow][newCol] == (currentCordinate.Item3 + 1).ToString()[0])
									{
										visitedCooridnates.Add(new Tuple<int, int, int>(newRow, newCol, currentCordinate.Item3 + 1));
									}
								}
							}
						}

						foreach (var tuple in visitedCooridnates)
						{
							//foreach (var item in visitedCooridnates)
							//{
							//	Console.WriteLine(item);
							//}
							if (tuple.Item3 == 9)
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
