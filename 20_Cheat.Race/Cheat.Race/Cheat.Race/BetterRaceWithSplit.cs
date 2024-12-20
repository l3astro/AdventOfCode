
namespace Cheat.Race
{
	internal class BetterRaceWithSplit
	{
		static int[,] directions = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } }; // moving up, rigth, down, left (y,x)
		public int getFastestRacePath(string[] map, List<Tuple<int, int>> normalPath, Tuple<int, int> replacedBorder)
		{
			var surroundingPoints = new List<(int y, int x, int indexInNormalPath)>();

			for (int i = 0; i < directions.GetLength(0); i++)
			{
				int newRow = replacedBorder.Item1 + directions[i, 0];
				int newCol = replacedBorder.Item2 + directions[i, 1];

				if (map[newRow][newCol] != '#')
				{
					var index = normalPath.IndexOf(new Tuple<int, int>(newRow, newCol));
					surroundingPoints.Add((newRow, newCol, index));
				}
			}

			if (surroundingPoints.Count < 2)
			{
				return normalPath.Count;
			}

			surroundingPoints = surroundingPoints.OrderBy(e => e.indexInNormalPath).ToList();

			var pathUntilReplacedBorder = normalPath.Take(surroundingPoints[0].indexInNormalPath).Count();
			var pathAfterReplacedBorder = normalPath.Skip(surroundingPoints.Last().indexInNormalPath).Count();

			return pathUntilReplacedBorder + 1 + pathAfterReplacedBorder;

		}
	}
}
