class Program
{
    static void Main()
    {
        Console.WriteLine("Enter row count:");
        int rowCount = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter header line:");
        string header = Console.ReadLine();
        Console.WriteLine("Enter footer line:");
        string footer = Console.ReadLine();
        Console.WriteLine(header);
        GenerateTree(rowCount);
        Console.WriteLine(footer);
    }

    static void GenerateTree(int rowCount)
    {
        int width = ((rowCount - 2) * 2) + 1;
        int posLeft = rowCount - 2;
        int posRight = posLeft + 2;

        //tree start
        for (int i = 0; i < rowCount; i++)
        {
            //first row
            if (i == 0)
            {
                for (int j = 0; j < width; j++)
                {
                    if (j > posLeft - 1 && j < posRight - 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
                posLeft--;
                posRight++;
            }
            //middle rows
            if (i > 0 && i < rowCount - 2)
            {
                for (int j = 0; j < width; j++)
                {
                    if (j == posLeft - 1 || j == posRight - 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
                posLeft--;
                posRight++;
            }
            //row before base
            if (i == rowCount - 2)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            //tree base
            if (i == rowCount - 1)
            {
                posLeft = rowCount - 2;
                posRight = posLeft + 2;
                for (int j = 0; j < width; j++)
                {
                    if (j > posLeft - 1 && j < posRight - 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
