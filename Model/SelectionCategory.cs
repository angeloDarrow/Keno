using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProjectFromTheStart
{
    internal class SelectionCategory
    {   //Properties
        public int NumberOutOfSix { get; set; }
        public bool WithBonus { get; set; }
        public decimal Percentage { get; set; }

        //Constructor
        public SelectionCategory(int numberOutOfSix,bool withBonus,decimal percentage)
        {
            NumberOutOfSix = numberOutOfSix;
            WithBonus = withBonus;
            Percentage = percentage;
        }

        //ToString Method for print purpose
        public override string ToString()
        {
           var with = "WITH";

           if (!WithBonus)
           {
               with = "WITHOUT";
           }
           
           return $" {NumberOutOfSix} OUT OF 6 {with} KINO BONUS ";
        }

    }
}
