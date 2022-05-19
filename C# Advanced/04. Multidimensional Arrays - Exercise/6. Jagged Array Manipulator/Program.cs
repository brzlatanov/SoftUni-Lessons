using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n <= 0)
            {
                return;
            }

            double[][] jagged = new double[n][];

            for (int i = 0; i < n; i++)
            {
                jagged[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            }

            for (int i = 0; i < n - 1; i++)
            {
                if (jagged[i].Length == jagged[i + 1].Length)
                {
                    for (int j = 0; j < jagged[i].Length; j++)
                    {
                        jagged[i][j] *= 2;
                        jagged[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < jagged[i].Length; j++)
                    {
                        jagged[i][j] /= 2;

                    }
                    for (int k = 0; k < jagged[i + 1].Length; k++)
                    {
                        jagged[i + 1][k] /= 2;
                    }
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "End")
                {
                    break;
                }

                int row = int.Parse(command[1]);
                int column = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (row > jagged.Length - 1 || row < 0 || column > jagged[row].Length - 1 || column < 0)
                {
                    continue;
                }

                if (command[0] == "Add") //"Add {row} {column} {value}"
                {
                    jagged[row][column] += value;
                }
                else if (command[0] == "Subtract") // Subtract {row} {column} {value}
                {
                    jagged[row][column] -= value;
                }

            }

            for (int i = 0; i < jagged.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jagged[i]));
            }
        }
    }
}
