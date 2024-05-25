namespace GarageControlCenterBackend.Models
{
    public class UserTicket
    {
        public static int ticketCounter = 1000;
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public string Number { get; private set; }
        public DateTime ValidFrom { get; private set; }
        public DateTime ValidUntil { get; private set; }
        public TicketState State { get; private set; }
        public TicketType Type { get; private set; }
        public bool isBlocked { get; private set; }

        private UserTicket() { }
        public UserTicket(DateTime from, DateTime until, TicketType type)
        {
            ValidFrom = from;
            ValidUntil = until;
            Type = type;
            Number = ticketCounter++.ToString();
            isBlocked = false;
            State = TicketState.Neutral;
        }

        public void ExtendTicket(DateTime extendUntil)
        {
            ValidUntil = extendUntil;
        }

        public void BlockTicket()
        {
            isBlocked = true;
        }

        public void UnblockTicket()
        {
            isBlocked = false;
        }

        public void SetToNeutral()
        {
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
