namespace GarageControlCenterUI
{
    partial class UsersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            usersListBox = new ListBox();
            firstNameTextBox = new TextBox();
            lastNameTextBox = new TextBox();
            phoneNumberTextBox = new TextBox();
            emailTextBox = new TextBox();
            ticketHistoryTabControl = new TabControl();
            ticketTabPage = new TabPage();
            validUntilTextBox = new MaskedTextBox();
            validFromTextBox = new MaskedTextBox();
            ticketNumberLabel = new Label();
            ticketNumberTextBox = new TextBox();
            ticketTypeLabel = new Label();
            ticketTypeComboBox = new ComboBox();
            deleteTicketCheckBox = new CheckBox();
            blockCheckBox = new CheckBox();
            neutralCheckBox = new CheckBox();
            validUntilLabel = new Label();
            validFromLabel = new Label();
            historyTabPage = new TabPage();
            usersLabel = new Label();
            lastNameLabel = new Label();
            firstNameLabel = new Label();
            phoneNumberLabel = new Label();
            emailLabel = new Label();
            userIdTextBox = new TextBox();
            registrationPlateTextBox = new TextBox();
            userIdLabel = new Label();
            registrationPlateLabel = new Label();
            deleteUserButton = new Button();
            newTicketButton = new Button();
            saveChangesButton = new Button();
            newUserButton = new Button();
            ticketHistoryTabControl.SuspendLayout();
            ticketTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // usersListBox
            // 
            usersListBox.FormattingEnabled = true;
            usersListBox.ItemHeight = 15;
            usersListBox.Location = new Point(5, 26);
            usersListBox.Name = "usersListBox";
            usersListBox.Size = new Size(165, 379);
            usersListBox.TabIndex = 12;
            usersListBox.SelectedIndexChanged += UsersListBox_SelectedIndexChanged;
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(506, 27);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(263, 23);
            firstNameTextBox.TabIndex = 1;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.BackColor = Color.FromArgb(255, 255, 192);
            lastNameTextBox.Location = new Point(189, 27);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(263, 23);
            lastNameTextBox.TabIndex = 0;
            // 
            // phoneNumberTextBox
            // 
            phoneNumberTextBox.Location = new Point(189, 82);
            phoneNumberTextBox.Name = "phoneNumberTextBox";
            phoneNumberTextBox.Size = new Size(263, 23);
            phoneNumberTextBox.TabIndex = 2;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(506, 82);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(263, 23);
            emailTextBox.TabIndex = 3;
            // 
            // ticketHistoryTabControl
            // 
            ticketHistoryTabControl.Controls.Add(ticketTabPage);
            ticketHistoryTabControl.Controls.Add(historyTabPage);
            ticketHistoryTabControl.Location = new Point(189, 168);
            ticketHistoryTabControl.Name = "ticketHistoryTabControl";
            ticketHistoryTabControl.SelectedIndex = 0;
            ticketHistoryTabControl.Size = new Size(580, 237);
            ticketHistoryTabControl.TabIndex = 5;
            // 
            // ticketTabPage
            // 
            ticketTabPage.Controls.Add(validUntilTextBox);
            ticketTabPage.Controls.Add(validFromTextBox);
            ticketTabPage.Controls.Add(ticketNumberLabel);
            ticketTabPage.Controls.Add(ticketNumberTextBox);
            ticketTabPage.Controls.Add(ticketTypeLabel);
            ticketTabPage.Controls.Add(ticketTypeComboBox);
            ticketTabPage.Controls.Add(deleteTicketCheckBox);
            ticketTabPage.Controls.Add(blockCheckBox);
            ticketTabPage.Controls.Add(neutralCheckBox);
            ticketTabPage.Controls.Add(validUntilLabel);
            ticketTabPage.Controls.Add(validFromLabel);
            ticketTabPage.Location = new Point(4, 24);
            ticketTabPage.Name = "ticketTabPage";
            ticketTabPage.Padding = new Padding(3);
            ticketTabPage.Size = new Size(572, 209);
            ticketTabPage.TabIndex = 0;
            ticketTabPage.Text = "Ticket";
            // 
            // validUntilTextBox
            // 
            validUntilTextBox.Location = new Point(447, 25);
            validUntilTextBox.Mask = "00,00,00,";
            validUntilTextBox.Name = "validUntilTextBox";
            validUntilTextBox.Size = new Size(119, 23);
            validUntilTextBox.TabIndex = 5;
            // 
            // validFromTextBox
            // 
            validFromTextBox.Location = new Point(313, 25);
            validFromTextBox.Mask = "00,00,00,";
            validFromTextBox.Name = "validFromTextBox";
            validFromTextBox.ReadOnly = true;
            validFromTextBox.Size = new Size(119, 23);
            validFromTextBox.TabIndex = 11;
            // 
            // ticketNumberLabel
            // 
            ticketNumberLabel.AutoSize = true;
            ticketNumberLabel.Location = new Point(22, 59);
            ticketNumberLabel.Name = "ticketNumberLabel";
            ticketNumberLabel.Size = new Size(83, 15);
            ticketNumberLabel.TabIndex = 10;
            ticketNumberLabel.Text = "Ticket number";
            // 
            // ticketNumberTextBox
            // 
            ticketNumberTextBox.Location = new Point(22, 77);
            ticketNumberTextBox.Name = "ticketNumberTextBox";
            ticketNumberTextBox.ReadOnly = true;
            ticketNumberTextBox.Size = new Size(201, 23);
            ticketNumberTextBox.TabIndex = 9;
            // 
            // ticketTypeLabel
            // 
            ticketTypeLabel.AutoSize = true;
            ticketTypeLabel.Location = new Point(19, 7);
            ticketTypeLabel.Name = "ticketTypeLabel";
            ticketTypeLabel.Size = new Size(64, 15);
            ticketTypeLabel.TabIndex = 8;
            ticketTypeLabel.Text = "Ticket type";
            // 
            // ticketTypeComboBox
            // 
            ticketTypeComboBox.FormattingEnabled = true;
            ticketTypeComboBox.Items.AddRange(new object[] { "Monthly whole day 00h-24h", "Monthly day shift 06h-18h", "Monthly night shift 18h-06h" });
            ticketTypeComboBox.Location = new Point(19, 25);
            ticketTypeComboBox.Name = "ticketTypeComboBox";
            ticketTypeComboBox.Size = new Size(204, 23);
            ticketTypeComboBox.TabIndex = 7;
            // 
            // deleteTicketCheckBox
            // 
            deleteTicketCheckBox.AutoSize = true;
            deleteTicketCheckBox.Location = new Point(313, 153);
            deleteTicketCheckBox.Name = "deleteTicketCheckBox";
            deleteTicketCheckBox.Size = new Size(91, 19);
            deleteTicketCheckBox.TabIndex = 8;
            deleteTicketCheckBox.Text = "Delete ticket";
            deleteTicketCheckBox.UseVisualStyleBackColor = true;
            // 
            // blockCheckBox
            // 
            blockCheckBox.AutoSize = true;
            blockCheckBox.Location = new Point(313, 115);
            blockCheckBox.Name = "blockCheckBox";
            blockCheckBox.Size = new Size(87, 19);
            blockCheckBox.TabIndex = 7;
            blockCheckBox.Text = "Block ticket";
            blockCheckBox.UseVisualStyleBackColor = true;
            // 
            // neutralCheckBox
            // 
            neutralCheckBox.AutoSize = true;
            neutralCheckBox.Location = new Point(313, 77);
            neutralCheckBox.Name = "neutralCheckBox";
            neutralCheckBox.Size = new Size(96, 19);
            neutralCheckBox.TabIndex = 6;
            neutralCheckBox.Text = "Set to neutral";
            neutralCheckBox.UseVisualStyleBackColor = true;
            // 
            // validUntilLabel
            // 
            validUntilLabel.AutoSize = true;
            validUntilLabel.Location = new Point(447, 7);
            validUntilLabel.Name = "validUntilLabel";
            validUntilLabel.Size = new Size(59, 15);
            validUntilLabel.TabIndex = 3;
            validUntilLabel.Text = "Valid until";
            // 
            // validFromLabel
            // 
            validFromLabel.AutoSize = true;
            validFromLabel.Location = new Point(313, 7);
            validFromLabel.Name = "validFromLabel";
            validFromLabel.Size = new Size(61, 15);
            validFromLabel.TabIndex = 2;
            validFromLabel.Text = "Valid from";
            // 
            // historyTabPage
            // 
            historyTabPage.Location = new Point(4, 24);
            historyTabPage.Name = "historyTabPage";
            historyTabPage.Padding = new Padding(3);
            historyTabPage.Size = new Size(572, 209);
            historyTabPage.TabIndex = 1;
            historyTabPage.Text = "History";
            // 
            // usersLabel
            // 
            usersLabel.AutoSize = true;
            usersLabel.Location = new Point(5, 5);
            usersLabel.Name = "usersLabel";
            usersLabel.Size = new Size(35, 15);
            usersLabel.TabIndex = 6;
            usersLabel.Text = "Users";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(189, 9);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(61, 15);
            lastNameLabel.TabIndex = 7;
            lastNameLabel.Text = "Last name";
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new Point(506, 5);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(62, 15);
            firstNameLabel.TabIndex = 8;
            firstNameLabel.Text = "First name";
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Location = new Point(189, 64);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(86, 15);
            phoneNumberLabel.TabIndex = 9;
            phoneNumberLabel.Text = "Phone number";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(506, 64);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(41, 15);
            emailLabel.TabIndex = 10;
            emailLabel.Text = "E-mail";
            // 
            // userIdTextBox
            // 
            userIdTextBox.Location = new Point(189, 139);
            userIdTextBox.Name = "userIdTextBox";
            userIdTextBox.ReadOnly = true;
            userIdTextBox.Size = new Size(259, 23);
            userIdTextBox.TabIndex = 11;
            // 
            // registrationPlateTextBox
            // 
            registrationPlateTextBox.Location = new Point(506, 139);
            registrationPlateTextBox.Name = "registrationPlateTextBox";
            registrationPlateTextBox.Size = new Size(263, 23);
            registrationPlateTextBox.TabIndex = 4;
            // 
            // userIdLabel
            // 
            userIdLabel.AutoSize = true;
            userIdLabel.Location = new Point(189, 121);
            userIdLabel.Name = "userIdLabel";
            userIdLabel.Size = new Size(44, 15);
            userIdLabel.TabIndex = 13;
            userIdLabel.Text = "User ID";
            // 
            // registrationPlateLabel
            // 
            registrationPlateLabel.AutoSize = true;
            registrationPlateLabel.Location = new Point(506, 121);
            registrationPlateLabel.Name = "registrationPlateLabel";
            registrationPlateLabel.Size = new Size(99, 15);
            registrationPlateLabel.TabIndex = 14;
            registrationPlateLabel.Text = "Registration plate";
            // 
            // deleteUserButton
            // 
            deleteUserButton.Location = new Point(656, 412);
            deleteUserButton.Name = "deleteUserButton";
            deleteUserButton.Size = new Size(109, 23);
            deleteUserButton.TabIndex = 15;
            deleteUserButton.Text = "Delete user";
            deleteUserButton.UseVisualStyleBackColor = true;
            deleteUserButton.Click += deleteUserButton_Click;
            // 
            // newTicketButton
            // 
            newTicketButton.Location = new Point(193, 412);
            newTicketButton.Name = "newTicketButton";
            newTicketButton.Size = new Size(109, 23);
            newTicketButton.TabIndex = 16;
            newTicketButton.Text = "New ticket";
            newTicketButton.UseVisualStyleBackColor = true;
            newTicketButton.Click += newTicketButton_Click;
            // 
            // saveChangesButton
            // 
            saveChangesButton.Location = new Point(524, 412);
            saveChangesButton.Name = "saveChangesButton";
            saveChangesButton.Size = new Size(109, 23);
            saveChangesButton.TabIndex = 17;
            saveChangesButton.Text = "Save changes";
            saveChangesButton.UseVisualStyleBackColor = true;
            saveChangesButton.Click += saveChangesButton_Click;
            // 
            // newUserButton
            // 
            newUserButton.Location = new Point(5, 412);
            newUserButton.Name = "newUserButton";
            newUserButton.Size = new Size(165, 23);
            newUserButton.TabIndex = 18;
            newUserButton.Text = "New user";
            newUserButton.UseVisualStyleBackColor = true;
            newUserButton.Click += newUserButton_Click;
            // 
            // UsersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(newUserButton);
            Controls.Add(saveChangesButton);
            Controls.Add(newTicketButton);
            Controls.Add(deleteUserButton);
            Controls.Add(registrationPlateLabel);
            Controls.Add(userIdLabel);
            Controls.Add(registrationPlateTextBox);
            Controls.Add(userIdTextBox);
            Controls.Add(emailLabel);
            Controls.Add(phoneNumberLabel);
            Controls.Add(firstNameLabel);
            Controls.Add(lastNameLabel);
            Controls.Add(usersLabel);
            Controls.Add(ticketHistoryTabControl);
            Controls.Add(emailTextBox);
            Controls.Add(phoneNumberTextBox);
            Controls.Add(lastNameTextBox);
            Controls.Add(firstNameTextBox);
            Controls.Add(usersListBox);
            Name = "UsersForm";
            Text = "Users";
            TopMost = true;
            FormClosing += UsersForm_FormClosing;
            ticketHistoryTabControl.ResumeLayout(false);
            ticketTabPage.ResumeLayout(false);
            ticketTabPage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox usersListBox;
        private TextBox firstNameTextBox;
        private TextBox lastNameTextBox;
        private TextBox phoneNumberTextBox;
        private TextBox emailTextBox;
        private TabControl ticketHistoryTabControl;
        private TabPage ticketTabPage;
        private TabPage historyTabPage;
        private Label usersLabel;
        private Label lastNameLabel;
        private Label firstNameLabel;
        private Label phoneNumberLabel;
        private Label emailLabel;
        private TextBox userIdTextBox;
        private TextBox registrationPlateTextBox;
        private Label userIdLabel;
        private Label registrationPlateLabel;
        private Label validUntilLabel;
        private Label validFromLabel;
        private Button deleteUserButton;
        private Button newTicketButton;
        private ComboBox ticketTypeComboBox;
        private CheckBox deleteTicketCheckBox;
        private CheckBox blockCheckBox;
        private CheckBox neutralCheckBox;
        private Label ticketTypeLabel;
        private Button saveChangesButton;
        private TextBox ticketNumberTextBox;
        private Label ticketNumberLabel;
        private Button newUserButton;
        private MaskedTextBox validUntilTextBox;
        private MaskedTextBox validFromTextBox;
    }
}