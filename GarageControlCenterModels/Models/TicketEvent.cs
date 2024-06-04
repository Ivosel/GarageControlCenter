using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageControlCenterBackend.Models
{
    public class TicketEvent
    {
        public int Id { get; set; }
        public int UserTicketId { get; private set; }
        public UserTicket UserTicketRef { get; set; }
        public DateTime TimeStamp { get; set; }
        public TicketEventType Type { get; set; }

        private TicketEvent() { }

        public TicketEvent(DateTime timeStamp, TicketEventType type)
        {
            TimeStamp = timeStamp;
            Type = type;
        }
    }

    public enum TicketEventType
    {
        Entrance,
        Exit
    }
}
