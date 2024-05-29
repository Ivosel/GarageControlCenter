using GarageControlCenterBackend.Models;
using GarageControlCenterBackend.Services;
using System.ComponentModel;

namespace GarageControlCenterUI
{
    public partial class UsersForm : Form
    {
        private readonly List<GarageUser> users;
        private bool newTicketFlag;
        private readonly BindingList<GarageUser> bindingUserList;
        private readonly BindingSource userBindingSource;
        private readonly UserService userService;

        public UsersForm(List<GarageUser> garageUsers, UserService service)
        {
            users = garageUsers;
            userService = service;
            InitializeComponent();
            ClearTicketControls();
            ClearUserControls();

            bindingUserList = new BindingList<GarageUser>(users);
            userBindingSource = new BindingSource(bindingUserList, null);
            usersListBox.DataSource = userBindingSource;
            SortUsersAlphabetically();
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
                switch (ctrl)
                {
                    case TextBox textBox:
                        textBox.Clear();
                        textBox.Visible = false;
                        break;
                    case MaskedTextBox maskedBox:
                        maskedBox.Visible = false;
                        break;
                    case ComboBox comboBox:
                        comboBox.SelectedIndex = -1;
                        comboBox.Visible = false;
                        break;
                    case CheckBox checkBox:
                        checkBox.Checked = false;
                        checkBox.Visible = false;
                        break;
                    case Label label:
                        label.Visible = false;
                        break;
                }
            }
        }

        private void ShowTicketControls()
        {
            foreach (Control ctrl in ticketTabPage.Controls)
            {
                ctrl.Visible = true;
            }
        }

        private async void saveChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                var existingUser = users.FirstOrDefault(u => u.Id.ToString() == userIdTextBox.Text);

                if (existingUser != null)
                {
                    UpdateExistingUser(existingUser);
                    await userService.UpdateUserAsync(existingUser); // Update user in the database
                    if (existingUser.UserTicket != null)
                    {
                        ticketNumberTextBox.Text = existingUser.UserTicket.Id.ToString();
                    }
                }

                else
                {
                    var newUser = CreateUser();
                    await userService.AddUserAsync(newUser); // Add new user to the database
                    userIdTextBox.Text = newUser.Id.ToString();
                    if (newUser.UserTicket != null)
                    {
                        ticketNumberTextBox.Text = newUser.UserTicket.Id.ToString();
                    }
                }

                SortUsersAlphabetically();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving changes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateExistingUser(GarageUser existingUser)
        {
            existingUser.UpdateUser(
                lastNameTextBox.Text,
                firstNameTextBox.Text,
                phoneNumberTextBox.Text,
                emailTextBox.Text,
                registrationPlateTextBox.Text);

            if (newTicketFlag)
            {
                existingUser.AssignTicket(CreateTicket());
                ticketNumberTextBox.Text = existingUser.UserTicket.Id.ToString();
                newTicketFlag = false;
            }
            else if (existingUser.UserTicket != null)
            {
                HandleTicketUpdates(existingUser);
            }
        }

        private void HandleTicketUpdates(GarageUser existingUser)
        {
            if (deleteTicketCheckBox.Checked)
            {
                existingUser.RemoveTicket();
                ClearTicketControls();
            }

            else
            {
                var extendDate = DateTime.ParseExact(validUntilTextBox.Text, "dd.MM.yy.", System.Globalization.CultureInfo.InvariantCulture);
                existingUser.UserTicket.ExtendTicket(extendDate);

                var type = ticketTypeComboBox.SelectedIndex switch
                {
                    0 => TicketType.WholeDay,
                    1 => TicketType.DayShift,
                    2 => TicketType.NightShift,
                    _ => TicketType.WholeDay,
                };

                existingUser.UserTicket.ChangeTicketType(type);

                if (neutralCheckBox.Checked)
                {
                    existingUser.UserTicket.SetToNeutral();
                }

                if (blockCheckBox.Checked)
                {
                    existingUser.UserTicket.BlockTicket();
                }

                else
                {
                    existingUser.UserTicket.UnblockTicket();
                }
            }
        }

