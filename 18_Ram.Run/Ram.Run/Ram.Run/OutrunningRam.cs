
namespace Ram.Run
{
	public class OutrunningRam
	{
		public int Running(char[,] droppingRam, int gridSize)
		{
			int[,] directions = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } }; // moving up, rigth, down, left (y,x)

			var startPosition = new Tuple<int, int>(0, 0);
			var endPosition = new Tuple<int, int>(gridSize - 1, gridSize - 1);

			var queue = new Queue<Tuple<int, int>>();
			var distance = new int[gridSize, gridSize];

			// init the grid to unvisited
			for (int i = 0; i < gridSize; i++)
			{
				for (int j = 0; j < gridSize; j++)
				{
					distance[i, j] = -1;
				}
			}

			queue.Enqueue(startPosition);
			distance[0, 0] = 0;

			while (queue.Count > 0)
			{
				var current = queue.Dequeue();
				int r = current.Item1;
				int c = current.Item2;

				// If we reach the end position, return the distance
				if (r == endPosition.Item1 && c == endPosition.Item2)
				{
					return distance[r, c];
				}


				for (int k = 0; k < directions.GetLength(0); k++)
				{
					int newRow = r + directions[k, 0];
					int newCol = c + directions[k, 1];

					if (newRow >= 0 && newRow < gridSize && newCol >= 0 && newCol < gridSize && droppingRam[newRow, newCol] != '#' && distance[newRow, newCol] == -1)
					{
						distance[newRow, newCol] = distance[r, c] + 1;
						queue.Enqueue(new Tuple<int, int>(newRow, newCol));
					}
				}
			}
			return -2; // should happen if no path
		}
	}
}
