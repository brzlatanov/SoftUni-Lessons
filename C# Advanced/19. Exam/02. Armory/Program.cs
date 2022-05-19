using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] armory = new char[matrixSize, matrixSize];

            int[] currentPosition = new int[2];
            List<int[]> mirrorPositions = new List<int[]>();
            for (int row = 0; row < matrixSize; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrixSize; col++)
                {
                    armory[row, col] = input[col];

                    if (armory[row, col] == 'A')
                    {
                        currentPosition[0] = row;
                        currentPosition[1] = col;
                    }
                    else if (armory[row, col] == 'M')
                    {
                        mirrorPositions.Add(new int[] { row, col });
                    }
                }
            }

            double pricePromised = 65;
            bool exitArmory = false;
            bool dealFulfilled = false;
            double currentPrice = 0;
            while (true)
            {
                string moveCommand = Console.ReadLine();
                if (moveCommand.ToUpper() == "UP")
                {
                    armory[currentPosition[0], currentPosition[1]] = '-';
                    if (currentPosition[0] - 1 < 0)
                    {
                        exitArmory = true;
                    }
                    else
                    {
                        currentPosition[0] = currentPosition[0] - 1;
                    }
                }
                else if (moveCommand.ToUpper() == "DOWN")
                {
                    armory[currentPosition[0], currentPosition[1]] = '-';
                    if (currentPosition[0] + 1 > matrixSize - 1)
                    {
                        exitArmory = true;
                    }
                    else
                    {
                        currentPosition[0] = currentPosition[0] + 1;
                    }
                }
                else if (moveCommand.ToUpper() == "LEFT")
                {
                    armory[currentPosition[0], currentPosition[1]] = '-';
                    if (currentPosition[1] - 1 < 0)
                    {
                        exitArmory = true;
                    }
                    else
                    {
                        currentPosition[1] = currentPosition[1] - 1;
                    }
                }
                else if (moveCommand.ToUpper() == "RIGHT")
                {
                    armory[currentPosition[0], currentPosition[1]] = '-';
                    if (currentPosition[1] + 1 > matrixSize - 1)
                    {
                        exitArmory = true;
                    }
                    else
                    {
                        currentPosition[1] = currentPosition[1] + 1;
                    }
                }

                if (exitArmory)
                {
                    Console.WriteLine("I do not need more swords!");
                    break;
                }
                else
                {
                    if (char.IsDigit(armory[currentPosition[0], currentPosition[1]]))
                    {
                        currentPrice += char.GetNumericValue(armory[currentPosition[0], currentPosition[1]]);
                    }
                    else if (armory[currentPosition[0], currentPosition[1]] == 'M')
                    {
                        int[] currentMirror = mirrorPositions.Find(m => m[0] == currentPosition[0] && m[1] == currentPosition[1]);
                        armory[currentPosition[0], currentPosition[1]] = '-';
                        mirrorPositions.Remove(currentMirror);
                        currentPosition = mirrorPositions[0];
                        armory[currentPosition[0], currentPosition[1]] = '-';
                    }

                    if (currentPrice >= pricePromised)
                    {
                        Console.WriteLine("Very nice swords, I will come back for more!");
                        armory[currentPosition[0], currentPosition[1]] = 'A';
                        break;
                    }
                }
            }

            Console.WriteLine($"The king paid {currentPrice} gold coins.");

            PrintMatrix(matrixSize, armory);
        }

        private static void PrintMatrix(int matrixSize, char[,] armory)
        {
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    Console.Write(armory[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
