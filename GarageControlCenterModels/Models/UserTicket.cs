namespace GarageControlCenterModels.Models
{
    public class UserTicket
    {
        public static int ticketCounter = 1000;
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Number { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public TicketState State { get; set; }
        public TicketType Type { get; set; }
        public bool isBlocked { get; set; }

        public UserTicket()
        {
            Id = ticketCounter++;
            isBlocked = false;
            State = TicketState.Neutral;
        }
    }

    public enum TicketState
    {
        Neutral,
        Inside,
        Outside
    }

    public enum TicketType
    {
        WholeDay,
        DayShift,
        NightShift
    }
}
