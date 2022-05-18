using System;

namespace _01._Bonus_Scoring_System
{
    class Program
    {
        static void Main(string[] args)
        {
            double students = double.Parse(Console.ReadLine());
            double lectures = double.Parse(Console.ReadLine());
            double initialBonus = double.Parse(Console.ReadLine());

            double attendance = 0;
            double attendanceMax = 0;
            double attendanceSum = 0;

            if (students <= 0 || lectures <= 0)
            {
                Console.WriteLine($"Max Bonus: 0.");
                Console.WriteLine($"The student has attended 0 lectures.");

                return;
            }

            for (int i = 0; i < students; i++)
            {
                attendance = double.Parse(Console.ReadLine());

                if (attendance > attendanceMax)
                {
                    attendanceMax = attendance;
                }

                attendanceSum += attendance;
            }

            double maxBonus = (attendanceMax / lectures) * (5 + initialBonus);

            Console.WriteLine($"Max Bonus: {Math.Round(maxBonus)}.");
            Console.WriteLine($"The student has attended {attendanceMax} lectures.");
        }
    }
}
