using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] numberMatrix = new int[matrixSize, matrixSize];

            ReadMatrix(matrixSize, numberMatrix);

            int primaryDiagonalSum = 0;

            SumPrimaryDiagonal(matrixSize, primaryDiagonalSum, numberMatrix);
        }


        private static void SumPrimaryDiagonal(int matrixSize, int primaryDiagonalSum, int[,] numberMatrix)
        {
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = i; j == i; j++)
                {
                    primaryDiagonalSum += numberMatrix[i, j];
                }
            }

            Console.WriteLine(primaryDiagonalSum);
        }

        private static void ReadMatrix(int matrixSize, int[,] numberMatrix)
        {
            for (int i = 0; i < matrixSize; i++)
            {
                int[] fillArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int j = 0; j < matrixSize; j++)
                {
                    numberMatrix[i, j] = fillArray[j];
                }
            }
        }
    }
}
