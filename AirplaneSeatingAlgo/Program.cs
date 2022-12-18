// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Metrics;
using System.Text.Json.Nodes;

void AssigenPassengerSeat(int[,] seats, int numberOfPassengers)
{
    int rows = seats.GetLength(0);
    int cols = seats.GetLength(1);
    int[,] transposed = new int[rows, cols];
    int max_rows = 0;

    for (int i = 0; i < seats.GetLength(0); i++)
    {
        transposed[i, 0] = seats[i, 1];
        transposed[i, 1] = seats[i, 0];
        if (transposed[i, 0] > max_rows)
            max_rows = transposed[i, 0];
    }

    int counter = 1;
    //Asile seats
    Console.WriteLine("Displaying Asile seats");
    for (int mi = 0; mi < max_rows && counter <= numberOfPassengers; mi++)
    {
        for (int i = 0; i < transposed.GetLength(0) && counter <= numberOfPassengers; i++)
        {
            int ros = transposed[i, 0];
            int columns = 0;

            if (i == 0)
            {
                if (mi < ros)
                {
                    columns = transposed[i, 1];
                    Console.WriteLine("Row={0}, Column={1}, Passanger={2}", mi, columns - 1, counter);
                    ++counter;
                }
            }
            else if (i > 0 && i < transposed.GetLength(0) - 1)
            {
                if (mi < ros)
                {
                    columns = transposed[i, 1];
                    Console.WriteLine("Row={0}, Column={1}, Passanger={2}", mi, 0, counter);
                    ++counter;
                    Console.WriteLine("Row={0}, Column={1}, Passanger={2}", mi, columns - 1, counter);
                    ++counter;
                }
            }
            else if (i == transposed.GetLength(0) - 1)
            {
                if (mi < ros)
                {
                    columns = transposed[i, 1];
                    Console.WriteLine("Row={0}, Column={1}, Passanger={2}", mi, 0, counter);
                    ++counter;
                }
            }
        }
    }

    //Window seats
    Console.WriteLine("Displaying Windows seats");
    for (int mi = 0; mi < max_rows && counter <= numberOfPassengers; mi++)
    {
        for (int i = 0; i < transposed.GetLength(0) && counter <= numberOfPassengers; i++)
        {
            int ros = transposed[i, 0];
            int columns = 0;

            if (i == 0)
            {
                if (mi < ros)
                {
                    columns = transposed[i, 1];
                    Console.WriteLine("Row={0}, Column={1}, Passanger={2}", mi, 0, counter);
                    ++counter;
                }
            }
            else if (i == transposed.GetLength(0) - 1)
            {
                if (mi < ros)
                {
                    columns = transposed[i, 1];
                    Console.WriteLine("Row={0}, Column={1}, Passanger={2}", mi, columns - 1, counter);
                    ++counter;
                }
            }
        }
    }

    //Center seats any order
    Console.WriteLine("Displaying Center Seats");
    for (int mi = 0; mi < max_rows && counter <= numberOfPassengers; mi++)
    {
        for (int i = 0; i < transposed.GetLength(0) && counter <= numberOfPassengers; i++)
        {
            int ros = transposed[i, 0];
            int columns = 0;

            if (mi < ros)
            {
                columns = transposed[i, 1];
                if (columns > 2)
                {
                    int numberOfColumns = columns - 2;
                    if (numberOfColumns == 1)
                    {
                        Console.WriteLine("Row={0}, Column={1}, Passanger={2}", mi, 1, counter);
                        ++counter;
                    }
                    else if (numberOfColumns > 1)
                    {
                        int col_index = 1;
                        while (col_index <= numberOfColumns && counter <= numberOfPassengers)
                        {
                            Console.WriteLine("Row={0}, Column={1}, Passanger={2}", mi, col_index, counter);
                            col_index++;
                            ++counter;
                        }
                    }
                }
            }
        }
    }
}

Console.WriteLine("Welcome to Airplane seat assignment algorithm!");

//Example input
Console.WriteLine("Displaying output for Example");
AssigenPassengerSeat(new int[,] { { 3, 2 }, { 4, 3 }, { 2, 3 }, { 3, 4 } }, 30);

//Question input
Console.WriteLine("Displaying output for Question");
AssigenPassengerSeat(new int[,] { { 3, 4 }, { 4, 5 }, { 2, 3 }, { 3, 4 } }, 30);
