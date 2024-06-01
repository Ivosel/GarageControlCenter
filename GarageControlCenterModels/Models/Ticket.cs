using System.ComponentModel;

namespace GarageControlCenterBackend.Models
{
    public class Ticket
    {
        [Browsable(false)]
        private static int ticketCounter = 0;
        [Browsable(false)]
        public int Id { get; private set; }
        [Browsable(false)]
        public Garage GarageRef { get; private set; }
        [Browsable(false)]
        public int GarageId { get; private set; }
        public string TicketNumber { get; private set; }
        public DateTime EntranceTime { get; private set; }
        public bool IsPaid { get; private set; }

        public Ticket()
        {
            ticketCounter++;

            TicketNumber = ticketCounter.ToString();
            EntranceTime = DateTime.Now;
            IsPaid = false;
        }

        public void MarkTicketPaid()
        {
            IsPaid = true;
        }
    }
}
