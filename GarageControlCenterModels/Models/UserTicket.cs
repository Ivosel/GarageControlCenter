using System.ComponentModel.DataAnnotations;

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
        public bool IsBlocked { get; private set; }
        public List<TicketEvent> TicketEvents { get; private set; }
        private int UncoveredHours;

        private UserTicket() { }

        public UserTicket(DateTime from, DateTime until, TicketType type)
        {
            ValidFrom = from;
            ValidUntil = until;
            Type = type;
            IsBlocked = false;
            State = TicketState.Neutral;
            TicketEvents = new List<TicketEvent>();
            UncoveredHours = -1;
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
            IsBlocked = true;
        }

        public void UnblockTicket()
        {
            IsBlocked = false;
        }

        public void SetToNeutral()
        {
            State = TicketState.Neutral;
        }

        public bool GetBlockedInfo()
        {
            return IsBlocked;
        }

        public bool GetNeutralInfo()
        {
            return State == TicketState.Neutral;
        }

        public void SetInside()
        {
            State = TicketState.Inside;
            TicketEvents.Add(new TicketEvent(DateTime.Now, TicketEventType.Entrance));
            UncoveredHours = -1;
        }

        public void SetOutside()
        {
            State = TicketState.Outside;
            TicketEvents.Add(new TicketEvent(DateTime.Now, TicketEventType.Exit));
        }

        public bool IsValid()
        {
            return ValidUntil.Date >= DateTime.Today;
        }

        public int GetUncoveredHours()
        {
            return UncoveredHours;
        }

        public void ResetUncoveredHours()
        {
            UncoveredHours = 0;
        }

        public void CalculateUncoveredHours()
        {
            var lastEntranceEvent = TicketEvents
                .LastOrDefault(e => e.Type == TicketEventType.Entrance);

            if (lastEntranceEvent == null)
            {
                throw new ArgumentException("No entrance event found!");
            }

            var startTime = lastEntranceEvent.TimeStamp;
            var endTime = DateTime.Now;

            for (var time = startTime; time < endTime; time = time.AddHours(1))
            {
                switch (Type)
                {
                    case TicketType.DayShift:
                        if (time.Hour < 6 || time.Hour >= 18)
                        {
                            UncoveredHours++;
                        }
                        break;

                    case TicketType.NightShift:
                        if (time.Hour >= 6 && time.Hour < 18)
                        {
                            UncoveredHours++;
                        }
                        break;
                    default:
                        UncoveredHours = 0;
                        break;
                }
            }
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

