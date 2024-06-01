
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
            SuspendLayout();
            // 
            // InsertTicketButton
            // 
            InsertTicketButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            InsertTicketButton.Location = new Point(136, 155);
            InsertTicketButton.Name = "InsertTicketButton";
            InsertTicketButton.Size = new Size(195, 56);
            InsertTicketButton.TabIndex = 1;
            InsertTicketButton.Text = "Insert Ticket";
            InsertTicketButton.UseVisualStyleBackColor = true;
            InsertTicketButton.Click += InsertTicketButton_Click;
            // 
            // ticketNumberTextBox
            // 
            ticketNumberTextBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            ticketNumberTextBox.Location = new Point(136, 73);
            ticketNumberTextBox.Name = "ticketNumberTextBox";
            ticketNumberTextBox.Size = new Size(195, 33);
            ticketNumberTextBox.TabIndex = 2;
            ticketNumberTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(136, 36);
            label1.Name = "label1";
            label1.Size = new Size(195, 25);
            label1.TabIndex = 3;
            label1.Text = "Enter ticket number:";
            // 
            // ExitDemonstration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(472, 254);
            Controls.Add(label1);
            Controls.Add(ticketNumberTextBox);
            Controls.Add(InsertTicketButton);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExitDemonstration";
            Text = "Demonstration";
            TopMost = true;
            FormClosing += ExitDemonstration_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button InsertTicketButton;
        private TextBox ticketNumberTextBox;
        private Label label1;
    }
}