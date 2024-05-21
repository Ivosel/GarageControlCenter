using GarageControlCenterModels.Models;
using System.Data;

namespace GarageControlCenterUI
{
    // A form to demonstrate an exit from the garage
    public partial class ExitDemonstration : Form
    {
        private Garage MyGarage;
        ExitBarrier Exit { get; set; }
        public event EventHandler<CustomerExitEventArgs> CustomerExit;

        public ExitDemonstration(Garage myGarage)
        {
            MyGarage = myGarage;
            Exit = new ExitBarrier();
            InitializeComponent();
        }

        private void InsertTicketButton_Click(object sender, EventArgs e)
        {
            // Get the ticket number entered by the user
            string ticketNumber = ticketNumberTextBox.Text;

            // Search for a ticket with the entered ticket number
            Ticket ticket = MyGarage.Tickets.FirstOrDefault(t => t.TicketNumber == ticketNumber);

            if (ticket != null)
            {
                // Ticket found, check if it's paid
                Exit.ReadTicket(ticket);

                if (Exit.IsOpen)
                {
                    MyGarage.Tickets.Remove(ticket);
                    UpdateParkingSpot();
                    MessageBox.Show("Thank you for using our garage!", "Barrier Open", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Exit.CloseBarrier();
                }
                else
                {
                    // If the ticket is not paid, display a message
                    MessageBox.Show("Ticket not paid. Please pay the ticket on the automatic payment machine!", "Barrier Closed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Ticket not found, display a message
                MessageBox.Show("Invalid ticket number. Please enter a valid ticket number.", "Invalid Ticket", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateParkingSpot()
        {
            List<Level> availableLevels = MyGarage.Levels.Where(level => level.OccupiedSpots() > 0).ToList();

            // Randomly select a level from the used levels
            Random random = new Random();
            int randomLevelIndex = random.Next(availableLevels.Count);
            Level chosenLevelObject = availableLevels[randomLevelIndex];

            // Filter spots that are occupied in the chosen level
            List<ParkingSpot> usedSpots = chosenLevelObject.Spots.Where(spot => spot.IsOccupied).ToList();

            // Select a random spot from the occupied spots
            int randomSpotIndex = random.Next(usedSpots.Count);
            ParkingSpot chosenSpot = usedSpots[randomSpotIndex];
            chosenSpot.ReleaseSpot();
            CustomerExit?.Invoke(this, new CustomerExitEventArgs(chosenSpot));
        }

        public class CustomerExitEventArgs : EventArgs
        {
            public ParkingSpot ChosenSpot { get; }

            public CustomerExitEventArgs(ParkingSpot spot)
            {
                ChosenSpot = spot;
            }
        }

        public void SubscribeToCustomerExitEvent(EventHandler<CustomerExitEventArgs> handler)
        {
            CustomerExit += handler;
        }

        private void ExitDemonstration_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
