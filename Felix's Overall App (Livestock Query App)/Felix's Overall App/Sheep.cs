using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felix_s_Overall_App
{
    class Sheep : Animal
    {
        public double amtOfWool;
        public Sheep(double amtOfWater, double dailyCost, double weight, int age, string colour, double amtOfWool) : base(amtOfWater, dailyCost, weight, age, colour)
        {
            this.amtOfWool = amtOfWool;
        }
        public override string displayFieldName()
        {
            string fieldName = string.Format("Amount of Water\r\nDaily Cost\r\nWeight\r\nAge\r\nColour\r\nAmount of Wool");
            return fieldName;
        }
        public override string displayFieldData()
        {
            string fieldData = string.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}\r\n{5}", amtOfWater, dailyCost, weight, age, colour, amtOfWool);
            return fieldData;
        }
        public override string getType()
        {
            return "Sheep";
        }
        public override double dailyRevenue()
        {
            return (amtOfWool * Price.sheep_WoolPrice / 365);
        }
    }
}
