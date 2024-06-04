using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace GarageControlCenterBackend.Models
{
    public class UserTicket
    {
        [Key]
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public GarageUser UserRef { get; set; }
        [Required]
        public DateTime ValidFrom { get; private set; }
        [Required]
        public DateTime ValidUntil { get; private set; }
        public TicketState State { get; private set; }
        [Required]
        public TicketType Type { get; private set; }
        public bool isBlocked { get; private set; }
        public List<TicketEvent> TicketEvents { get; private set; }


        private UserTicket() { }

        public UserTicket(DateTime from, DateTime until, TicketType type)
        {
            ValidFrom = from;
            ValidUntil = until;
            Type = type;
            isBlocked = false;
            State = TicketState.Neutral;
            TicketEvents = new List<TicketEvent>();
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

        public void SetInside()
        {
            State = TicketState.Inside;
            TicketEvents.Add(new TicketEvent(DateTime.Now, TicketEventType.Entrance));
        }

        public void SetOutside()
        {
            State = TicketState.Outside;
            TicketEvents.Add(new TicketEvent(DateTime.Now, TicketEventType.Exit));
        }

        public bool IsValid()
        {
            return ValidUntil.Date >= DateTime.Now.Date;
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
