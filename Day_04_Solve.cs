enum Dir
{
    NE,
    N,
    NW,
    W,
    SW,
    S,
    SE,
    E    
}

class SolveDayFour : SolutionsBase
{
    char[,] input; 
    int size;
    
    public SolveDayFour(StreamReader given_sr, int given_size) : base(given_sr)
    { 
        size = given_size; 
        input = new char[size,size];

        while (stream_handle.Peek() >= 0)
        {
            for (int row = 0; row < size; row++)    
            {
                for (int col = 0; col < size; col++)
                {
                    input[col, row] = (char)stream_handle.Read();
                }
                stream_handle.Read();
            }
        }
//        display();
    }

    private void display()
    {
        for (int row = 0; row < size; row++)    
        {
            for (int col = 0; col < size; col++)
            {
                Console.Write(input[col,row]);
            }
            Console.WriteLine();
        }
    }

    public override void part_one()
    {
        int sum = 0;

        for (int row = 0; row < size; row++)    
        {
            for (int col = 0; col < size; col++)
            {
                if (input[col,row] == 'X')
                {
                    Console.WriteLine($"col = {col} row = {row}");
                }
            }
        }

        Console.WriteLine($"\n\t\t\tThe sum of all the mul(x,y) calculations is {sum}\n");
    }

    public override void part_two()
    {
        int sum = 0;
        Console.WriteLine($"\n\t\t\tThe sum of all the mul(x,y) calculations taking into account the do/don't flags is {sum}\n");        
    }
}