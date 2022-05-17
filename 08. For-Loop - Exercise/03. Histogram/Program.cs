using System;

namespace _03._Histogram
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int n2Capture = 0;
            double p1 = 0.0;
            double p2 = 0.0;
            double p3 = 0.0;
            double p4 = 0.0;
            double p5 = 0.0;

            for (int i = 0; i < n; i++)
            {
                int n2 = int.Parse(Console.ReadLine());
                n2Capture = n2;

                if (n2Capture < 200)
                {
                    p1++;
                }
                else if (n2Capture >= 200 && n2Capture <= 399)
                {
                    p2++;
                }
                else if (n2Capture >= 400 && n2Capture <= 599)
                {
                    p3++;
                }
                else if (n2Capture >= 600 && n2Capture <= 799)
                {
                    p4++;
                }
                else if (n2Capture >= 800)
                {
                    p5++;
                }
            }


            Console.WriteLine($"{(p1 / n * 100):F2}%");
            Console.WriteLine($"{(p2 / n * 100):F2}%");
            Console.WriteLine($"{(p3 / n * 100):F2}%");
            Console.WriteLine($"{(p4 / n * 100):F2}%");
            Console.WriteLine($"{(p5 / n * 100):F2}%");
        }
    }
}
