using GarageControlCenterBackend.Services;

namespace GarageControlCenterBackend.Models
{
    public class PaymentMachine
    {
        private static decimal Rate = 0.8M;
        private static int GracePeriod = 10;
        private Garage MyGarage;
        private UserService UserService;
        private GarageService GarageService;

        public PaymentMachine(Garage garage, UserService userService, GarageService garageService)
        {
            MyGarage = garage;
            UserService = userService;
            GarageService = garageService;
        }

        public decimal CalculateTotalPrice(Ticket ticket)
        {
            TimeSpan elapsedTime = DateTime.Now - ticket.EntranceTime;
            int totalElapsedMinutes = (int)Math.Ceiling(elapsedTime.TotalMinutes);

            int totalHours = totalElapsedMinutes / 60;
            int minutesAfterHour = totalElapsedMinutes % 60;

            decimal totalPrice = (minutesAfterHour < GracePeriod) ? totalHours * Rate : (totalHours + 1) * Rate;
            return totalPrice;
        }

        public async Task CheckTicket(int ticketNumber)
        {
            Ticket ticket = MyGarage.GetTicket(ticketNumber);

            if (ticket == null)
            {
                ShowMessage("Ticket not found!", "Error", MessageBoxIcon.Error);
                return;
            }

            if (ticket.IsPaid)
            {
                ShowMessage("Ticket already paid!", "Error", MessageBoxIcon.Error);
                return;
            }

            await HandleUnpaidTicket(ticket);
        }

        public async Task HandleUnpaidTicket(Ticket ticket)
        {
            decimal price = CalculateTotalPrice(ticket);

            if (price == 0)
            {
                ShowMessage("You are within our grace period, you may exit free of charge!", "Grace Period", MessageBoxIcon.Information);
                ticket.MarkTicketPaid();
                await GarageService.UpdateTicketAsync(ticket);
                return;
            }

            DialogResult result = ShowConfirmation($"Please pay {price.ToString("0.00")}€", "Confirmation");

            if (result == DialogResult.Yes)
            {
                ticket.MarkTicketPaid();
                await GarageService.UpdateTicketAsync(ticket);
                ShowMessage("Payment accepted, please remove your ticket!", "Payment Accepted", MessageBoxIcon.Information);
            }
            else
            {
                ShowMessage("Operation canceled!", "Operation Canceled", MessageBoxIcon.Information);
            }
        }

        public async Task CheckUserTicket(int userId)
        {
            var user = MyGarage.GetUser(userId);

            if (user.UserTicket == null)
            {
                ShowMessage("User doesn't have a ticket!", "Error", MessageBoxIcon.Error);
                return;
            }

            if (user.UserTicket.GetUncoveredHours() == 0)
            {
                ShowMessage("Ticket is paid!", "Error", MessageBoxIcon.Error);
                return;
            }

            await HandleUnpaidUserTicket(user);
        }

        public async Task HandleUnpaidUserTicket(GarageUser user)
        {
            if (user.UserTicket.GetUncoveredHours() == -1)
            {
                user.UserTicket.CalculateUncoveredHours();
            }

            decimal price = user.UserTicket.GetUncoveredHours() * Rate;

            if (price == 0)
            {
                ShowMessage("You may exit the garage!", "Ticket paid", MessageBoxIcon.Information);
                user.UserTicket.ResetUncoveredHours();
                await UserService.UpdateUserAsync(user);
                return;
            }

            DialogResult result = ShowConfirmation($"Please pay {price.ToString("0.00")}€", "Confirmation");

            if (result == DialogResult.Yes)
            {
                user.UserTicket.ResetUncoveredHours();
                await UserService.UpdateUserAsync(user);
                ShowMessage("Payment accepted, please remove your ticket!", "Payment Accepted", MessageBoxIcon.Information);
            }
            else
            {
                ShowMessage("Operation canceled!", "Operation Canceled", MessageBoxIcon.Information);
            }
        }

        private DialogResult ShowConfirmation(string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void ShowMessage(string message, string caption, MessageBoxIcon icon)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
        }
    }
}