
using System.Text.RegularExpressions;

public class Program
{
	public static void Main(string[] args)
	{
		var path = "path\\input.txt";
		string[] lines = File.ReadAllLines(path);

		string input = string.Join(" ", lines);
		string pattern = @"\d+";

		Regex rg = new Regex(pattern);

		MatchCollection matches = rg.Matches(input);

		List<int> left = new List<int>();
		List<int> right = new List<int>();

		for (int i = 0; i < matches.Count; i++)
		{
			if (i % 2 == 0)
			{
				left.Add(int.Parse(matches[i].Value));
			}
			else
			{
				right.Add(int.Parse(matches[i].Value));
			}
		}
		//Console.WriteLine(left.Count);
		Program program = new Program();

		Console.WriteLine(program.SimilarityScore(left, right));
	}

	private int MeasureDistance(List<int> left, List<int> right)
	{
		int distance = 0;
		left.Sort();
		right.Sort();

		for (int i = 0; i < left.Count; i++)
		{
			int a = left[i] - right[i];
			//Console.WriteLine(a);
			distance += Math.Abs(a);
		}
		return distance;
	}

	private int SimilarityScore(List<int> left, List<int> right)
	{
		int score = 0;

		for (int i = 0; i < left.Count; i++)
		{
			int occurence = 0;
			int number = left[i];
			for (int j = 0; j < right.Count; j++)
			{
				if (number == right[j])
				{
					occurence++;
				}
			}
			score += occurence * number;
		}
		return score;
	}
}