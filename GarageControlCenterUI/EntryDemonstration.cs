using GarageControlCenterBackend.Models;
using GarageControlCenterBackend.Services;
using System;
using System.Data;

namespace GarageControlCenterUI
{
    // A form to demonstrate an entrance to the garage
    public partial class EntryDemonstration : Form
    {
        private readonly Garage myGarage;
        private readonly GarageService garageService;
        private readonly UserService userService;
        private readonly Random random;
        EntranceBarrier Entrance { get; }

        public event Func<object, CustomerEntryEventArgs, Task> CustomerEntry;

        public EntryDemonstration(Garage garage, GarageService GarageService, UserService UserService)
        {
            InitializeComponent();
            TakeTicketButton.Click += async (sender, e) => await TakeTicketButton_Click(sender, e);
            InsertTicketButton.Click += async (sender, e) => await InsertTicketButton_Click(sender, e);
            
            myGarage = garage;
            garageService = GarageService;
            userService = UserService;
            random = new Random();
            Entrance = new EntranceBarrier();
        }

        private async Task TakeTicketButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Find levels with available spots
                var availableLevels = myGarage.Levels.Where(level => level.FreeSpots() > 0).ToList();

                if (availableLevels.Count > 0)
                {
                    string registration = RegistrationTextBox.Text;
                    if (registration != "REGISTRATION" && registration != "")
                    {
                        var ticket = Entrance.IssueTicket(RegistrationTextBox.Text);
                        myGarage.Tickets.Add(ticket);
                        await garageService.AddTicketAsync(ticket);
                        await UpdateParkingSpot(availableLevels);
                        Entrance.OpenBarrier();
                    }
                    else
                    {
                        MessageBox.Show("Please enter your vehicle's registration.");
                    }
                }
                else
                {
                    // Handle case where all levels are full
                    MessageBox.Show("No available spots in the garage.");
                }
            }

            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            finally
            {
                RegistrationTextBox.Text = "REGISTRATION";
                RegistrationTextBox.ForeColor = Color.LightGray;

                if (Entrance.IsOpen)
                {
                    Entrance.CloseBarrier();
                }
            }
        }

        private async Task UpdateParkingSpot(List<Level> availableLevels)
        {
            // Randomly select a level from the available levels
            int randomLevelIndex = random.Next(availableLevels.Count);
            var chosenLevel = availableLevels[randomLevelIndex];

            // Filter spots that are not occupied in the chosen level
            var availableSpots = chosenLevel.Spots.Where(spot => !spot.IsOccupied).ToList();

            // Select a random spot from the available spots
            int randomSpotIndex = random.Next(availableSpots.Count);
            var chosenSpot = availableSpots[randomSpotIndex];
            chosenSpot.ReserveSpot();

            await CustomerEntry?.Invoke(this, new CustomerEntryEventArgs(chosenSpot));
        }

        private async Task InsertTicketButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Read the user ID from the UserIdTextBox
                int userId = int.Parse(UserIdTextBox.Text);

                // Find the user with this ID in the myGarage.Users list
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

                    if (user.UserTicket.State == TicketState.Inside)
                    {
                        MessageBox.Show("User already inside the garage.");
                        return;
                    }

                    // Find levels with available spots
                    var availableLevels = myGarage.Levels.Where(level => level.FreeSpots() > 0).ToList();

                    if (availableLevels.Count > 0)
                    {
                        Entrance.OpenBarrier();
                        await UpdateParkingSpot(availableLevels);
                        user.UserTicket.SetInside();
                        await userService.UpdateUserAsync(user);
                    }
                    else
                    {
                        // Handle case where all levels are full
                        MessageBox.Show("No available spots in the garage.");
                    }
                }

                else
                {
                    MessageBox.Show("Invalid user ID.");
                }

            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                UserIdTextBox.Text = "Enter user ID";
                UserIdTextBox.ForeColor = Color.LightGray;

                if (Entrance.IsOpen)
                {
                    Entrance.CloseBarrier();
                }
            }
        }

        public class CustomerEntryEventArgs : EventArgs
        {
            public ParkingSpot ChosenSpot { get; }

            public CustomerEntryEventArgs(ParkingSpot spot)
            {
                ChosenSpot = spot;
            }
        }

        public void SubscribeToCustomerEntryEvent(Func<object, CustomerEntryEventArgs, Task> handler)
        {
            CustomerEntry += handler;
        }

        private void EntryDemonstration_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void RegistrationTextBox_Enter(object sender, EventArgs e)
        {
            if (RegistrationTextBox.Text == "REGISTRATION")
            {
                RegistrationTextBox.ForeColor = Color.Black;
                RegistrationTextBox.Text = "";
            }
        }

        private void RegistrationTextBox_Leave(object sender, EventArgs e)
        {
            if (RegistrationTextBox.Text.Length == 0)
            {
                RegistrationTextBox.ForeColor = Color.LightGray;
                RegistrationTextBox.Text = "REGISTRATION";
            }
        }

        private void TicketIdTextBox_Enter(object sender, EventArgs e)
        {
            if (UserIdTextBox.Text == "Enter user ID")
            {
                UserIdTextBox.ForeColor = Color.Black;
                UserIdTextBox.Text = "";
            }
        }

        private void TicketIdTextBox_Leave(object sender, EventArgs e)
        {
            if (UserIdTextBox.Text.Length == 0)
            {
                UserIdTextBox.ForeColor = Color.LightGray;
                UserIdTextBox.Text = "Enter user ID";
            }
        }
    }
}
