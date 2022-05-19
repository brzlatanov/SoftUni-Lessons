using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private Dictionary<string, double> toppingTypes = new Dictionary<string, double>
            {{"MEAT", 1.2}, {"VEGGIES", 0.8}, {"CHEESE", 1.1}, {"SAUCE", 0.9}};

        private KeyValuePair<string, double> toppingType = new KeyValuePair<string, double>();

        private double grams;
        public double caloriesPerGram { get; } = 2;

        public Topping(string toppingType, double grams)
        {

            if (!this.toppingTypes.ContainsKey(toppingType.ToUpper()))
            {
                this.ToppingType = new KeyValuePair<string, double>(toppingType, 0);
            }

            this.ToppingType = this.toppingTypes.Where(t => t.Key.ToString() == toppingType.ToUpper()).FirstOrDefault();
            this.Grams = grams;
            this.caloriesPerGram = this.ToppingType.Value;
        }

        private KeyValuePair<string, double> ToppingType
        {
            get
            {
                return this.toppingType;
            }
            set
            {
                if (!this.toppingTypes.ContainsKey(value.Key.ToString()))
                {
                    throw new ArgumentException($"Cannot place {value.Key.ToString()} on top of your pizza.");
                }

                this.toppingType = value;
            }
        }

        private double Grams
        {
            get
            {
                return this.grams;
            }
            set
            {
                if (value <= 0 || value > 50)
                {
                    string currentTopping = this.toppingType.Key.ToString();
                    StringBuilder sb = new StringBuilder(currentTopping);
                    for (int i = 1; i < sb.Length; i++)
                    {
                        sb[i] = char.ToLower(sb[i]);
                    }
                    throw new ArgumentException(
                        $"{sb} weight should be in the range [1..50].");
                }

                this.grams = value;
            }
        }

        public double CalculateCalories()
        {
            return 2 * this.caloriesPerGram * this.Grams;
        }

    }
}