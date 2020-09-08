using System;
using System.Collections.Generic;
using System.Linq;

namespace Metoder2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SumOfArray(new List<int> { 1, 2, 3 }));
            Console.WriteLine(string.Join(",",ReveresedStringArray(new List<string> { "hej", "på", "dig" })));
            Console.WriteLine(GreaterAndLesserIntOfArray(new List<int> { 20,-1,50, 0, 2000, -5, 1 }));
        }

        

        private static int SumOfArray(List<int> intArray)
        {
            var sum = 0;
            for (int i = 0; i < intArray.Count; i++)
            {
                sum += intArray[i];
            }
            return sum;
        }

        private static List<string> ReveresedStringArray(List<string> stringArray)
        {
            for (int i = 0; i < stringArray.Count / 2; i++) //delar på två eftersom annars vändar man på arrayen igen
            {
                var temp = stringArray[i];
                stringArray[i] = stringArray[stringArray.Count - i - 1];
                stringArray[stringArray.Count - i - 1] = temp;
                
            }
            return stringArray;
        }

        private static string GreaterAndLesserIntOfArray(List<int> intArray)
        {
            var highest = 0;
            var lowest = 0;
            for (int i = 0; i < intArray.Count - 1; i++)
            {
                for (int j = 0; j < intArray.Count; j++)
                {
                    if (intArray[j] > intArray[i + 1])
                    {
                        highest = intArray[j];
                    }
                    if (intArray[j] < intArray[i + 1])
                    {
                        lowest = intArray[j];
                    }
                }
            }
            return "Highest: " + highest + "\nLowest: " + lowest; 
        }
        
            
        
    }
}
