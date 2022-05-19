using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] matrixSize = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = matrixSize[0];
            int cols = matrixSize[1];

            int[,] matrix = new int[rows, cols];

            int matrixSum = 0;

            for (int i = 0; i < rows; i++)
            {
                int[] inputArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = inputArr[j];

                }
            }

            for (int row = 0; row < cols; row++)
            {
                int elementSum = 0;
                for (int col = 0; col < rows; col++)
                {
                    elementSum += matrix[col, row];
                }

                Console.WriteLine(elementSum);
            }
        }
    }
}
