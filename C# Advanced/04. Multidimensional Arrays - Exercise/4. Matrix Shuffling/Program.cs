using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            string[,] matrix = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = arr[j];
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                string keyword = command[0];

                if (keyword == "END")
                {
                    break;
                }

                if (keyword != "swap" || command.Length != 5 || int.Parse(command[1]) > matrix.GetLength(0) - 1 || int.Parse(command[1]) < 0 || int.Parse(command[2]) > matrix.GetLength(1) || int.Parse(command[2]) < 0 || int.Parse(command[3]) > matrix.GetLength(0) - 1 || int.Parse(command[3]) < 0 || int.Parse(command[3]) > matrix.GetLength(1) - 1 || int.Parse(command[3]) < 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int row1 = int.Parse(command[1]);
                int col1 = int.Parse(command[2]);
                int row2 = int.Parse(command[3]);
                int col2 = int.Parse(command[4]);

                string tempvalue1 = matrix[row1, col1];
                string tempvalue2 = matrix[row2, col2];

                matrix[row1, col1] = tempvalue2;
                matrix[row2, col2] = tempvalue1;

                for (int printRows = 0; printRows < matrix.GetLength(0); printRows++)
                {
                    for (int printCols = 0; printCols < matrix.GetLength(1); printCols++)
                    {
                        Console.Write(matrix[printRows, printCols] + " ");
                    }
                    Console.Write("\n");
                }
            }
        }
    }
}
