using GarageControlCenterBackend.Models;
using GarageControlCenterBackend.Services;
using System.Data;
using static GarageControlCenterUI.EntryDemonstration;

namespace GarageControlCenterUI
{
    // A form to demonstrate an exit from the garage
    public partial class ExitDemonstration : Form
    {
        private readonly Garage myGarage;
        private readonly GarageService service;
        private readonly UserService userService;

        private readonly Random random;
        ExitBarrier Exit { get; }

        public event Func<object, CustomerExitEventArgs, Task> CustomerExit;

        public ExitDemonstration(Garage garage, GarageService GarageService, UserService UserService)
        {
            InitializeComponent();
            InsertTicketButton.Click += async (sender, e) => await InsertTicketButton_Click(sender, e); ;
            service = GarageService;
            myGarage = garage;
            random = new Random();
            Exit = new ExitBarrier();
            userService = UserService;
        }

        private async Task InsertTicketButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool isTicketNumberEntered = int.TryParse(ticketNumberTextBox.Text, out int ticketNumber);
                bool isUserIdEntered = int.TryParse(userIdTextBox.Text, out int userId);

                if (isTicketNumberEntered && isUserIdEntered)
                {
                    MessageBox.Show("Please enter either a ticket number or a user ID, not both.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!isTicketNumberEntered && !isUserIdEntered)
                {
                    MessageBox.Show("Please enter a valid ticket number or a user ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (isTicketNumberEntered)
                {
                    await HandleTicketInserted(ticketNumber);
                }

                else if (isUserIdEntered)
                {
                    await HandleUserIdEntered(userId);
                }

            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            finally
            {
                ticketNumberTextBox.Text = "Ticket number";
                ticketNumberTextBox.ForeColor = Color.LightGray;
                userIdTextBox.Text = "User ID";
                userIdTextBox.ForeColor = Color.LightGray;

                if (Exit.IsOpen)
                {
                Exit.CloseBarrier();
                }
            }
        }

        private async Task UpdateParkingSpot()
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
            await CustomerExit?.Invoke(this, new CustomerExitEventArgs(chosenSpot));
        }

        public async Task HandleTicketInserted(int ticketNumber)
        {
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
                    await UpdateParkingSpot();
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

        public async Task HandleUserIdEntered(int userId)
        {
            var user = myGarage.Users.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                if (user.UserTicket == null)
                {
                    MessageBox.Show("User does not have a ticket.");
                    return;
                }

                if (!user.UserTicket.IsValid())
                {
                    MessageBox.Show("Ticket expired!");
                    return;
                }

                if (user.UserTicket.State == TicketState.Outside)
                {
                    MessageBox.Show("User is not inside the garage.");
                    return;
                }
                await UpdateParkingSpot();
                user.UserTicket.SetOutside();
                await userService.UpdateUserAsync(user);
                Exit.CloseBarrier();
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

        public void SubscribeToCustomerExitEvent(Func<object, CustomerExitEventArgs, Task> handler)
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

        private void ticketNumberTextBox_Enter(object sender, EventArgs e)
        {
            if (ticketNumberTextBox.Text == "Ticket number")
            {
                ticketNumberTextBox.ForeColor = Color.Black;
                ticketNumberTextBox.Text = "";
            }
        }

        private void ticketNumberTextBox_Leave(object sender, EventArgs e)
        {
            if (ticketNumberTextBox.Text.Length == 0)
            {
                ticketNumberTextBox.ForeColor = Color.LightGray;
                ticketNumberTextBox.Text = "Ticket number";
            }
        }

        private void userIdTextBox_Enter(object sender, EventArgs e)
        {
            if (userIdTextBox.Text == "User ID")
            {
                userIdTextBox.ForeColor = Color.Black;
                userIdTextBox.Text = "";
            }
        }

        private void userIdTextBox_Leave(object sender, EventArgs e)
        {
            if (userIdTextBox.Text.Length == 0)
            {
                userIdTextBox.ForeColor = Color.LightGray;
                userIdTextBox.Text = "User ID";
            }
        }
    }
}
