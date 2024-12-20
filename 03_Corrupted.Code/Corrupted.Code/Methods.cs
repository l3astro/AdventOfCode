using System.Text.RegularExpressions;
public class Methods
{
    private static string pattern = @"mul\((\d+),(\d+)\)|do\(\)|don't\(\)";
    Regex rg = new Regex(pattern);

    public int findMul(string input)
    {
        bool doMul = true;
        int result = 0;
        Match match =rg.Match(input);
        while (match.Success)
        {
            Console.WriteLine(match);
            if (match.Value == "do()")
            {
                doMul = true;
                Console.WriteLine(doMul);
            }
            if (match.Value == "don't()")
            {
                doMul = false;
                Console.WriteLine(doMul);

            }
            if (doMul && match.Length > 7)
            {
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);

                result += mul(x, y);
            }

            match = match.NextMatch();
        }
        return result;
    }

    private int mul(int x, int y)
    {
        return x * y;
    }
}