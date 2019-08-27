using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProjectFromTheStart
{
    //Helper Class for the random number generated properties 
    class RandomNumbersMachine
    {
        //Field
        private static Random rng;

        //Static constructor
        static RandomNumbersMachine()
        {
            rng = new Random();
        }

        //Method for the Inialization of numbers list
        private static List<int> InitNumbersList(int start , int end)
        {
            var numbersList = new List<int>();
            for (int i = start; i <= end; i++)
            {
                numbersList.Add(i);
            }
            return numbersList;
        }
        //Method that gets you random generated numbers
        public static List<int> GenerateNumbers(int howMany,int start = 1,int end = 80)
        {
            var numbersList = InitNumbersList(start, end);
          
            var numbersOfTheDraw = new List<int>();

            for (int i = 1; i <= howMany; i++)
            {
                int randomNumber = numbersList[rng.Next(numbersList.Count)];
                numbersOfTheDraw.Add(randomNumber);
                numbersList.Remove(randomNumber);
            }
            return numbersOfTheDraw;
        }

        //Helping method for
        public static bool TossCoin()
        {
            return rng.Next() % 2 == 0;
        }
   
    }
}
