
namespace GarageControlCenterUI
{
    partial class ExitDemonstration
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
            InsertTicketButton = new Button();
            ticketNumberTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            userIdTextBox = new TextBox();
            SuspendLayout();
            // 
            // InsertTicketButton
            // 
            InsertTicketButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            InsertTicketButton.Location = new Point(136, 186);
            InsertTicketButton.Name = "InsertTicketButton";
            InsertTicketButton.Size = new Size(195, 56);
            InsertTicketButton.TabIndex = 1;
            InsertTicketButton.Text = "Insert Ticket";
            InsertTicketButton.UseVisualStyleBackColor = true;
            // 
            // ticketNumberTextBox
            // 
            ticketNumberTextBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            ticketNumberTextBox.ForeColor = Color.LightGray;
            ticketNumberTextBox.Location = new Point(136, 37);
            ticketNumberTextBox.Name = "ticketNumberTextBox";
            ticketNumberTextBox.Size = new Size(195, 35);
            ticketNumberTextBox.TabIndex = 2;
            ticketNumberTextBox.Text = "Ticket number";
            ticketNumberTextBox.TextAlign = HorizontalAlignment.Center;
            ticketNumberTextBox.Enter += ticketNumberTextBox_Enter;
            ticketNumberTextBox.Leave += ticketNumberTextBox_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(136, 9);
            label1.Name = "label1";
            label1.Size = new Size(195, 25);
            label1.TabIndex = 3;
            label1.Text = "Enter ticket number:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(180, 75);
            label2.Name = "label2";
            label2.Size = new Size(105, 25);
            label2.TabIndex = 4;
            label2.Text = "or user ID:";
            // 
            // userIdTextBox
            // 
            userIdTextBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            userIdTextBox.ForeColor = Color.LightGray;
            userIdTextBox.Location = new Point(136, 103);
            userIdTextBox.Name = "userIdTextBox";
            userIdTextBox.Size = new Size(195, 35);
            userIdTextBox.TabIndex = 3;
            userIdTextBox.Text = "User ID";
            userIdTextBox.TextAlign = HorizontalAlignment.Center;
            userIdTextBox.Enter += userIdTextBox_Enter;
            userIdTextBox.Leave += userIdTextBox_Leave;
            // 
            // ExitDemonstration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(472, 254);
            Controls.Add(userIdTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ticketNumberTextBox);
            Controls.Add(InsertTicketButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExitDemonstration";
            Text = "Exit Demonstration";
            TopMost = true;
            FormClosing += ExitDemonstration_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button InsertTicketButton;
        private TextBox ticketNumberTextBox;
        private Label label1;
        private Label label2;
        private TextBox userIdTextBox;
    }
}