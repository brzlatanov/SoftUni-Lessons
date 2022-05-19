using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int tempSize = size;

            int[,] matrix = new int[size, size];

            int matrixSum1 = 0;
            int matrixSum2 = 0;

            matrixSum1 = FillMatrix(size, matrix, matrixSum1);

            matrixSum2 = SecondMatrixDiagonal(size, matrix, matrixSum2, tempSize);

            Console.WriteLine(Math.Abs(matrixSum1 - matrixSum2));
        }

        private static int SecondMatrixDiagonal(int size, int[,] matrix, int matrixSum2, int tempSize)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = tempSize - 1 - row; ; tempSize--)
                {
                    matrixSum2 += matrix[row, col];
                    break;
                }
            }

            return matrixSum2;
        }

        private static int FillMatrix(int size, int[,] matrix, int matrixSum1)
        {
            for (int row = 0; row < size; row++)
            {

                int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = arr[col];
                }
                matrixSum1 += matrix[row, row];
            }

            return matrixSum1;
        }
        private static int[] ReadArrayFromConsole()
        {
            return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
    }
}
