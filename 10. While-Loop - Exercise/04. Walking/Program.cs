using System;

namespace _04._Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsGoal = 10000;
            string daySteps;
            int homeSteps = 0;
            int dayStepsTotal = 0;
            int stepsTotal = 0;

            while (stepsTotal < stepsGoal)
            {
                daySteps = Console.ReadLine();
                if (daySteps == "Going home")
                {
                    homeSteps = int.Parse(Console.ReadLine());
                    stepsTotal = homeSteps + dayStepsTotal;
                    break;
                }
                else
                {
                    dayStepsTotal += int.Parse(daySteps);
                }

                stepsTotal = homeSteps + dayStepsTotal;
            }

            if (stepsTotal >= stepsGoal)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{stepsTotal - stepsGoal} steps over the goal!");
            }
            else if (stepsTotal < stepsGoal)
            {
                Console.WriteLine($"{Math.Abs(stepsGoal - stepsTotal)} more steps to reach goal.");
            }
        }
    }
}
