using GarageControlCenterModels.Models;
using System.Data;

namespace GarageControlCenterUI
{
    // A form to demonstrate an exit from the garage
    public partial class ExitDemonstration : Form
    {
        private MainForm MainForm;
        ExitBarrier Exit { get; set; }
        public event EventHandler<CustomerExitEventArgs> CustomerExit;

        public ExitDemonstration(MainForm mainForm)
        {
            MainForm = mainForm;
            Exit = new ExitBarrier();
            InitializeComponent();
        }

        private void InsertTicketButton_Click(object sender, EventArgs e)
        {
            // Get the ticket number entered by the user
            string ticketNumber = ticketNumberTextBox.Text;

            // Search for a ticket with the entered ticket number
            Ticket ticket = MainForm.myGarage.Tickets.FirstOrDefault(t => t.TicketNumber == ticketNumber);

            if (ticket != null)
            {
                // Ticket found, check if it's paid
                Exit.ReadTicket(ticket);

                if (Exit.IsOpen)
                {
                    // If the barrier is open, remove the ticket from the list
                    MainForm.myGarage.Tickets.Remove(ticket);
                    MainForm.ticketsForm.RefreshTickets();
                    // Refresh the visual representation of the parking spots
                    UpdateParkingSpotGrid();
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

        private void UpdateParkingSpotGrid()
        {
            List<Level> availableLevels = MainForm.myGarage.Levels.Where(level => level.OccupiedSpots() > 0).ToList();

            if (availableLevels.Count > 0)
            {
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

            else
            {
                // Handle case where all levels are full
                MessageBox.Show("No available spots in the garage.");
            }
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
