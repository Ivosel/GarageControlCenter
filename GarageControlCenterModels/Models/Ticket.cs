using System.ComponentModel;

namespace GarageControlCenterModels.Models
{
    public class Ticket
    {
        [Browsable(false)]
        private static int ticketCounter = 0;
        [Browsable(false)]
        public int Id { get; set; }
        [Browsable(false)]
        public Garage GarageRef { get; set; }
        [Browsable(false)]
        public int GarageId { get; set; }

        public string TicketNumber { get; set; }
        public DateTime EntranceTime { get; set; }
        public bool IsPaid { get; set; }

        public Ticket()
        {
            ticketCounter++;

            Id = ticketCounter;
            TicketNumber = ticketCounter.ToString();
            EntranceTime = DateTime.Now;
            IsPaid = false;
        }
    }
}
