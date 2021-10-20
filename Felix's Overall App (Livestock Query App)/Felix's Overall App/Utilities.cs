using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felix_s_Overall_App
{
    class Utilities
    {
        public static List<dynamic[]> QuickSort(List<dynamic[]> animalList, int start, int end)
        {
            if (start < end)
            {
                int pivot = partition(animalList, start, end);
                QuickSort(animalList, start, pivot);
                QuickSort(animalList, pivot + 1, end);
            }
            return animalList;
        }
        public static void Swap(List<dynamic[]> animalList, int i, int j)
        {
            dynamic[] temp = animalList[i];
            animalList[i] = animalList[j];
            animalList[j] = temp;
        }
        public static int partition(List<dynamic[]> animalList, int start, int end)
        {
            double pivot = animalList[start][1];         
            int swapIndex = start;                  
            for (int i = start + 1; i < end; i++)   
            {                                       
                if (animalList[i][1] < pivot)
                {
                    swapIndex++;
                    Swap(animalList, i, swapIndex);
                }
            }                                       
            Swap(animalList, start, swapIndex);            
            return swapIndex;                       
        }
        public static bool isInteger(string text)
        {
            int num;
            bool isInteger = int.TryParse(text, out num);
            return isInteger;
        }
        public static bool isDouble(string text)
        {
            double num;
            bool isDouble = double.TryParse(text, out num);
            return isDouble;
        }
        public static double GCD(double a, double b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }
            if (a == 0)
                return b;
            else
                return a;
        }
        public static string ratio(double num1, double num2)
        {
            var gcd = GCD(num1, num2);
            string ratio = string.Format("{0}:{1}", num1 / gcd, num2 / gcd);
            return ratio;
        }
    }
}
