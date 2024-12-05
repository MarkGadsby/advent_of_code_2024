enum Direction
{
    ascending,
    descending,
    flat
}

class SolveDayTwo : SolutionsBase
{   
    private int [,] dataBlock;
    private const int MAX_WIDTH = 9;
    private int size;
    private int runner;

    public SolveDayTwo(StreamReader given_sr, int given_size) : base(given_sr)
    { 
        size = given_size;
        dataBlock = new int[MAX_WIDTH, size];

        // Fill block
        runner = 0;

        while (stream_handle.Peek() >= 0)
        {   
            string[] lineOfInput = stream_handle.ReadLine().Split(' ');
            
            int iInputs = lineOfInput.Length;

            while (--iInputs >= 0)
                dataBlock[iInputs, runner] = int.Parse(lineOfInput[iInputs]);

            runner++;    
        }
    }

    private void DisplayData()
    {
        for (int r = 0; r < size; r++)
        {
            Console.WriteLine();
            for (int c = 0; c < MAX_WIDTH; c++)
            {
                Console.Write($"{dataBlock[c,r]}\t");
            }
        }    
        Console.WriteLine();
    }

    public override void part_one()
    {
        int sum = 0;

        int[] lineArray = new int[MAX_WIDTH]; 

        for (int r = 0; r < size; r++)
        {
            for (int c = 0; c < MAX_WIDTH; c++)
            {
                lineArray[c] = dataBlock[c,r];
            }
            
            if (isSafe(lineArray))
                sum++;            
        }
        Console.WriteLine($"\t\tThe sum is: {sum}\n");
    }

    public override void part_two()
    {
        int sum = 0;

        int[] lineArray = new int[MAX_WIDTH]; 

        for (int r = 0; r < size; r++)
        {
            for (int c = 0; c < MAX_WIDTH; c++)
            {
                lineArray[c] = dataBlock[c,r];
            }

            if (isSafe(lineArray))
                sum++;            
            else 
            {
                if (isSaftyTolerant(lineArray))
                    sum++;            
            }
        }
        Console.WriteLine($"\t\tThe sum is: {sum}\n");
    }

    private int GetEndOfData(int[] data)
    {
        int index = 0;

        while (index < MAX_WIDTH && data[index] != 0)
            index++;

        return --index;    
    }

    private bool isSaftyTolerant(int[] data)
    {
        // assume true - until its false
        bool retVal = true;
        bool gotMaskHit = false;
        int endOfData = GetEndOfData(data);

        Direction dir;

        if (data[0] > data[endOfData])
            dir = Direction.descending;
        else if (data[0] < data[endOfData])
            dir = Direction.ascending;
        else
            dir = Direction.flat;

        for (int maskout = 0; maskout < MAX_WIDTH; maskout++)
        {
            retVal = true;
            int[] tempArray = new int[MAX_WIDTH];

            for (int i = 0; i < MAX_WIDTH; i++)
                tempArray[i] = data[i];

            RemoveFromData(tempArray, maskout);

            for (int i = 0; i < (MAX_WIDTH - 1); i++)
            {
                if (tempArray[i+1] == 0)
                    continue;

                int diff = tempArray[i] - tempArray[i+1];

                if ( (diff >= 1 && diff <= 3 && dir == Direction.descending) ||
                    (diff <= -1 && diff >= -3 && dir == Direction.ascending) )
                    {
                        // still true
                    }
                else
                    retVal = false;
            }
            if (retVal)
                gotMaskHit = true;
        }
        return gotMaskHit;        
    }

    private void RemoveFromData(int[] data, int maskout)
    {
        for (int i = 0; i < MAX_WIDTH; i++)
        {
            if (i > maskout)
                data[i-1] = data[i];
        }
    }

    private bool isSafe(int[] data)
    {
        // assume true - until its false
        bool retVal = true;
        int endOfData = GetEndOfData(data);

        Direction dir;

        if (data[0] > data[endOfData])
            dir = Direction.descending;
        else if (data[0] < data[endOfData])
            dir = Direction.ascending;
        else
            dir = Direction.flat;

        for (int i = 0; i < (MAX_WIDTH - 1); i++)
        {
            if (data[i+1] == 0)
                continue;

            int diff = data[i] - data[i+1];

            if ( (diff >= 1 && diff <= 3 && dir == Direction.descending) ||
                 (diff <= -1 && diff >= -3 && dir == Direction.ascending) )
                 {
                    // still true
                 }
            else
                retVal = false;
        }
        return retVal;        
    }
}
