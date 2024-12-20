
using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string[] args)
    {
        var path = "input.txt";
        string[] lines = File.ReadAllLines(path);
        Methods methods = new Methods();
        int result = 0;

        foreach(var line in lines)
        { 
            result += methods.Order(line);
        }

        Console.WriteLine(result);
    }

}