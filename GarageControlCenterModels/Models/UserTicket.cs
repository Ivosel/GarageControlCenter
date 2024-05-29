using System.Reflection.Metadata.Ecma335;

namespace GarageControlCenterBackend.Models
{
    public class UserTicket
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public GarageUser UserRef { get; set; }
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
            isBlocked = false;
            State = TicketState.Neutral;
        }

        public void ExtendTicket(DateTime extendUntil)
        {
            ValidUntil = extendUntil;
        }

        public void ChangeTicketType(TicketType type)
        {
            Type = type;
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

        public bool GetBlockedInfo()
        {
            return isBlocked;
        }

        public bool GetNeutralInfo()
        {
            return State == TicketState.Neutral;
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
