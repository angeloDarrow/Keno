using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProjectFromTheStart
{
    class Player
    {
        //Properties
        public int ID { get; private set; }
        public List<Ticket> Tickets { get; set; }
        private List<int> ChosenNumbers { get; set; }

        //Constructor
        public Player(int id)
        {
            ID = id;
            Tickets = new List<Ticket>();
            //Inialization of random selected numbers 
            ChosenNumbers = RandomNumbersMachine.GenerateNumbers(6);
        }

        //Method to add new tickets fot the player
        public void AddNewTicket(int drawID)
        {
            var kinoBonusOption = RandomNumbersMachine.TossCoin();
            var ticket = new Ticket(drawID,kinoBonusOption);

            foreach(var num in ChosenNumbers)
            {
                ticket.AddNumberPlayed(num);
            }
            Tickets.Add(ticket);
        }

        //Method that finds the ticket from the corresponded draw
        public Ticket GetTicketByDrawId(int drawId)
        {
            
            foreach (Ticket ticket in Tickets)
            {
                if (ticket.ID == drawId)
                {
                    return ticket;
                }
            }
            
            throw new ArgumentException ("Ticket not found");
        }        
    }
}
