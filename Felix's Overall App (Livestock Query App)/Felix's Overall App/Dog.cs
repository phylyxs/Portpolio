using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felix_s_Overall_App
{
    class Dog : Animal
    {
        public Dog(double amtOfWater, double dailyCost, double weight, int age, string colour) : base(amtOfWater, dailyCost, weight, age, colour)
        {
        }
        public override string displayFieldName()
        {
            string fieldName = string.Format("Amount of Water\r\nDaily Cost\r\nWeight\r\nAge\r\nColour");
            return fieldName;
        }
        public override string displayFieldData()
        {
            string fieldData = string.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}", amtOfWater, dailyCost, weight, age, colour);
            return fieldData;
        }
        public override string getType()
        {
            return "Dog";
        }
        public override double dailyRevenue()
        {
            return 0;
        }
        public override double dailyExpense()
        {
            return dailyCost + (amtOfWater * Price.waterPrice);
        }
        public override double dailyGovTax()
        {
            return 0; //dogs don't have tax
        }
    }
}
