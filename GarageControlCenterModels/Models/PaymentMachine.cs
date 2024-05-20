namespace GarageControlCenterModels.Models
{
    public class PaymentMachine
    {
        private static decimal Rate = 0.8M;
        private static int GracePeriod = 10;
        public void MarkTicketPaid(Ticket ticket)
        {
            ticket.IsPaid = true;
        }

        public decimal CalculateTotalPrice(Ticket ticket)
        {
            // Calculate the time elapsed since the entrance time in minutes
            TimeSpan elapsedTime = DateTime.Now - ticket.EntranceTime;
            int totalElapsedMinutes = (int)Math.Ceiling(elapsedTime.TotalMinutes);

            // Calculate the total hours of elapsed time
            int totalHours = totalElapsedMinutes / 60;

            // Check if the minutes after the nearest hour are within the grace period
            int minutesAfterHour = totalElapsedMinutes % 60;
            if (minutesAfterHour < GracePeriod)
            {
                // If within the grace period, charge for the exact number of hours elapsed
                decimal totalPrice = totalHours * Rate;
                return totalPrice;
            }
            else
            {
                // If beyond the grace period, charge for the next hour
                decimal totalPrice = (totalHours + 1) * Rate;
                return totalPrice;
            }
        }
    }
}
