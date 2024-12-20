

namespace Corrupted.Harddisk
{
	public class Method2
	{
		public long getChecksum(string line)
		{
			List<List<int>> intList = new List<List<int>>();// list containing free spaces and the index the correct amount of time
			long score = 0;

			for (int i = 0; i < line.Length; i++)
			{
				int value = (int)char.GetNumericValue(line[i]);

				for (int j = 0; j < value; j++)
				{
					if (i % 2 == 0) // even numbers
					{
						intList[i].Add(i / 2);
					}
					else
					{
						intList[i].Add(-1);
					}
				}
			}

			List<int> newIntList = new List<int>();

			for (int i = 0;i < intList.Count; i++)
			{
				if (intList[i].Contains(-1))
				{
					for (int j = intList.Count - 1; j >= 0; j--)
					{
						if (intList[i].Count >= intList[j].Count)
						{
							for (int k = 0; k < intList[j].Count; k++)
							{
								newIntList.Add(intList[j][k]); // i still do have to remove the -1s i used up so not jet finished
							}
							intList.RemoveAt(j);
						}
					}
				}
				else
				{
					foreach (int value in intList[i])
					{
						newIntList.Add(value);
					}
				}
			}

			for (int i = 0; i < intList.Count; i++)
			{
				for(int j = 0;j < intList[i].Count; j++)
				{
					score += intList[i][j] * j;
				}
				
			}


			return score;
		}
	}
}
