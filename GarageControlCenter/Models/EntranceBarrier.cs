namespace GarageControlCenter.Models
{
    // A sub-class of Barrier, representing the entrance to the garage
    public class EntranceBarrier : Barrier
    {
        Ticket Ticket;
        public Ticket IssueTicket()
        {
            Ticket = new Ticket();
            return Ticket;
        }

        public bool ReadTicket(Ticket ticket)
        {
            return ticket.IsPaid ? true : false;
        }
    }
}
