using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProjectFromTheStart

//Use Cases of this project

//1)Draw 1 - 80(12 unique numbers). Last is Kino Bonus.

//2)Participation of players in the draw. Choice of 6 unique numbers. Choice of numbers is automatic(random).

//3)Presentation : 
//There are Χ numbers that won 6 out of 6 Numbers (+ ΚΙΝΟ Bonus)
//There are Χ numbers that won 5 out of 6 Numbers (+ ΚΙΝΟ Bonus)
//There are Χ numbers that won 4 out of 6 Numbers (+ ΚΙΝΟ Bonus)
//...
//...
//There are Χ numbers that won 1 out of 6 Numbers (+ ΚΙΝΟ Bonus)

//4)Many Draws with participation of the same players.

//5)Every draw provides a constant ammount of money(100000)
//The categories must share this ammount with percentages:
//6+ : 35%
//6  : 23%
//5+ : 15%
//5  : 7%
//4+ : 5%
//4  : 3%
//3+ : 2%
//3  : 1%
//2+ : 0.8%
//2  : 0.6%
//1+ : 0.4%
//1  : 0.2%

//The remaining 7% is provided for Philanthropies.If in some category, there are no winners,
//then the ammount of the category will be added to the ammount of the next draw.

//6)Statistics: Lucky numbers with the max frequency. Kino Bonuses with the max frequency.

{
    class Program
    {
        static void Main(string[] args)
        {
            var kino = new KinoGame();

            kino.MakePlayers(5);
            kino.MakeDraws(10);
            kino.RunDraws();
            kino.RunSelections();

            //Scripts for the results each draw
            foreach (var draw in kino.Draws)
            {
                var totalPayable = draw.GetTotalMoneyPaiyable();
                Console.WriteLine($"\nTOTAL AMMOUNT OF MONEY THAT THE DRAW THAT IS PAYABLE TO PLAYERS IS {totalPayable}\n");            

                Console.WriteLine($"\nDraw with id {draw.ID} has");
                foreach (var number in draw.LuckyNumbers)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine($"Kino bonus is {draw.KinoBonus}");

                foreach (Player player in kino.Players)
                {
                    var ticket = player.GetTicketByDrawId(draw.ID);
                    Console.WriteLine($"\nNumbers that player with id {player.ID} played: ");
                    foreach (var number in ticket.NumbersPlayed)
                    {
                        Console.Write(number + " ");
                    }
                    Console.WriteLine("\nNumbers that player got are :");
                    foreach (var number in ticket.NumbersWon)
                    {
                        Console.Write(number + " ");
                    }

                }

                foreach(var sel in draw.Selections)
                {
                    Console.WriteLine("\n" + sel + " THAT GOT " + sel.SelectionCategory);
                    Console.WriteLine($"THE AMMOUNT OF MONEY THAT GOES IN THIS CATEGORY IS {sel.AmmountPaid}");
                }

                var totalPaid = draw.GetTotalMoneyPaid();
                Console.WriteLine($"\nTOTAL AMMOUNT OF MONEY THAT THE DRAW PAID IS {totalPaid}\n");
                Console.WriteLine($"MONEY THAT GOES TO FILANTHROPY IS {draw.FilanthropyMoney}");
                Console.WriteLine();
            }

            //Scripts for Statistics

            var stats = kino.GetStatistics();
            var maxFrequencyOfDrawsnNumbers = stats.MostDrawnNumbers.Values.Max();

            var maxFrequencyOfKinoBonuses = stats.MostDrawnKinoNumbers.Values.Max();
        
            Console.WriteLine($"NUMBERS WITH MAX FREQUENCY {maxFrequencyOfDrawsnNumbers} ARE :\n");
            foreach (var pair in stats.MostDrawnNumbers)
            {
                if (pair.Value == maxFrequencyOfDrawsnNumbers)
                {
                    Console.Write(pair.Key + " ");
                }
            }

            Console.WriteLine($"\n\nKINO BONUSES WITH MAX FREQUENCY {maxFrequencyOfKinoBonuses} ARE :\n");
            foreach (var pair in stats.MostDrawnKinoNumbers)
            {
                if (pair.Value == maxFrequencyOfKinoBonuses)
                {
                    Console.Write(pair.Key + " ");
                }
            }
        }

        
}
}
