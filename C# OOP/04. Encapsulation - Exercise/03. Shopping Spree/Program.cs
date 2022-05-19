using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();
            List<Product> productList = new List<Product>();

            try
            {
                string[] personInput =
                Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < personInput.Length; i += 2)
            {
                string name = personInput[i];
                decimal money = decimal.Parse(personInput[i + 1]);
                Person person = new Person(name, money);

                personList.Add(person);
            }

            string[] productInput = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < productInput.Length; i += 2)
            {
                string name = productInput[i];
                decimal money = decimal.Parse(productInput[i + 1]);
                Product product = new Product(name, money);

                productList.Add(product);
            }

            string[] purchaseAction = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (purchaseAction[0] != "END")
            {
                string personName = purchaseAction[0];
                string itemName = purchaseAction[1];

                Person currentPerson = personList.Where(p => p.Name == personName).FirstOrDefault();
                Product currentProduct = productList.Where(p => p.Name == itemName).FirstOrDefault();

                if (currentPerson.Money >= currentProduct.Cost)
                {
                    currentPerson.BagOfProducts.Add(currentProduct);
                    currentPerson.Money -= currentProduct.Cost;
                    Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
                }
                else
                {
                    Console.WriteLine($"{currentPerson.Name} can't afford {currentProduct.Name}");
                }

                purchaseAction = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var person in personList)
            {
                if (person.BagOfProducts.Count <= 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.Write($"{person.Name} - ");
                    Console.Write(string.Join(", ", person.BagOfProducts) + Environment.NewLine);
                }
            }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
