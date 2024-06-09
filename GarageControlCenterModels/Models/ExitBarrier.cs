namespace GarageControlCenterBackend.Models
{
    public class ExitBarrier : Barrier
    {
        public void ReadTicket(Ticket ticket)
        {
            if (ticket.IsPaid)
            {
                OpenBarrier();
            }
        }

        public void ReadUserTicket(UserTicket ticket)
        {
            int uncoveredHours = ticket.GetUncoveredHours();
            if (uncoveredHours == -1)
            {
                ticket.CalculateUncoveredHours();
                uncoveredHours = ticket.GetUncoveredHours();
            }
            if (uncoveredHours == 0)
            {
                OpenBarrier();
            }
        }
    }
}
