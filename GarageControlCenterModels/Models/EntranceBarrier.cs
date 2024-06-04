﻿namespace GarageControlCenterBackend.Models
{
    public class EntranceBarrier : Barrier
    {
        Ticket Ticket;
        public Ticket IssueTicket(string registrationPlate)
        {
            Ticket = new Ticket(registrationPlate);
            return Ticket;
        }
    }
}
