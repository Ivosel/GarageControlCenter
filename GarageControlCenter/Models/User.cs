namespace GarageControlCenter.Models
{
    public class User
    {
        private static int userCounter = 0;
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string RegistrationPlate { get; set; }
        public UserTicket UserTicket { get; set; }
        
        public User(string lastName, string firstName, string phoneNumber, string email, string registrationPlate)
        {
            Id = userCounter++;
            LastName = lastName;
            FirstName = firstName;
            PhoneNumber = phoneNumber;
            Email = email;
            RegistrationPlate = registrationPlate;
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
