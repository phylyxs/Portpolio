using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Felix_s_Overall_App
{
    public partial class outputType : Form
    {
        Dictionary<int, Animal> myFarm;//global variable
        public outputType()
        {
            InitializeComponent();
            this.Text = "Livestock Query App";
            //Automatically read database as soon as it runs
            myFarm = initReadDB.turnToDictionary();
            initReadDB.readDBPrices();
        }
        private bool isReportNoValid(string text)
        {
            if (Utilities.isInteger(text))
            {
                int num = Int32.Parse(text);
                if (num >= 2 && num <= 12)
                {
                    return true;
                }
            }
            return false;
        }
        private bool isIDFound(string inputID)
        {
            if (!Utilities.isInteger(inputID))
            {
                MessageBox.Show("Error: ID invalid. Must be 4-digit integer.");
                return false;
            }

            int id = Int32.Parse(inputID);
            if (!myFarm.ContainsKey(id))
            {
                MessageBox.Show("Error: ID not found. Try Again.");
                return false;
            }

            return true;
        }
        private double calcDailyTotalProfit(string type, bool isAllAnimal)
        {
            double totalProfit = 0;
            if (isAllAnimal) //for ALL animals
            {
                foreach (KeyValuePair<int, Animal> animal in myFarm)
                {
                    totalProfit += animal.Value.dailyProfit();
                }
            }
            else //for 1 type of animal ONLY
            {
                foreach (KeyValuePair<int, Animal> animal in myFarm)
                {
                    if (animal.Value.getType() == type)
                    {
                        totalProfit += animal.Value.dailyProfit();
                    } 
                }
            }
            totalProfit = Math.Round(totalProfit, 2);
            return totalProfit;
        }

        private double calcDailyGovTax(string type, bool isAllAnimal)
        {
            double totalDailyGovTax = 0.0;
            if (isAllAnimal) //for ALL animals
            {
                foreach (KeyValuePair<int, Animal> animal in myFarm)
                {
                    totalDailyGovTax += animal.Value.dailyGovTax();
                }
            }
            else //for 1 type of animal ONLY
            {
                foreach (KeyValuePair<int, Animal> animal in myFarm)
                {
                    if (animal.Value.getType() == type)
                    {
                        totalDailyGovTax += animal.Value.dailyGovTax();
                    }
                }
            }          
            return totalDailyGovTax;
        }
        private double calcMonthlyGovTax(string type, bool isAllAnimal)
        {
            double totalMonthlyGovTax = 30 * calcDailyGovTax(type, isAllAnimal);
            totalMonthlyGovTax = Math.Round(totalMonthlyGovTax, 2);
            return totalMonthlyGovTax;
        }
        private double calcAvgAge() //since there is animalCount()...i might need to change this as well
        {
            double totalAge = 0.0;
            double avgAge = 0.0;
            int animalCount = Price.numberOfAnimals - Price.dogCount; //since all except dog.
            foreach (KeyValuePair<int, Animal> animal in myFarm)
            {
                if (animal.Value.getType() == "Dog")
                {
                    continue;
                }
                totalAge += animal.Value.age;
            }
            avgAge = totalAge / animalCount;
            avgAge = Math.Round(avgAge, 2);

            return avgAge;
        }
        private int animalCount(string type, bool isAllAnimal)
        {
            int num = 0;
            if (isAllAnimal) 
            {
                num = Price.numberOfAnimals;
                return num;
            }

            switch (type)
            {
                case "Cow":
                    num = Price.cowCount;
                    break;
                case "Jersey Cow":
                    num = Price.jerseyCowCount;
                    break;
                case "Goat":
                    num = Price.goatCount;
                    break;
                case "Sheep":
                    num = Price.sheepCount;
                    break;
                case "Dog":
                    num = Price.dogCount;
                    break;
            }
            return num;
        }
        private double calcAvgProfit(string type, bool isAllAnimal)
        {
            double avgProfit = 0.0;
            avgProfit = calcDailyTotalProfit(type, isAllAnimal) / animalCount(type, isAllAnimal);
            return avgProfit;
        }
        private double calcTotalCost(string type)
        {
            double totalCostPerAnimal = 0.0;
            foreach (KeyValuePair<int, Animal> animal in myFarm)
            {
                if (animal.Value.getType() == type)
                {
                    totalCostPerAnimal += animal.Value.dailyCost;
                }
            }
            return totalCostPerAnimal;
        }
        public int countColour(string colour)
        {
            int numberofColour = 0;
            foreach (KeyValuePair<int, Animal> animal in myFarm)
            {
                if (animal.Value.colour == colour)
                {
                    numberofColour++;
                }
            }
            return numberofColour;
        }
        public int countAge(int age)
        {
            int numberOfAge = 0;
            foreach (KeyValuePair<int, Animal> animal in myFarm)
            {
                if (animal.Value.age > age)
                {
                    numberOfAge++;
                }
            }
            return numberOfAge;
        }

        public List<dynamic[]> ID_ProfitList()
        {
            List<dynamic[]> animalList = new List<dynamic[]>();
            foreach (KeyValuePair<int, Animal> animal in myFarm)
            {
                //According to report 8, dogs are excluded.
                if(animal.Value.getType() == "Dog")
                {
                    continue;
                }
                int ID = animal.Key;
                double dailyProfit = animal.Value.dailyProfit();
                animalList.Add(new dynamic[] {ID, dailyProfit});
            }
            return animalList;
        }
        private void report1Table_TextChanged(object sender, EventArgs e)
        {

        }

        private void enterID_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }       
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void showReport1_Click(object sender, EventArgs e)
        {
            report1();
        }
        private void report1()
        {
            typeOfAnimal.Clear();
            fieldNameCol.Clear();
            dataCol.Clear();

            if (isIDFound(enterID.Text))
            {
                int id = Int32.Parse(enterID.Text);
                Animal animal = myFarm[id];
                fieldNameCol.Text = animal.displayFieldName();
                dataCol.Text = animal.displayFieldData();
                typeOfAnimal.Text = animal.getType();
            }
            else
            {
                fieldNameCol.Text = "Error!";
            }
        }
        private void report2(String type, bool isAllAnimal)
        {
            displayReport.Text = "$ " + calcDailyTotalProfit(type, isAllAnimal).ToString();
        }
        private void report3(String type, bool isAllAnimal)
        {
            displayReport.Text = "$ " + calcMonthlyGovTax(type, isAllAnimal).ToString();
        }

        private void report4()
        {
            displayReport.Text = Price.totalDailyMilk.ToString() + " litres";
            
        }
        private void report5()
        {
            displayReport.Text = calcAvgAge().ToString() + " y/o";
        }
        private void report6()
        {
            double cowTotalProfit = calcDailyTotalProfit("Cow", false);
            double jerseyCowTotalProfit = calcDailyTotalProfit("Jersey Cow", false);
            double goatTotalProfit = calcDailyTotalProfit("Goat", false);
            double cowGoatCount = Price.cowCount + Price.jerseyCowCount + Price.goatCount;
            //calculate the average profitability of "Goats and Cow"
            double cowGoatAvgProfit = (cowTotalProfit + jerseyCowTotalProfit + goatTotalProfit) / cowGoatCount;
            //calculatte the average profitability of "Sheep"
            double sheepAvgProfit = calcAvgProfit("Sheep", false);
            string report = string.Format("Goats and Cow: {0}\r\nSheep: {1}", Math.Round(cowGoatAvgProfit,2), Math.Round(sheepAvgProfit,2));

            displayReport.Text = report;
        }
        private void report7(string type)
        {
            double typeTotalCost = calcTotalCost(type);
            string title = string.Format(type + "'s Total Cost : {0}\r\nTotal Cost: {1}", typeTotalCost, Price.totalCost);
            //turn it into ratio (dog cost : all animal cost)
            string report = string.Format("Ratio: {0}", Utilities.ratio(typeTotalCost, Price.totalCost));
            displayReport.Text = title + "\r\n" + report;
        }
        private void report8()
        {
            List<dynamic[]> animalList = ID_ProfitList();
            //sorts the animalList based in daily profit in ascending order
            Utilities.QuickSort(animalList, 0, animalList.Count());
            String report = string.Format("{0,-15} {1,-10}\r\n", "ID", "Daily Profit");
            foreach (dynamic[] animalData in animalList)
            {
                report += string.Format("{0,-15} {1,-10}\r\n", animalData[0], Math.Round(animalData[1], 2));
            }

            //write into text file
            try
            {
                var path = @"C:\Users\MD HAMAD AIMAN\Desktop\Felix's Files\Year 2\Semester 2\Application Development\Felix's Overall App\report8.txt";
                File.WriteAllText(path, report);
                
            }
            catch(Exception ex)
            {
                report = ex.Message;
            }

            displayReport.Text = report;

        }

        private void report9(string colour)
        {
            int colourCount = countColour(colour);
            string title = string.Format(colour + "'s Count : {0}\r\nNumber of Animals: {1}", colourCount, Price.numberOfAnimals);
            //turn it into ratio (1 colour : all colours)
            string report = string.Format("Ratio: {0}", Utilities.ratio(colourCount, Price.numberOfAnimals));
            displayReport.Text = title + "\r\n" + report;
        }
        private void report10(string type, bool isAllAnimal)
        {
            double animalTotalDailyGovTax = calcDailyGovTax(type, isAllAnimal);
            displayReport.Text = "$ " + animalTotalDailyGovTax.ToString();
        }
        private bool isAgeThresholdValid()
        {
            if (!Utilities.isInteger(ageThreshold.Text))
            {
                MessageBox.Show("Error: Please input the age threshold.");
                displayReport.Text = "Error: Please input the age threshold.";
                return false;
            }
            int ageThresholdYrs = Int32.Parse(ageThreshold.Text);
            if (ageThresholdYrs < 0)
            {
                displayReport.Text = "Error: Age threshold must be >= 0";
                return false;
            }
            return true;
        }
        private void report11()
        {
            if (!isAgeThresholdValid())
            {
                return;
            }
            int ageThresholdYrs = Int32.Parse(ageThreshold.Text);
            int ageCount = countAge(ageThresholdYrs);
            string title = string.Format("Age above threshold count : {0}\r\nNumber of Animals: {1}", ageCount, Price.numberOfAnimals);
            string report = string.Format("Ratio: {0}", Utilities.ratio(ageCount, Price.numberOfAnimals));
            displayReport.Text = title + "\r\n" + report;
        }
        private void report12(string type, bool isAllAnimal)
        {
            double animalTotalProfit = calcDailyTotalProfit(type, isAllAnimal);
            displayReport.Text = "$ " + animalTotalProfit.ToString();
        }

        private void displayReportNo_Click(object sender, EventArgs e)
        {
            if (!isReportNoValid(reportNo.Text))
            {
                MessageBox.Show("Error: Must be in between 2 to 12. Try Again.");
                displayReport.Text = "Error! Try Again.";
                return;
            }
            int reportNum = Int32.Parse(reportNo.Text);
            switch (reportNum)
            {
                case 2:
                    report2("All animals", true);
                    break;
                case 3:
                    report3("All animals", true);
                    break;
                case 4:
                    report4();
                    break;
                case 5:
                    report5();
                    break;
                case 6:
                    report6();
                    break;
                case 7:
                    report7("Dog");
                    break;
                case 8:
                    report8();
                    break;
                case 9:
                    report9("Red");
                    break;
                case 10:
                    report10("Jersey Cow", false);
                    break;
                case 11:
                    report11();
                    break;
                case 12:
                    report12("Jersey Cow", false);
                    break;
            }
        }
    }
}