        private GarageUser CreateUser()
        {
            var createdUser = new GarageUser(
                lastNameTextBox.Text,
                firstNameTextBox.Text,
                phoneNumberTextBox.Text,
                emailTextBox.Text,
                registrationPlateTextBox.Text);

            if (newTicketFlag)
            {
                createdUser.AssignTicket(CreateTicket());
                newTicketFlag = false;
            }
            users.Add(createdUser);
            SortUsersAlphabetically();

            return createdUser;
        }

        private UserTicket CreateTicket()
        {
            var from = DateTime.ParseExact(validFromTextBox.Text, "dd.MM.yy.", System.Globalization.CultureInfo.InvariantCulture);
            var until = DateTime.ParseExact(validUntilTextBox.Text, "dd.MM.yy.", System.Globalization.CultureInfo.InvariantCulture);
            var type = ticketTypeComboBox.SelectedIndex switch
            {
                0 => TicketType.WholeDay,
                1 => TicketType.DayShift,
                2 => TicketType.NightShift,
                _ => TicketType.WholeDay,
            };

            return new UserTicket(from, until, type);
        }

        private void UsersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (usersListBox.SelectedItem is GarageUser selectedUser)
            {
                PopulateUserControls(selectedUser);
            }
        }

        private void PopulateUserControls(GarageUser selectedUser)
        {
            firstNameTextBox.Text = selectedUser.FirstName;
            lastNameTextBox.Text = selectedUser.LastName;
            userIdTextBox.Text = selectedUser.Id.ToString();
            phoneNumberTextBox.Text = selectedUser.PhoneNumber;
            emailTextBox.Text = selectedUser.Email;
            registrationPlateTextBox.Text = selectedUser.RegistrationPlate;

            if (selectedUser.UserTicket != null)
            {
                PopulateTicketControls(selectedUser.UserTicket);
            }

            else
            {
                ClearTicketControls();
            }
        }

        private void PopulateTicketControls(UserTicket ticket)
        {
            ticketNumberTextBox.Text = ticket.Id.ToString();
            validFromTextBox.Text = ticket.ValidFrom.ToString("dd.MM.yy.");
            validUntilTextBox.Text = ticket.ValidUntil.ToString("dd.MM.yy.");
            ticketTypeComboBox.SelectedIndex = ticket.Type switch
            {
                TicketType.WholeDay => 0,
                TicketType.DayShift => 1,
                TicketType.NightShift => 2,
                _ => -1,
            };
            blockCheckBox.Checked = ticket.isBlocked;

            ShowTicketControls();
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
            ClearTicketControls();
        }

        private void newTicketButton_Click(object sender, EventArgs e)
        {
            if (usersListBox.SelectedItem != null)
            {
                var from = DateOnly.FromDateTime(DateTime.Now);
                var until = from.AddMonths(1).AddDays(-1);

                validFromTextBox.Text = from.ToString("dd.MM.yy");
                validUntilTextBox.Text = until.ToString("dd.MM.yy");
                ticketTypeComboBox.SelectedIndex = 0;
                newTicketFlag = true;

                ShowTicketControls();
            }
        }

        private async void deleteUserButton_Click(object sender, EventArgs e)
        {
            if (usersListBox.SelectedItem is GarageUser selectedUser)
            {
                users.Remove(selectedUser);
                ClearUserControls();
                ClearTicketControls();
                await userService.DeleteUserAsync(selectedUser.Id); // Delete user from the database
                SortUsersAlphabetically();
            }
        }

        private void SortUsersAlphabetically()
        {
            users.Sort((x, y) => string.Compare(x.LastName, y.LastName));
            bindingUserList.ResetBindings();
        }
    }
}
