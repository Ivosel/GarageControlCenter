using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageControlCenterModels.Models
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
