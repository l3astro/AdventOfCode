
using System.Text.RegularExpressions;
using Chronospatial.Computer;
using static Chronospatial.Computer.Method2;

public class Program
{
	//public static void Main(string[] args)
	//{
	//	var path = "C:\\Users\\lga\\Desktop\\grooveBASE\\AdventOfCode\\17_Chronospatial.Computer\\Chronospatial.Computer\\Chronospatial.Computer\\Input.txt";
	//	string input = File.ReadAllText(path);

	//	string pattern = @"\d+";

	//	Regex regex = new Regex(pattern);
	//	MatchCollection matches = regex.Matches(input);

	//	int registerA = int.Parse(matches[0].Value);
	//	int registerB = int.Parse(matches[1].Value);
	//	int registerC = int.Parse(matches[2].Value);

	//	List<int> program = new List<int>();
	//	for (int i = 3; i < matches.Count; i++)
	//	{
	//		program.Add(int.Parse(matches[i].Value));
	//	}

	//	MiniComputer miniComputer = new MiniComputer(registerA, registerB, registerC);

	//	Console.WriteLine(miniComputer.computing(program));
	//}

	public static void Main(string[] args)
	{
		var path = "path\\SmallInput.txt";
		string input = File.ReadAllText(path);

		string pattern = @"\d+";

		Regex regex = new Regex(pattern);
		MatchCollection matches = regex.Matches(input);

		List<int> program = new List<int>();
		for (int i = 3; i < matches.Count; i++)
		{
			program.Add(int.Parse(matches[i].Value));
		}
		int registerA = 117430;

		MiniComputer2 miniComputer = new MiniComputer2(registerA, 0, 0);
		while (!miniComputer.computing(program))
		{
			registerA++;
			miniComputer = new MiniComputer2(registerA, 0, 0);
		}
		Console.WriteLine(registerA);
	}

}