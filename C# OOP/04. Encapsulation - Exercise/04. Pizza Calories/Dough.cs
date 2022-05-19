using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Dough
    {
        private Dictionary<string, double> flourTypeList = new Dictionary<string, double> { { "WHITE", 1.5 }, { "WHOLEGRAIN", 1.0 } };
        private Dictionary<string, double> bakingTechniqueList = new Dictionary<string, double>{{"CRISPY", 0.9}, { "CHEWY", 1.1 }, { "HOMEMADE", 1.0 } };

        private KeyValuePair<string, double> flourType = new KeyValuePair<string, double>();

        private KeyValuePair<string, double> bakingTechnique = new KeyValuePair<string, double>();
     
        private double grams;
        private double caloriesPerGram = 2;
        private double totalCalories;

        public Dough()
        {

        }
        public Dough(string flourType, string bakingTechnique, int grams)
        {
            this.FlourType = flourTypeList.Where(f => f.Key.ToString() == flourType.ToUpper()).FirstOrDefault();
            this.BakingTechnique = bakingTechniqueList.Where(b => b.Key.ToString() == bakingTechnique.ToUpper()).FirstOrDefault();
            this.Grams = grams;
        }

        public double CaloriesPerGram
        {
            get
            {
                return this.caloriesPerGram;
            }
        }

        private KeyValuePair<string, double> FlourType
        {
            get
            {
                return this.flourType;
            }
            set
            {
                if (value.Key == null)
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }
        private KeyValuePair<string, double> BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            set
            {
                if (value.Key == null)
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
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
                if (value <= 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range[1..200].");
                }

                this.grams = value;
            }
        }

        public double CalculateCalories()
        {
            this.totalCalories = (this.caloriesPerGram* this.grams) * this.flourType.Value * this.bakingTechnique.Value;
            return this.totalCalories;
        }
    }
}