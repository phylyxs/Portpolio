using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Felix_s_Overall_App
{
    class initReadDB
    {
        public static void readDBAnimals(OleDbCommand cmd, string type, Dictionary<int, Animal> farm)
        {
            using (OleDbDataReader reader = cmd.ExecuteReader()) //run the query 
            {
                while (reader.Read()) //reading the query 
                {
                    int ID = 0; double amtOfWater = 0; double dailyCost = 0; double weight = 0; int age = 0;
                    string colour = ""; double amtOfMilk = 0; bool isJersy = false; double amtOfWool = 0;

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string fieldName = reader.GetName(i).ToLower();
                        string data = reader.GetValue(i).ToString();
                        if (fieldName == "id") { ID = Int32.Parse(data); continue; }
                        if (fieldName == "amount of water") { amtOfWater = Double.Parse(data); continue; }
                        if (fieldName == "daily cost") { dailyCost = Double.Parse(data); continue; }
                        if (fieldName == "weight") { weight = Double.Parse(data); continue; }
                        if (fieldName == "age") { age = Int32.Parse(data); continue; }
                        if (fieldName == "color") { colour = data; continue; }
                        if (fieldName == "amount of milk") { amtOfMilk = Double.Parse(data); continue; }
                        if (fieldName == "is jersy") { isJersy = bool.Parse(data); continue; }
                        if (fieldName == "amount of wool") { amtOfWool = Double.Parse(data); }
                    }

                    //1.) Read and add to dictionary
                    //2.) While reading, accummulate totalDailyMilk for Cows and Goats.
                    //3.) While reading, accummulate totalCost for all animals
                    //4.) While reading, count the number of animals per type.
                    switch (type)
                    {
                        case "cows":
                            if (isJersy)
                            {
                                farm.Add(ID, new JerseyCow(amtOfWater, dailyCost, weight, age, colour, amtOfMilk, isJersy));
                                Price.totalDailyMilk += amtOfMilk;
                                Price.totalCost += dailyCost;
                                Price.jerseyCowCount++;
                            }
                            else
                            {
                                farm.Add(ID, new Cow(amtOfWater, dailyCost, weight, age, colour, amtOfMilk, isJersy));
                                Price.totalDailyMilk += amtOfMilk;
                                Price.totalCost += dailyCost;
                                Price.cowCount++;
                            }
                            break;

                        case "goats":
                            farm.Add(ID, new Goat(amtOfWater, dailyCost, weight, age, colour, amtOfMilk));
                            Price.totalDailyMilk += amtOfMilk;
                            Price.totalCost += dailyCost;
                            Price.goatCount++;
                            break;

                        case "sheep":
                            farm.Add(ID, new Sheep(amtOfWater, dailyCost, weight, age, colour, amtOfWool));
                            Price.totalCost += dailyCost;
                            Price.sheepCount++;
                            break;

                        case "dogs":
                            farm.Add(ID, new Dog(amtOfWater, dailyCost, weight, age, colour));
                            Price.totalCost += dailyCost;
                            Price.dogCount++;
                            break;
                    }
                    Price.numberOfAnimals++;
                }
            }
        }

        public static Dictionary<int, Animal> turnToDictionary()
        {
            Dictionary<int, Animal> farm = new Dictionary<int, Animal>();

            String ConnStr = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 
                            C:\Users\MD HAMAD AIMAN\Desktop\Felix's Files\Year 2\Semester 2\Application Development\Felix's Overall App\FarmInfomation.accdb; 
                            Persist Security Info = False";

            string[] typesOfAnimals = new string[] { "cows", "dogs", "goats", "sheep" };
            foreach (string type in typesOfAnimals) //to 'select' query for all animals.
            {
                String q = "select * from [" + type + "]"; //putting square brackets, allows special chars in table name.
                using (OleDbConnection conn = new OleDbConnection(ConnStr)) //init connection to file path.
                {
                    OleDbCommand cmd = new OleDbCommand(q, conn); //run query with the connection
                    conn.Open();
                    readDBAnimals(cmd, type, farm);
                    conn.Close();
                }
            }

            return farm;
        }

        public static void readDBPrices()
        {
            String ConnStr = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 
                            C:\Users\MD HAMAD AIMAN\Desktop\Felix's Files\Year 2\Semester 2\Application Development\Felix's Overall App\FarmInfomation.accdb; 
                            Persist Security Info = False";
            string tableName = "Commodity Prices";
            String q = "select * from [" + tableName + "]";
            using (OleDbConnection conn = new OleDbConnection(ConnStr)) //init connection to file path.
            {
                OleDbCommand cmd = new OleDbCommand(q, conn); //run query with the connection
                conn.Open();
                using (OleDbDataReader reader = cmd.ExecuteReader()) //run the query 
                {
                    while (reader.Read()) //reading the query 
                    {
                        string commodity = reader.GetValue(0).ToString();
                        double price = Double.Parse(reader.GetValue(1).ToString());
                        switch (commodity)
                        {
                            case "Goat milk price":
                                Price.goat_MilkPrice = price;
                                break;

                            case "Sheep wool price":
                                Price.sheep_WoolPrice = price;
                                break;

                            case "Water price":
                                Price.waterPrice = price;
                                break;

                            case "Government tax per kg":
                                Price.govTax = price;
                                break;

                            case "Jersy cow tax":
                                Price.jerseyCowTax = price;
                                break;

                            case "Cow milk price":
                                Price.cow_MilkPrice = price;
                                break;
                        }
                    }
                }
                conn.Close();
            }
        }
    }
}
