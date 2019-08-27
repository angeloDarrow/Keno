using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProjectFromTheStart
{
    class Draw
    {
        //Properties
        public int ID { get; private set; }
        public List<int> LuckyNumbers { get; private set; }
        public int KinoBonus
        {
            get
            {
                return LuckyNumbers.Last();
            }
        }

        public List<Selection> Selections { get; private set; }

        private const decimal StartingMoney = 100000;
        private const decimal FilanthropyPercentage = 0.07m;
  
        public decimal FilanthropyMoney
        {
            get
            {
                if (GetTotalMoneyPaiyable() + FilanthropyPercentage * StartingMoney == StartingMoney)
                {
                    return StartingMoney * FilanthropyPercentage;
                }
                else
                {
                    return (GetTotalMoneyPaiyable()) * FilanthropyPercentage;
                }
            }
        }

        //Constructor
        public Draw(int id, List<SelectionCategory> selectionCategories)
        {
            ID = id;
            LuckyNumbers = new List<int>();
            Selections = new List<Selection>();
            //Inits the selections for every new draw, calling the private method InitSelections
            InitSelections(selectionCategories);            
        }

        //Method that sets the 12 lucky numbers , calling the static method from the RandomNumbersMachine Class
        public void GenerateLuckyNumbers()
        {
            LuckyNumbers = RandomNumbersMachine.GenerateNumbers(12);
        }

        //Inits the selections for the draw
        private void InitSelections(List<SelectionCategory> selectionCategories)
        {
            foreach (var selectioncat in selectionCategories)
            {
                var newSelection = new Selection(0, selectioncat.Percentage * StartingMoney, selectioncat);
                Selections.Add(newSelection);
            }
        }

        //Method that called in KinoGame Class in RunSelections method to update the selections
        public void UpdateSelectionsFromPreviousDraw(Draw previousDraw)
        {         
            for(int i = 0; i < Selections.Count; i++)
            {
                var currentSelection = Selections[i];
                var previousSelection = previousDraw.Selections[i];
                currentSelection.UpdateFromPrevious(previousSelection);
            }
        }

        public decimal GetTotalMoneyPaid()
        {
            return Selections.Sum(x => x.AmmountPaid);

        }

        public decimal GetTotalMoneyPaiyable()
        {
            return Selections.Sum(x => x.AmmountPayable);
        }



    }
}
