﻿using GarageControlCenterBackend.Models;
using GarageControlCenterBackend.Services;
using System;
using System.Data;

namespace GarageControlCenterUI
{
    // A form to demonstrate an entrance to the garage
    public partial class EntryDemonstration : Form
    {
        private readonly Garage myGarage;
        private readonly GarageService service;
        private readonly Random random;
        EntranceBarrier Entrance { get; }

        public event EventHandler<CustomerEntryEventArgs> CustomerEntry;

        public EntryDemonstration(Garage garage, GarageService garageService)
        {
            myGarage = garage;
            service = garageService;
            random = new Random();
            Entrance = new EntranceBarrier();
            InitializeComponent();
        }

        private async void TakeTicketButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Find levels with available spots
                var availableLevels = myGarage.Levels.Where(level => level.FreeSpots() > 0).ToList();

                if (availableLevels.Count > 0)
                {
                    var ticket = Entrance.IssueTicket(RegistrationTextBox.Text);
                    myGarage.Tickets.Add(ticket);
                    await service.AddTicketAsync(ticket);
                    UpdateParkingSpot(availableLevels);
                    Entrance.OpenBarrier();
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
                RegistrationTextBox.Text = "Registration";
                Entrance.CloseBarrier();
            }
        }

        private void UpdateParkingSpot(List<Level> availableLevels)
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

            CustomerEntry?.Invoke(this, new CustomerEntryEventArgs(chosenSpot));
        }

        private void InsertTicketButton_Click(object sender, EventArgs e)
        {
            //TODO Implement Insert ticket button for prepaid customers
        }

        public class CustomerEntryEventArgs : EventArgs
        {
            public ParkingSpot ChosenSpot { get; }

            public CustomerEntryEventArgs(ParkingSpot spot)
            {
                ChosenSpot = spot;
            }
        }

        public void SubscribeToCustomerEntryEvent(EventHandler<CustomerEntryEventArgs> handler)
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
    }
}
