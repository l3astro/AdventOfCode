using Corrupted.Harddisk;

public class Program
{
	public static void Main(string[] args)
	{
		var path = "path\\Input.txt";
		string line = File.ReadAllText(path);

		Method2 metod  = new Method2();

		Console.Write(metod.getChecksum(line));

		//
	}
}
