using GarageControlCenterBackend.Models;

namespace GarageControlCenterUI.Controls
{
    // A user control representing a payment machine button
    public partial class PaymentMachineButton : Button
    {
        PaymentMachine Machine;
        TextBox ticketNumberTextBox;
        TextBox userIdTextBox;
        TicketsForm ticketsForm;

        public PaymentMachineButton(PaymentMachine machine, TicketsForm form)
        {
            InitializeButton();
            Machine = machine;
            ticketsForm = form;
        }

        private void InitializeButton()
        {
            BackColor = Color.White;
            Size = new Size(200, 240);
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
            enterTicketNumberLabel.Anchor = AnchorStyles.Top;
            enterTicketNumberLabel.Width = (int)(tableLayoutPanel.Width * 0.5);
            enterTicketNumberLabel.Margin = new Padding(0, 10, 0, 0);

            Label enterUserIdLabel = CreateLabel($"or user ID:", FontStyle.Bold, ContentAlignment.MiddleCenter, 12);
            enterUserIdLabel.Anchor = AnchorStyles.Top;
            enterUserIdLabel.Width = (int)(tableLayoutPanel.Width * 0.5);

            // Create a button for inserting a ticket
            Button insertTicketButton = CreateButton("Insert Ticket");
            insertTicketButton.Anchor = AnchorStyles.Top;
            insertTicketButton.Width = (int)(tableLayoutPanel.Width * 0.5);
            insertTicketButton.Click += async (sender, e) => await InsertTicketButton_Click(sender, e); ;

            // Create TextBoxes for entering ticket numbers and user IDs
            ticketNumberTextBox = new TextBox();
            ticketNumberTextBox.Anchor = AnchorStyles.Top;
            ticketNumberTextBox.TextAlign = HorizontalAlignment.Center;
            userIdTextBox = new TextBox();
            userIdTextBox.Anchor = AnchorStyles.Top;
            userIdTextBox.TextAlign = HorizontalAlignment.Center;

            // Add controls to the TableLayoutPanel
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.Controls.Add(pictureBox, 0, 0);
            tableLayoutPanel.Controls.Add(nameLabel, 0, 1);
            tableLayoutPanel.Controls.Add(enterTicketNumberLabel, 0, 2);
            tableLayoutPanel.Controls.Add(ticketNumberTextBox, 0, 3);
            tableLayoutPanel.Controls.Add(enterUserIdLabel, 0, 4);
            tableLayoutPanel.Controls.Add(userIdTextBox, 0, 5);
            tableLayoutPanel.Controls.Add(insertTicketButton, 0, 6);

            // Add TableLayoutPanel to the panel
            panel.Controls.Add(tableLayoutPanel);
            Controls.Add(panel);
        }

        // Event handler for the insert ticket button click event
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
                    await Machine.CheckTicket(ticketNumber);
                }

                else
                {
                    await Machine.CheckUserTicket(userId);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            finally
            {
                // Clear the ticket number TextBox and refresh the tickets form
                ticketNumberTextBox.Clear();
                userIdTextBox.Clear();
                ticketsForm.RefreshTickets();
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
    }
}
