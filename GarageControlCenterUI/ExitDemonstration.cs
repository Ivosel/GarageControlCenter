using GarageControlCenterBackend.Models;
using GarageControlCenterBackend.Services;
using System.Data;

namespace GarageControlCenterUI
{
    // A form to demonstrate an exit from the garage
    public partial class ExitDemonstration : Form
    {
        private readonly Garage myGarage;
        private readonly GarageService service;
        private readonly Random random;
        ExitBarrier Exit { get; }

        public event EventHandler<CustomerExitEventArgs> CustomerExit;

        public ExitDemonstration(Garage garage, GarageService garageService)
        {
            service = garageService;
            myGarage = garage;
            random = new Random();
            Exit = new ExitBarrier();
            InitializeComponent();
        }

        private async void InsertTicketButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the ticket number entered by the user
                int ticketNumber;

                if (int.TryParse(ticketNumberTextBox.Text, out int ticketId))
                {
                    ticketNumber = ticketId;
                }

                else
                {
                    // Display a warning message if the input is invalid
                    MessageBox.Show("Please enter a valid ticket number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Search for a ticket with the entered ticket number
                var ticket = myGarage.Tickets.FirstOrDefault(t => t.Id == ticketNumber);

                if (ticket != null)
                {
                    // Ticket found, check if it's paid
                    Exit.ReadTicket(ticket);

                    if (Exit.IsOpen)
                    {
                        myGarage.Tickets.Remove(ticket);
                        await service.RemoveTicketAsync(ticket);
                        UpdateParkingSpot();
                        MessageBox.Show("Thank you for using our garage!", "Barrier Open", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ticket not paid. Please pay the ticket on the automatic payment machine!", "Barrier Closed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Ticket not found. Please enter a valid ticket number.", "Invalid Ticket", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                Exit.CloseBarrier();
            }
        }

        private void UpdateParkingSpot()
        {
            var availableLevels = myGarage.Levels.Where(level => level.OccupiedSpots() > 0).ToList();

            // Randomly select a level from the used levels
            int randomLevelIndex = random.Next(availableLevels.Count);
            var chosenLevel = availableLevels[randomLevelIndex];

            // Filter spots that are occupied in the chosen level
            var usedSpots = chosenLevel.Spots.Where(spot => spot.IsOccupied).ToList();

            // Select a random spot from the occupied spots
            int randomSpotIndex = random.Next(usedSpots.Count);
            var chosenSpot = usedSpots[randomSpotIndex];
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
