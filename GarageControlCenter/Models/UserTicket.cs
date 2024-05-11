namespace GarageControlCenter.Models
{
    public class UserTicket
    {
        public static int ticketCounter = 0;
        public int Id { get; set; }
        public string Number { get; set; }
        public DateOnly ValidFrom { get; set; }
        public DateOnly ValidUntil { get; set;}
        public TicketState State { get; set; }
        public TicketType Type { get; set; }
        public bool IsBlocked { get; set; }
 
        public UserTicket()
        {
            Id = ticketCounter++;
            IsBlocked = false;
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
