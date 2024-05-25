using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
