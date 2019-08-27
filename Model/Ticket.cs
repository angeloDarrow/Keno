using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProjectFromTheStart
{
    class Ticket
    {
        //Properties
        public int ID { get; private set; }
        public List<int> NumbersPlayed { get; private set; }
        public bool KinoBonusOption { get; private set; }
        public List<int> NumbersWon { get; private set; }
        public int NumbersWonOutOfPlayed
        {
            get
            {
                return NumbersWon.Count();
            }
        }

        //Constructor
        public Ticket(int id, bool kinoBonusOption)
        {
            ID = id;
            NumbersPlayed = new List<int>();
            KinoBonusOption = kinoBonusOption;
            NumbersWon = new List<int>();         
        }

        //Method that add the numbers to the ticket
        public void AddNumberPlayed(int number)
        {         
            NumbersPlayed.Add(number);
        }

        //Method that finds the numbers that win
        public void SetWonNumbers(List<int> luckyNumbers)
        {
            if (luckyNumbers == null)
                throw new ArgumentNullException("luckyNumbers");

            foreach (var numberPlayed in NumbersPlayed)
            {
                if (luckyNumbers.Contains(numberPlayed))
                {
                    NumbersWon.Add(numberPlayed);
                }
            }
        }



    }
}
