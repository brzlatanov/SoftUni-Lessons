using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppingList = new List<Topping>();
        private Dough dough;
        private double totalCalories;
        private int toppingsCount  => toppingList.Count;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
        }
        public string Name {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough
        {
            get
            {
                return this.dough;
            }
            set
            {
                this.dough = value;
                this.totalCalories += this.dough.CalculateCalories();
            }
        }

        public int ToppingsCount
        {
            get
            {
                return this.toppingsCount;
            }
        }

        public double TotalCalories
        {
            get
            {
                return this.totalCalories;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppingList.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            else
            {
                this.toppingList.Add(topping);
                this.totalCalories += topping.CalculateCalories();
            }
        }
    }
}
