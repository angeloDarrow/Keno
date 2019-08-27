using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProjectFromTheStart
{
    class Selection
    {
        //Properties
        public int NumberOfWinners { get; private set; }
        public decimal AmmountPayable { get; private set; }
        public decimal AmmountPaid { get; private set; }
        public SelectionCategory SelectionCategory { get; private set; }

        //Constructor
        public Selection(int numberOfWinners, decimal ammountPayable, SelectionCategory selectionCategory)
        {
            NumberOfWinners = numberOfWinners;
            AmmountPayable = ammountPayable;
            AmmountPaid = 0;
            SelectionCategory = selectionCategory;
        }

        //Method that bumps the number of winners in the Selection 
        public void BumpNumberOfWinners()
        {
            NumberOfWinners++;
            if(AmmountPaid != AmmountPayable)
            {
                AmmountPaid = AmmountPayable;
            } 
        }

        //ToString Method for print purpose
        public override string ToString()
        {
            return $"THERE ARE {NumberOfWinners} WINNERS";
        }

        //Method that updates the payable ammount from the previous draw 
        public void UpdateFromPrevious(Selection previousSelection)
        {
            if(previousSelection.NumberOfWinners == 0)
            {
                AmmountPayable += previousSelection.AmmountPayable;
            }
        }

    }
}
