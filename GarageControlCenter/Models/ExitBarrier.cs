namespace GarageControlCenter.Models
{
    // A sub-class of Barrier, representing the exit from the garage
    public class ExitBarrier : Barrier
    {
        public void ReadTicket(Ticket ticket)
        {
            if (ticket.IsPaid)
            {
                OpenBarrier();
            }
        }
    }
}
