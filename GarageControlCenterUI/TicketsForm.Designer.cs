namespace GarageControlCenterUI
{
    partial class TicketsForm
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
            ticketGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)ticketGrid).BeginInit();
            SuspendLayout();
            // 
            // ticketGrid
            // 
            ticketGrid.AllowUserToAddRows = false;
            ticketGrid.AllowUserToDeleteRows = false;
            ticketGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ticketGrid.Dock = DockStyle.Fill;
            ticketGrid.Location = new Point(0, 0);
            ticketGrid.Name = "ticketGrid";
            ticketGrid.RowTemplate.Height = 25;
            ticketGrid.Size = new Size(444, 438);
            ticketGrid.TabIndex = 0;
            // 
            // TicketsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 438);
            Controls.Add(ticketGrid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TicketsForm";
            Text = "Tickets";
            TopMost = true;
            FormClosing += TicketsForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)ticketGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView ticketGrid;
    }
}