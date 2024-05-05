
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
            SuspendLayout();
            // 
            // TakeTicketButton
            // 
            TakeTicketButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            TakeTicketButton.Location = new Point(128, 36);
            TakeTicketButton.Name = "TakeTicketButton";
            TakeTicketButton.Size = new Size(203, 56);
            TakeTicketButton.TabIndex = 0;
            TakeTicketButton.Text = "Take Ticket";
            TakeTicketButton.UseVisualStyleBackColor = true;
            TakeTicketButton.Click += TakeTicketButton_Click;
            // 
            // InsertTicketButton
            // 
            InsertTicketButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            InsertTicketButton.Location = new Point(128, 150);
            InsertTicketButton.Name = "InsertTicketButton";
            InsertTicketButton.Size = new Size(203, 56);
            InsertTicketButton.TabIndex = 1;
            InsertTicketButton.Text = "Insert Ticket";
            InsertTicketButton.UseVisualStyleBackColor = true;
            InsertTicketButton.Click += this.InsertTicketButton_Click;
            // 
            // EntryDemonstration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(472, 254);
            Controls.Add(InsertTicketButton);
            Controls.Add(TakeTicketButton);
            Name = "EntryDemonstration";
            Text = "Demonstration";
            ResumeLayout(false);
        }

        #endregion

        private Button TakeTicketButton;
        private Button InsertTicketButton;
    }
}