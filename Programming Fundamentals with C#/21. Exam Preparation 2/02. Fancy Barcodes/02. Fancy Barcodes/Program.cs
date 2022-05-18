using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string barcodeRegex = @"@#+(?<product>[A-Z][A-Za-z0-9]{4,}[A-Z])@#+";

            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();
                Match match = Regex.Match(barcode, barcodeRegex);

                if (match.Success)
                {
                    bool digitFound = false;
                    string productGroup = "";

                    for (int j = 0; j < barcode.Length; j++)
                    {
                        if (Char.IsDigit(barcode[j]))
                        {
                            productGroup += barcode[j];
                            digitFound = true;
                        }
                    }

                    if (!digitFound)
                    {
                        productGroup = "00";
                    }

                    Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
