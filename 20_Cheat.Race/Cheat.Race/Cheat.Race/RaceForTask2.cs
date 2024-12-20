using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheat.Race
{
	internal class RaceForTask2
	{
		public int getFastestRacePathsCount(List<Tuple<int, int>> normalPath)
		{
			var shorterShortcuts = 0;
			var normalDistance = normalPath.Count;
			for (int i = 0; i < normalPath.Count; i++)
			{
				for (int j = i + 2; j < normalPath.Count; j++)
				{
					var difY = Math.Abs(normalPath[i].Item1 - normalPath[j].Item1);
					var difX = Math.Abs(normalPath[i].Item2 - normalPath[j].Item2);

					var distance = difY + difX;

					if (distance > 20)
					{
						continue;
					}

					var pathUntilShortcut = normalPath.Take(i).Count();
					var pathAfterShortcut = normalPath.Skip(j).Count();

					var totalShortcutPathLength = pathUntilShortcut + distance + pathAfterShortcut;

					if (totalShortcutPathLength <= normalDistance - 100)
					{
						shorterShortcuts++;
					}
				}
			}

			return shorterShortcuts;
		}
	}
}
