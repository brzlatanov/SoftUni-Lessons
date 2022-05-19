using System;
using System.Linq;

namespace TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialArmor = int.Parse(Console.ReadLine());

            int rows = int.Parse(Console.ReadLine());

            char[][] matrix = new char[rows][];

            int[] currentPosition = new int[2];

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();
                char[] inputArr = new char[input.Length];

                for (int i = 0; i < input.Length; i++)
                {
                    inputArr[i] = input[i];
                    if (input[i] == 'A')
                    {
                        currentPosition[0] = row;
                        currentPosition[1] = i;
                    }
                }

                matrix[row] = inputArr;
            }

            while (true)
            {
                if (initialArmor <= 0)
                {
                    matrix[currentPosition[0]][currentPosition[1]] = 'X';
                    Console.WriteLine($"The army was defeated at {currentPosition[0]};{currentPosition[1]}.");
                    break;
                }

                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = command[0];
                int spawnRow = int.Parse(command[1]);
                int spawnCol = int.Parse(command[2]);

                matrix[spawnRow][spawnCol] = 'O';

                if (direction == "up") // up
                {
                    initialArmor--;
                    if (currentPosition[0] - 1 >= 0)
                    {
                        matrix[currentPosition[0]][currentPosition[1]] = '-';


                        currentPosition[0] = currentPosition[0] - 1;
                    }

                }
                else if (direction == "down")
                {
                    initialArmor--;
                    if (currentPosition[0] + 1 < matrix.GetLength(0))
                    {

                        matrix[currentPosition[0]][currentPosition[1]] = '-';

                        currentPosition[0] = currentPosition[0] + 1;
                    }

                }
                else if (direction == "left")
                {
                    initialArmor--;
                    if (currentPosition[1] - 1 >= 0)
                    {

                        matrix[currentPosition[0]][currentPosition[1]] = '-';


                        currentPosition[1] = currentPosition[1] - 1;
                    }
                }
                else if (direction == "right")
                {
                    initialArmor--;
                    if (currentPosition[1] + 1 < matrix[currentPosition[0]].Length)
                    {

                        matrix[currentPosition[0]][currentPosition[1]] = '-';


                        currentPosition[1] = currentPosition[1] + 1;
                    }

                }

                if (matrix[currentPosition[0]][currentPosition[1]] == 'O')
                {
                    initialArmor -= 2;
                    if (initialArmor > 0)
                    {
                        matrix[currentPosition[0]][currentPosition[1]] = '-';
                    }
                    else
                    {
                        matrix[currentPosition[0]][currentPosition[1]] = 'X';
                        Console.WriteLine(
                            $"The army was defeated at {currentPosition[0]};{currentPosition[1]}.");
                        break;
                    }
                }

                else if (matrix[currentPosition[0]][currentPosition[1]] == 'M')
                {
                    matrix[currentPosition[0]][currentPosition[1]] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {initialArmor}");
                    break;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine(string.Join("", matrix[row]));
            }
        }
    }
}
