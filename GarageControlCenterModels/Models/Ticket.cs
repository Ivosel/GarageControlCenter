using System.ComponentModel;

namespace GarageControlCenterBackend.Models
{
    public class Ticket
    {
        public int Id { get; private set; }
        [Browsable(false)]
        public Garage GarageRef { get; private set; }
        [Browsable(false)]
        public int GarageId { get; private set; }
        public string RegistrationPlate {  get; private set; }
        public DateTime EntranceTime { get; private set; }
        public bool IsPaid { get; private set; }

        public Ticket(string registrationPlate)
        {
            EntranceTime = DateTime.Now;
            IsPaid = false;
            RegistrationPlate = registrationPlate;
        }

        public void MarkTicketPaid()
        {
            IsPaid = true;
        }
    }
}
