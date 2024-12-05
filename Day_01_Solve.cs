class SolveDayOne : SolutionsBase
{
    private int[] dataList_1; 
    private int[] dataList_2; 
    private int runner;
   
    public SolveDayOne(StreamReader given_sr, int size) : base(given_sr)
    { 
        dataList_1 = new int[size];
        dataList_2 = new int[size];
        runner = 0;

        while (stream_handle.Peek() >= 0)
        {
            string lineOfData = stream_handle.ReadLine();
            dataList_1[runner] = int.Parse(lineOfData.Split("   ")[0]);
            dataList_2[runner] = int.Parse(lineOfData.Split("   ")[1]);
            runner++;
        }
    }

    public override void part_one()
    {
        bubble(dataList_1);
        bubble(dataList_2);

        int sum = 0;    

        while (--runner >= 0)
            sum += Math.Abs(dataList_1[runner] - dataList_2[runner]);
        
        Console.WriteLine($"\n\t\t\tThe sum of the difference between the two sorted list is: {sum}\n");
    }

    public override void part_two()
    {
        resetStream();

        int sum = 0;    
        
        foreach (int i in dataList_1)
            sum += i * SumOfOccurrences(dataList_2, i);
        
        Console.WriteLine($"\n\t\t\tThe sum of the numbers in the first list, each multiplied by the number of times it occurs in the second list, is: {sum}\n");
    }

    private int SumOfOccurrences(int[] data_II, int numInQuestion)
    {
        int sumOfOccurrences = 0;
        foreach (int i in data_II)
        {
            if (i == numInQuestion)
                sumOfOccurrences++;
        }
        return sumOfOccurrences;    
    }

    private void bubble(int[] data)
    {
        // each number
        for (int i = 0; i < data.Length; i++)
        {
            // each pass
            for (int j = 0; j < data.Length - 1; j++)
            {
                // Do swap
                if (data[j] > data[j + 1])
                {
                    int temp = data[j];
                    data[j] = data[j + 1];
                    data[j + 1] = temp;
                }
            }    
        }
    }
}

