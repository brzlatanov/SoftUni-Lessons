using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] charMatrix = new char[matrixSize, matrixSize];

            ReadMatrix(matrixSize, charMatrix);

            char symbol = char.Parse(Console.ReadLine());
            bool charFound = false;

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (charMatrix[i, j] == symbol)
                    {
                        Console.WriteLine($"({i}, {j})");
                        charFound = true;
                        return;
                    }
                }
            }

            if (!charFound)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }


        private static void ReadMatrix(int matrixSize, char[,] charMatrix)
        {
            for (int i = 0; i < matrixSize; i++)
            {
                string fillArray = Console.ReadLine();

                for (int j = 0; j < matrixSize; j++)
                {
                    charMatrix[i, j] = fillArray[j];
                }
            }
        }
    }
}
