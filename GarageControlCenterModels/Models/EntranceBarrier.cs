namespace GarageControlCenterBackend.Models
{
    public class EntranceBarrier : Barrier
    {
        public Ticket IssueTicket(string registrationPlate)
        {
            return new Ticket(registrationPlate);
        }
    }
}
