using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Felix_s_Overall_App
{
    class Cow : Animal
    {
        public double amtOfMilk;
        public bool isJersy;
        public Cow(double amtOfWater, double dailyCost, double weight, int age, string colour, double amtOfMilk, bool isJersy) : base(amtOfWater, dailyCost, weight, age, colour)
        {
            this.amtOfMilk = amtOfMilk;
            this.isJersy = isJersy;
        }
        public override string displayFieldName()
        {
            string fieldName = string.Format("Amount of Water\r\nDaily Cost\r\nWeight\r\nAge\r\nColour\r\nAmount of Milk\r\nisJersy");
            return fieldName;
        }
        public override string displayFieldData()
        {
            string fieldData = string.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}\r\n{5}\r\n{6}", amtOfWater, dailyCost, weight, age, colour, amtOfMilk, isJersy);
            return fieldData;
        }
        public override string getType()
        {
            return "Cow";
        }
        public override double dailyRevenue()
        {
            return amtOfMilk * Price.cow_MilkPrice;
        }
    }
}
