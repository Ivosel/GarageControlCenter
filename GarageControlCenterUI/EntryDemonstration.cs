﻿using GarageControlCenterBackend.Models;
using GarageControlCenterBackend.Services;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace GarageControlCenterUI
{
    // A form to demonstrate an entrance to the garage
    public partial class EntryDemonstration : Form
    {
        private Garage MyGarage;
        private GarageService Service;
        EntranceBarrier Entrance { get; set; }
        public event EventHandler<CustomerEntryEventArgs> CustomerEntry;

        public EntryDemonstration(Garage myGarage, GarageService service)
        {
            MyGarage = myGarage;
            Service = service;
            Entrance = new EntranceBarrier();
            InitializeComponent();
        }

        private async void TakeTicketButton_Click(object sender, EventArgs e)
        {

            // Find levels with available spots
            List<Level> availableLevels = MyGarage.Levels.Where(level => level.FreeSpots() > 0).ToList();

            if (availableLevels.Count > 0)
            {
                Ticket ticket = Entrance.IssueTicket();
                MyGarage.Tickets.Add(ticket);
                await Service.AddTicketAsync(ticket);
                UpdateParkingSpot(availableLevels);
                Entrance.OpenBarrier();
            }

            else
            {
                // Handle case where all levels are full
                MessageBox.Show("No available spots in the garage.");
            }

            Entrance.CloseBarrier();
        }

        private void UpdateParkingSpot(List<Level> availableLevels)
        {
            // Randomly select a level from the available levels
            Random random = new Random();
            int randomLevelIndex = random.Next(availableLevels.Count);
            Level chosenLevelObject = availableLevels[randomLevelIndex];

            // Filter spots that are not occupied in the chosen level
            List<ParkingSpot> availableSpots = chosenLevelObject.Spots.Where(spot => !spot.IsOccupied).ToList();

            // Select a random spot from the available spots
            int randomSpotIndex = random.Next(availableSpots.Count);
            ParkingSpot chosenSpot = availableSpots[randomSpotIndex];
            chosenSpot.ReserveSpot();
            CustomerEntry?.Invoke(this, new CustomerEntryEventArgs(chosenSpot));
            Entrance.CloseBarrier();
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
