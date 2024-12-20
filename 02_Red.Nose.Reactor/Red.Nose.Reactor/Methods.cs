using System.Text.RegularExpressions;

public class Methods
{
    public int Order(string input)
    {
        string pattern = @"\d+";
        Regex rg = new Regex(pattern);
        Match match1 = rg.Match(input);
        Match match2 = match1.NextMatch();
        Match match3 = match2.NextMatch();

        int value1 = int.Parse(match1.Value);
        int value2 = int.Parse(match2.Value);
        int value3 = int.Parse(match3.Value);

        if (value1 > value2 && value1 <= value2 + 3)
        {
            return Decreasing(input);
        }
        if (value1 < value2 && value1 + 3 >= value2)
        {
            return Increasing(input);
        }
        if (value1 == value2)
        {
            if (value2 > value3 && value2 <= value3 + 3)
            {
                return Decreasing(input);
            }
            if (value2 < value3 && value2 + 3 >= value3)
            {
                return Increasing(input);
            }
                return 0;
        }
        return 0;
    }

    private int Decreasing(string input)
    {
        string pattern = @"\d+";
        Regex rg = new Regex(pattern);
        Match match1 = rg.Match(input);
        Match match2 = match1.NextMatch();

        bool skipped = false;

        while (match2.Success) 
        {
            int value1 = int.Parse(match1.Value);
            int value2 = int.Parse(match2.Value);

            if (value1 > value2 && value1 <= value2 + 3)
            {
                match1 = match1.NextMatch();
                match2 = match2.NextMatch();
                continue;
            }
            else
            {
                if (!skipped)
                {
                    skipped = true;
                    match2 = match2.NextMatch();
                }
                else
                {
                    return 0;
                }
            }
        }
        return 1;
    }

    private int Increasing(string input)
    {
        string pattern = @"\d+";
        Regex rg = new Regex(pattern);
        Match match1 = rg.Match(input);
        Match match2 = match1.NextMatch();

        bool skipped = false;

        while (match2.Success)
        {
            int value1 = int.Parse(match1.Value);
            int value2 = int.Parse(match2.Value);

            if (value1 < value2 && value1 + 3 >= value2)
            {
                match1 = match1.NextMatch();
                match2 = match2.NextMatch();
                continue;
            }
            else
            {
                if (!skipped)
                {
                    skipped = true;
                    match2 = match2.NextMatch();
                } else
                {
                    return 0;
                }
            }
        }
        return 1;
    }
}