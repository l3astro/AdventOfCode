

namespace Corrupted.Harddisk
{
	public class Method1
	{
		public long getChecksum(string line)
		{
			List<int> intList = new List<int>(); // list containing free spaces and the index the correct amount of time
			long score = 0;

			for (int i = 0; i < line.Length; i++) 
			{
				int value = (int)char.GetNumericValue(line[i]);

				for (int j = 0; j < value; j++)
				{
					if (i % 2 == 0) // even numbers
					{
						intList.Add(i/2);
					} 
					else
					{
						intList.Add(-1);
					}
				}
			}

			while (intList.Contains(-1))
			{
				int lastNumber = intList.Last();
				intList.RemoveAt(intList.Count - 1);

				if (lastNumber == -1)
				{
					continue;
				} else
				{
					intList[intList.IndexOf(-1)] = lastNumber;
				}
			}

			for (int i = 0; i < intList.Count; i++)
			{
				score += intList[i] * i;
			}


			return score;
		}
	}
}
