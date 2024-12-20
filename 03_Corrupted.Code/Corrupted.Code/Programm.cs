public class Programm
{
    public static void Main(string[] args)
    {
        Methods metod = new Methods();
        Console.WriteLine("enter corrupted code here: ");
        string input = Console.ReadLine();

        Console.WriteLine("Calculating...");

        Console.WriteLine(metod.findMul(input));
    }
}
