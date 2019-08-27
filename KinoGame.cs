using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProjectFromTheStart
{
    class KinoGame
    {
        //Properties
        public List<Player> Players { get; set; }
        public List<Draw> Draws { get; set; }
        public List<SelectionCategory> SelectionCategories { get; private set; }

        private List<int> allLukyNumbers;
        public List<int> AllLukyNumbers
        {
            get
            {
                //query syntax to put the drawn numbers from all draws to an IEnumerable
                var allnumbers = from d in Draws
                                 from n in d.LuckyNumbers
                                 select n;
                allLukyNumbers = allnumbers.ToList();
                return allLukyNumbers;
            }
            set
            {

                allLukyNumbers = value;
            }

        }

        private List<int> allBonuses;
        public List<int> AllKinoBonuses
        {
            get
            {
                //query syntax to add all the kinoBonuses to the list               
                var allBonuses = from d in Draws
                                 select d.KinoBonus;
                                 
                return allBonuses.ToList();
            }
            set
            {
                allBonuses = value;
            }

        }
        //Constructor
        public KinoGame()
        {
            Players = new List<Player>();
            Draws = new List<Draw>();
            SelectionCategories = new List<SelectionCategory>();
            InitSelectionCategories();
            AllLukyNumbers = new List<int>();
            AllKinoBonuses = new List<int>();
        }
       
        //Method that returns statistics. I make two lists with 80 elements for 0 to 80.
        //Foreach of these lists i pump every index of it when for this index , there is 
        // a corresponded lucky number or kinoBonus
        //Then , with method syntax, i make a dictionary for each of these lists
        //with keys, every number from 1 to 80 and values foreach key, the number of the times
        //that this key(number) was a lucky number(or kino bonus).
        public  KinoStatistics GetStatistics()
        {
            var stats = new KinoStatistics();
            var listaWitheighty = new List<int>();
            var listaWitheighty2 = new List<int>();

            for (int i = 0; i < 81; i++)
            {
                listaWitheighty.Add(0);
            }

            for (int i = 0; i < 81; i++)
            {
                listaWitheighty2.Add(0);
            }

            for (int i = 1; i < 81; i++)
            {
                foreach (int number in AllLukyNumbers)
                {
                    if (i == number)
                    {
                        listaWitheighty[i]++;
                    }
                }
            }

            for (int i = 1; i < 81; i++)
            {
                foreach (int number in AllKinoBonuses)
                {
                    if (i == number)
                    {
                        listaWitheighty2[i]++;
                    }
                }
            }
            var j = 0;
            var k = 0;
            stats.MostDrawnNumbers = listaWitheighty.ToDictionary(x => j++, x => x);
            stats.MostDrawnKinoNumbers = listaWitheighty2.ToDictionary(x => k++, x => x);

            return stats;

        }

        //Method that adds players to the Players Property
        public void MakePlayers(int numberOfPlayers)
        {

            for (int i = 1; i <= numberOfPlayers ; i++)
            {
                var newPlayer = new Player(i);
                Players.Add(newPlayer);
                
            }
        }

        //Method that adds draws to the Draws Property
        public void MakeDraws(int numberOfDraws)
        {
            for (int drawId = 1; drawId <= numberOfDraws; drawId++)
            {
                var newDraw = new Draw(drawId,SelectionCategories);
                Draws.Add(newDraw);
            }
        }

        //Method that assigns tickets calling the method from the Player Class
        private void AssignTickets(int drawId)
        {
            foreach(Player player in Players)
            {
                player.AddNewTicket(drawId);
            }          
        }
        //Method calling the private method above and generates the lucky numbers of the draw
        private void RunDraw(Draw draw)
        {          
            AssignTickets(draw.ID);
            draw.GenerateLuckyNumbers();
        }

        //Method that calls the private method above and generates luvky numbers for each draw
        public void RunDraws()
        {
            Draws.ForEach(RunDraw);
        }

        //Method that runs the Selections
        public void RunSelections()
        {
            //For the first draw that doesn't have previes draw
            Draw previousDraw = null;

            foreach (Draw draw in Draws)
            {                
                foreach(Player player in Players)
                {
                    try
                    {
                        //calls the method from Player Class and finds the corresponded ticket for the draw
                        var ticket = player.GetTicketByDrawId(draw.ID);
                        //calls the method from Ticket Class and puts the numbers that win in the list NumbersWon
                        ticket.SetWonNumbers(draw.LuckyNumbers);
                        if(ticket.NumbersWonOutOfPlayed > 0)
                        {
                            //calls the method below and gets the corresponded selection category for the numbers that won out of played
                            var selectionCategory = GetSelectionCategory(ticket.NumbersWonOutOfPlayed, ticket.KinoBonusOption);
                            foreach(var selection in draw.Selections)
                            {
                                if (selection.SelectionCategory == selectionCategory)
                                {
                                    //calls the method from Selections Class and bumps the number of winners in this selection Category
                                    selection.BumpNumberOfWinners();
                                }
                            }                                                                           
                        }                                             
                    }
                    catch(ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }                  
                }
                if (previousDraw != null)
                {
                    //updates the selections of the draw , from the selections of the previous draw
                    draw.UpdateSelectionsFromPreviousDraw(previousDraw);
                }
                   
                previousDraw = draw;
            }
        }

        //Method that initializes the selection Categories
        private void InitSelectionCategories()
        {
            SelectionCategories.Add(new SelectionCategory(6, true, 0.35m));
            SelectionCategories.Add(new SelectionCategory(6, false, 0.23m));
            SelectionCategories.Add(new SelectionCategory(5, true, 0.15m));
            SelectionCategories.Add(new SelectionCategory(5, false, 0.07m));
            SelectionCategories.Add(new SelectionCategory(4, true, 0.05m));
            SelectionCategories.Add(new SelectionCategory(4, false, 0.03m));
            SelectionCategories.Add(new SelectionCategory(3, true, 0.02m));
            SelectionCategories.Add(new SelectionCategory(3, false, 0.01m));
            SelectionCategories.Add(new SelectionCategory(2, true, 0.008m));
            SelectionCategories.Add(new SelectionCategory(2, false, 0.006m));
            SelectionCategories.Add(new SelectionCategory(1, true, 0.004m));
            SelectionCategories.Add(new SelectionCategory(1, false, 0.002m));
        } 

        //Method that returns the selection category to use it in the RunSelections method above
        public SelectionCategory GetSelectionCategory(int numbersWonOutOfPlayed, bool kinoBonusOption)
        {
            foreach(var selcategory in SelectionCategories)
            {
                if(selcategory.NumberOutOfSix == numbersWonOutOfPlayed  && selcategory.WithBonus == kinoBonusOption)
                {
                    return selcategory;
                }
            }
            throw new ArgumentException("Selection Category not found");
        }

        
    }

}


