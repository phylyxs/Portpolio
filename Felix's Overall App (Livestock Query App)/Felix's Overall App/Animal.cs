using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felix_s_Overall_App
{
    abstract class Animal
    {
        public double amtOfWater;
        public double dailyCost;
        public double weight;
        public int age;
        public string colour;
        //constructor
        public Animal(double amtOfWater, double dailyCost, double weight, int age, string colour)
        {
            this.amtOfWater = amtOfWater;
            this.dailyCost = dailyCost;
            this.weight = weight;
            this.age = age;
            this.colour = colour;
        }
        public virtual void printAll()
        {
            displayFieldName();
            displayFieldData();
        }
        public abstract string displayFieldName();
        public abstract string displayFieldData();
        public abstract string getType();
        public abstract double dailyRevenue();
        public virtual double dailyExpense()
        {
            return dailyCost + dailyGovTax() + (amtOfWater * Price.waterPrice);
        }
        public virtual double dailyProfit()
        {
            return dailyRevenue() - dailyExpense();
        }
        public virtual double dailyGovTax()
        {
            return weight * Price.govTax;
        }
    }
}
