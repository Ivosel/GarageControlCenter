using GarageControlCenterModels.Models;
using System.ComponentModel;

namespace GarageControlCenterUI
{
    public partial class UsersForm : Form
    {
        public List<User> users = new List<User>();
        private bool newTicketFlag = false;
        private BindingList<User> bindingUserList;
        private BindingSource userBindingSource;


        public UsersForm(List<User> garageUsers)
        {
            users = garageUsers;
            InitializeComponent();
            ClearTicketControls();
            ClearUserControls();

            bindingUserList = new BindingList<User>(users);
            userBindingSource = new BindingSource(bindingUserList, null);
            usersListBox.DataSource = userBindingSource;
        }

        private void ClearUserControls()
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl is TextBox textBox)
                {
                    textBox.Clear();
                }
            }
        }

        private void ClearTicketControls()
        {
            foreach (Control ctrl in ticketTabPage.Controls)
            {
                if (ctrl is TextBox textBox)
                {
                    textBox.Clear();
                    textBox.Visible = false;
                }
                else if (ctrl is MaskedTextBox maskedBox)
                {
                    maskedBox.Visible = false;
                }
                else if (ctrl is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = -1;
                    comboBox.Visible = false;
                }
                else if (ctrl is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                    checkBox.Visible = false;
                }
                else if (ctrl is Label label)
                {
                    label.Visible = false;
                }
            }
        }

        private void ShowTicketControls()
        {
            foreach (Control ctrl in ticketTabPage.Controls)
            {
                if (ctrl is TextBox textBox)
                {
                    textBox.Visible = true;
                }
                else if (ctrl is MaskedTextBox maskedBox)
                {
                    maskedBox.Visible = true;
                }
                else if (ctrl is ComboBox comboBox)
                {
                    comboBox.Visible = true;
                }
                else if (ctrl is CheckBox checkBox)
                {
                    checkBox.Visible = true;
                }
                else if (ctrl is Label label)
                {
                    label.Visible = true;
                }
            }
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            User existingUser = users.FirstOrDefault(u => u.Id.ToString() == userIdTextBox.Text);

            if (existingUser != null)
            {
                existingUser.FirstName = firstNameTextBox.Text;
                existingUser.LastName = lastNameTextBox.Text;
                existingUser.PhoneNumber = phoneNumberTextBox.Text;
                existingUser.Email = emailTextBox.Text;
                existingUser.RegistrationPlate = registrationPlateTextBox.Text;
                if (newTicketFlag)
                {
                    existingUser.AssignTicket(CreateTicket());
                    newTicketFlag = false;
                }
                else if (existingUser.UserTicket != null)
                {
                    existingUser.UserTicket.ValidUntil = DateTime.ParseExact(validUntilTextBox.Text, "dd.MM.yy.", System.Globalization.CultureInfo.InvariantCulture);
                    existingUser.UserTicket.isBlocked = blockCheckBox.Checked;
                    if (deleteTicketCheckBox.Checked) 
                    { 
                        existingUser.UserTicket = null;
                        ClearTicketControls();
                    }
                    if (neutralCheckBox.Checked) { existingUser.UserTicket.State = TicketState.Neutral; }
                }
            }

            else
            {
                User createdUser = new User(lastNameTextBox.Text, firstNameTextBox.Text, phoneNumberTextBox.Text, emailTextBox.Text, registrationPlateTextBox.Text);
                userIdTextBox.Text = createdUser.Id.ToString();
                if (newTicketFlag)
                {
                    createdUser.AssignTicket(CreateTicket());
                    newTicketFlag = false;
                }
                users.Add(createdUser);
            }

            bindingUserList.ResetBindings();
        }

        private UserTicket CreateTicket()
        {
            UserTicket ticket = new UserTicket();
            ticket.ValidFrom = DateTime.ParseExact(validFromTextBox.Text, "dd.MM.yy.", System.Globalization.CultureInfo.InvariantCulture);
            ticket.ValidUntil = DateTime.ParseExact(validUntilTextBox.Text, "dd.MM.yy.", System.Globalization.CultureInfo.InvariantCulture);
            switch (ticketTypeComboBox.SelectedIndex)
            {
                case 0:
                    ticket.Type = TicketType.WholeDay;
                    break;
                case 1:
                    ticket.Type = TicketType.DayShift;
                    break;
                case 2:
                    ticket.Type = TicketType.NightShift;
                    break;
                default:
                    break;
            }

            return ticket;
        }

        private void usersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            User selectedUser = (User)usersListBox.SelectedItem;

            firstNameTextBox.Text = selectedUser.FirstName;
            lastNameTextBox.Text = selectedUser.LastName;
            userIdTextBox.Text = selectedUser.Id.ToString();
            phoneNumberTextBox.Text = selectedUser.PhoneNumber;
            emailTextBox.Text = selectedUser.Email;
            registrationPlateTextBox.Text = selectedUser.RegistrationPlate;
            UserTicket ticket = selectedUser.UserTicket;

            if (ticket != null)
            {
                ticketNumberTextBox.Text = ticket.Number;
                validFromTextBox.Text = ticket.ValidFrom.ToString("dd.MM.yy.");
                validUntilTextBox.Text = ticket.ValidUntil.ToString("dd.MM.yy.");
                ticketNumberTextBox.Text = ticket.Id.ToString();
                switch (ticket.Type)
                {
                    case TicketType.WholeDay:
                        ticketTypeComboBox.SelectedIndex = 0;
                        break;
                    case TicketType.DayShift:
                        ticketTypeComboBox.SelectedIndex = 1;
                        break;
                    case TicketType.NightShift:
                        ticketTypeComboBox.SelectedIndex = 2;
                        break;
                    default:
                        break;
                }

                blockCheckBox.Checked = ticket.isBlocked;

                ShowTicketControls();
            }
            else
            {
                ClearTicketControls();
            }
        }

        private void UsersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {
            ClearUserControls();
        }

        private void newTicketButton_Click(object sender, EventArgs e)
        {
            DateOnly from = DateOnly.FromDateTime(DateTime.Now);
            DateOnly until = from.AddMonths(1).AddDays(-1);

            if (usersListBox.SelectedItem != null)
            {
                validFromTextBox.Text = from.ToString("dd.MM.yy");
                validUntilTextBox.Text = until.ToString("dd.MM.yy");
                ticketTypeComboBox.SelectedIndex = 0;
                newTicketFlag = true;
                ShowTicketControls();
            }
        }

        private void deleteUserButton_Click(object sender, EventArgs e)
        {
            if (usersListBox.SelectedItem != null)
            {
                var selectedUser = (User)usersListBox.SelectedItem;
                users.Remove(selectedUser);
                ClearUserControls();
                ClearTicketControls();
                bindingUserList.ResetBindings();
            }
        }
    }
}
