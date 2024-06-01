
namespace GarageControlCenterUI
{
    partial class EntryDemonstration
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
            TakeTicketButton = new Button();
            InsertTicketButton = new Button();
            RegistrationTextBox = new TextBox();
            TicketIdTextBox = new TextBox();
            SuspendLayout();
            // 
            // TakeTicketButton
            // 
            TakeTicketButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            TakeTicketButton.Location = new Point(128, 61);
            TakeTicketButton.Name = "TakeTicketButton";
            TakeTicketButton.Size = new Size(203, 56);
            TakeTicketButton.TabIndex = 1;
            TakeTicketButton.Text = "Take Ticket";
            TakeTicketButton.UseVisualStyleBackColor = true;
            TakeTicketButton.Click += TakeTicketButton_Click;
            // 
            // InsertTicketButton
            // 
            InsertTicketButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            InsertTicketButton.Location = new Point(128, 186);
            InsertTicketButton.Name = "InsertTicketButton";
            InsertTicketButton.Size = new Size(203, 56);
            InsertTicketButton.TabIndex = 3;
            InsertTicketButton.Text = "Insert Ticket";
            InsertTicketButton.UseVisualStyleBackColor = true;
            InsertTicketButton.Click += InsertTicketButton_Click;
            // 
            // RegistrationTextBox
            // 
            RegistrationTextBox.CharacterCasing = CharacterCasing.Upper;
            RegistrationTextBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            RegistrationTextBox.ForeColor = Color.LightGray;
            RegistrationTextBox.Location = new Point(128, 20);
            RegistrationTextBox.Name = "RegistrationTextBox";
            RegistrationTextBox.Size = new Size(203, 35);
            RegistrationTextBox.TabIndex = 0;
            RegistrationTextBox.Text = "REGISTRATION";
            RegistrationTextBox.TextAlign = HorizontalAlignment.Center;
            RegistrationTextBox.Enter += RegistrationTextBox_Enter;
            RegistrationTextBox.Leave += RegistrationTextBox_Leave;
            // 
            // TicketIdTextBox
            // 
            TicketIdTextBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            TicketIdTextBox.ForeColor = Color.LightGray;
            TicketIdTextBox.Location = new Point(128, 145);
            TicketIdTextBox.Name = "TicketIdTextBox";
            TicketIdTextBox.Size = new Size(203, 35);
            TicketIdTextBox.TabIndex = 2;
            TicketIdTextBox.Text = "Enter user ID";
            TicketIdTextBox.TextAlign = HorizontalAlignment.Center;
            TicketIdTextBox.Enter += TicketIdTextBox_Enter;
            TicketIdTextBox.Leave += TicketIdTextBox_Leave;
            // 
            // EntryDemonstration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(472, 254);
            Controls.Add(TicketIdTextBox);
            Controls.Add(RegistrationTextBox);
            Controls.Add(InsertTicketButton);
            Controls.Add(TakeTicketButton);
            Name = "EntryDemonstration";
            Text = "Demonstration";
            TopMost = true;
            FormClosing += EntryDemonstration_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button TakeTicketButton;
        private Button InsertTicketButton;
        private TextBox RegistrationTextBox;
        private TextBox TicketIdTextBox;
    }
}