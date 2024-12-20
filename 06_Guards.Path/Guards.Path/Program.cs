using Guards.Path;

public class Program
{
	public static void Main(string[] args)
	{
		var path = "C:\\Users\\lga\\Desktop\\grooveBASE\\ASP.NET MVC\\Guards.Path\\Guards.Path\\input.txt";
		string[] lines = File.ReadAllLines(path);
		int maxColumns = lines.Max(line => line.Length);
		char[,] data = new char[lines.Length, maxColumns];

		for (int i = 0; i < lines.Length; i++)
		{
			for (int j = 0; j < lines[i].Length; j++)
			{
				data[i, j] = lines[i][j];
			}
		}

		Methods2 methods = new Methods2();

		Console.WriteLine("Count: " + methods.CountWithObstacles());

		//for (int i = 0; i < data.Length; i++)
		//{
		//	Console.WriteLine(string.Join(" ", data[i]));
		//}

	}
}