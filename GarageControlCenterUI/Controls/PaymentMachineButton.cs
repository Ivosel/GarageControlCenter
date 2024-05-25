using GarageControlCenterBackend.Models;

namespace GarageControlCenterUI.Controls
{
    // A user control representing a payment machine button
    public partial class PaymentMachineButton : Button
    {
        PaymentMachine Machine;
        MainForm MainForm;
        TextBox ticketNumberTextBox;

        public PaymentMachineButton(MainForm mainForm)
        {
            Machine = new PaymentMachine();
            MainForm = mainForm;
            InitializeButton();
        }

        private void InitializeButton()
        {
            BackColor = Color.White;
            Size = new Size(200, 180);
            Margin = new Padding(20, 3, 3, 3);

            // Create a panel to contain the button elements
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(3)
            };

            // Create a TableLayoutPanel to organize button elements
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                RowCount = 6,
                ColumnCount = 1,
                AutoSize = true
            };

            // Create a PictureBox to display an icon
            PictureBox pictureBox = new PictureBox
            {
                Margin = new Padding(0, 10, 0, 0),
                Anchor = AnchorStyles.None,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Resources.PaymentMachineIcon
            };

            // Create a label for the payment machine name
            Label nameLabel = CreateLabel($"Payment Machine", FontStyle.Bold, ContentAlignment.MiddleCenter, 14);
            nameLabel.Dock = DockStyle.Top;

            // Create a label for entering ticket number
            Label enterTicketNumberLabel = CreateLabel($"Enter ticket number:", FontStyle.Bold, ContentAlignment.MiddleCenter, 12);
            nameLabel.Dock = DockStyle.Top;
            enterTicketNumberLabel.Anchor = AnchorStyles.Top;
            enterTicketNumberLabel.Width = (int)(tableLayoutPanel.Width * 0.5);

            // Create a button for inserting a ticket
            Button insertTicketButton = CreateButton("Insert Ticket");
            insertTicketButton.Anchor = AnchorStyles.Top;
            insertTicketButton.Width = (int)(tableLayoutPanel.Width * 0.5);
            insertTicketButton.Click += InsertTicketButton_Click;

            // Create a TextBox for entering ticket number
            ticketNumberTextBox = new TextBox();
            ticketNumberTextBox.Anchor = AnchorStyles.Top;

            // Add controls to the TableLayoutPanel
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.Controls.Add(pictureBox, 0, 0);
            tableLayoutPanel.Controls.Add(nameLabel, 0, 1);
            tableLayoutPanel.Controls.Add(enterTicketNumberLabel, 0, 2);
            tableLayoutPanel.Controls.Add(ticketNumberTextBox, 0, 3);
            tableLayoutPanel.Controls.Add(insertTicketButton, 0, 4);

            // Add TableLayoutPanel to the panel
            panel.Controls.Add(tableLayoutPanel);
            Controls.Add(panel);
        }

        // Event handler for the insert ticket button click event
        private void InsertTicketButton_Click(object sender, EventArgs e)
        {
            string ticketNumber = ticketNumberTextBox.Text;
            Ticket ticket = MainForm.myGarage.Tickets.FirstOrDefault(t => t.TicketNumber == ticketNumber);

            // Check if the ticket exists
            if (ticket != null)
            {
                // Handle unpaid ticket
                if (!ticket.IsPaid)
                {
                    HandleUnpaidTicket(ticket);
                }
                else
                {
                    ShowMessage("Ticket already paid!", "Ticket Already Paid", MessageBoxIcon.Information);
                }
            }
            else
            {
                ShowMessage("Ticket number not valid!", "Ticket Not Valid", MessageBoxIcon.Information);
            }

            // Clear the ticket number TextBox
            ticketNumberTextBox.Clear();
        }

        // Handle an unpaid ticket
        private async void HandleUnpaidTicket(Ticket ticket)
        {
            decimal price = Machine.CalculateTotalPrice(ticket);

            // If the price is 0, the ticket is within the grace period
            if (price == 0)
            {
                // Mark the ticket as paid and refresh tickets
                ShowMessage("You are within our grace period, you may exit free of charge!", "Grace Period", MessageBoxIcon.Information);
                ticket.MarkTicketPaid();
                await MainForm.garageService.UpdateTicketAsync(ticket);
                MainForm.ticketsForm.RefreshTickets();
                return;
            }

            // Show confirmation dialog for payment
            DialogResult result = ShowConfirmation($"Please pay {price.ToString("0.00")}€", "Confirmation");

            // Process payment based on user response
            if (result == DialogResult.Yes)
            {
                ticket.MarkTicketPaid();
                await MainForm.garageService.UpdateTicketAsync(ticket);
                MainForm.ticketsForm.RefreshTickets();
                ShowMessage("Payment accepted, please remove your ticket!", "Payment Accepted", MessageBoxIcon.Information);
            }
            else
            {
                ShowMessage("Operation canceled!", "Operation Canceled", MessageBoxIcon.Information);
            }
        }

        // Create a label with specified properties
        private Label CreateLabel(string text, FontStyle style, ContentAlignment alignment, int fontSize)
        {
            var label = new Label
            {
                Text = text,
                AutoSize = true,
                TextAlign = alignment,
                Font = new Font("Arial", fontSize, style)
            };
            return label;
        }

        // Create a button with specified text
        private Button CreateButton(string text)
        {
            var button = new Button
            {
                Text = text,
            };
            return button;
        }

        // Show a confirmation dialog
        private DialogResult ShowConfirmation(string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        // Show a message dialog
        private void ShowMessage(string message, string caption, MessageBoxIcon icon)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
        }
    }
}
