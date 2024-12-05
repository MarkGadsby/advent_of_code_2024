using System.Text.RegularExpressions;

class SolveDayThree : SolutionsBase
{
    string[]? input; 
    
    public SolveDayThree(StreamReader given_sr) : base(given_sr)
    { 
        while (stream_handle.Peek() >= 0)
        {
            input = stream_handle.ReadToEnd().Split('\n'); 
        }
    }

    public override void part_one()
    {
        int sum = 0;

        foreach(string st in input)
        {
            string pattern = "mul\\([0-999]+,[0-999]+\\)";
            
            foreach(Match match in Regex.Matches(st, pattern))
            {
                string[] funct = match.Value.Split('(',',',')');
                sum += int.Parse(funct[1]) * int.Parse(funct[2]);
            }
        }
        Console.WriteLine($"\n\t\t\tThe sum of all the mul(x,y) calculations is {sum}\n");
    }

    public override void part_two()
    {
        int sum = 0;
        bool addFlag = true;

        foreach(string st in input)
        {
            string pattern = "mul\\([0-999]+,[0-999]+\\)|don?'?t?\\(\\)";
            
            foreach(Match match in Regex.Matches(st, pattern))
            {
                if (match.Value == "don't()")
                    addFlag = false;
                else if (match.Value == "do()")
                    addFlag = true;
                else
                {
                    if (addFlag)
                    {
                        string[] funct = match.Value.Split('(',',',')');
                        sum += int.Parse(funct[1]) * int.Parse(funct[2]);
                    }
                }
            }
        }
        Console.WriteLine($"\n\t\t\tThe sum of all the mul(x,y) calculations taking into account the do/don't flags is {sum}\n");        
    }
}