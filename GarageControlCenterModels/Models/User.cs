namespace GarageControlCenterModels.Models
{
    public class User
    {
        private static int userCounter = 0;
        public int Id { get; private set; }
        public Garage GarageRef { get; private set; }
        public int GarageId { get; private set; }
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string RegistrationPlate { get; private set; }
        public UserTicket UserTicket { get; private set; }

        private User() { }
        public User(string lastName, string firstName, string phoneNumber, string email, string registrationPlate)
        {
            Id = userCounter++;
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
