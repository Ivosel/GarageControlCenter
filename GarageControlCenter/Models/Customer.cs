namespace GarageControlCenter.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Ticket TicketNr { get; set; }
        public DateTime ValidUntil { get; set; }
    }
}
