
namespace Trail.Map
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var path = "path\\Input.txt";
			string[] lines = File.ReadAllLines(path);

			Metods2 metods = new Metods2();

			Console.WriteLine(metods.searchPath(lines));
		}
	}

}
