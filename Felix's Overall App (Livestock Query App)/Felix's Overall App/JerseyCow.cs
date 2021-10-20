using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felix_s_Overall_App
{
    class JerseyCow : Cow
    {
        public JerseyCow(double amtOfWater, double dailyCost, double weight, int age, string colour, double amtOfMilk, bool isJersy) : base(amtOfWater, dailyCost, weight, age, colour, amtOfMilk, isJersy)
        {  
        }
        public override string getType()
        {
            return "Jersey Cow";
        }
        public override double dailyGovTax()
        {
            return weight * Price.jerseyCowTax;
        }
    }
}
