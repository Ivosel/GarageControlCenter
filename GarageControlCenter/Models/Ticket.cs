namespace GarageControlCenter.Models
{
    // A class representing parking tickets
    public class Ticket
    {
        private static int ticketCounter = 0;
        public int Id { get; set; }
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
