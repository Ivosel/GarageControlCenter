using System.ComponentModel.DataAnnotations;

namespace GarageControlCenterBackend.Models
{
    public class GarageUser
    {
        [Key]
        public int Id { get; private set; }
        public Garage GarageRef { get; private set; }
        public int GarageId { get; private set; }
        [Required]
        public string LastName { get; private set; }
        [Required]
        public string FirstName { get; private set; }
        [Phone]
        public string PhoneNumber { get; private set; }
        [EmailAddress]
        public string Email { get; private set; }
        [Required]
        public string RegistrationPlate { get; private set; }
        public UserTicket UserTicket { get; private set; }

        private GarageUser() { }
        public GarageUser(string lastName, string firstName, string phoneNumber, string email, string registrationPlate)
        {
            LastName = lastName;
            FirstName = firstName;
            PhoneNumber = phoneNumber;
            Email = email;
            RegistrationPlate = registrationPlate;
        }

        public void UpdateUser(string lastName, string firstName, string phoneNumber, string email, string registrationPlate)
        {
            LastName = lastName;
            FirstName = firstName;
            PhoneNumber = phoneNumber;
            Email = email;
            RegistrationPlate = registrationPlate;
        }

        public void RemoveTicket()
        {
            UserTicket = null;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public void AssignTicket(UserTicket ticket)
        {
            UserTicket = ticket;
        }
    }
}
