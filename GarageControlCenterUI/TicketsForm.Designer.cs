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
            components = new System.ComponentModel.Container();
            garageBindingSource = new BindingSource(components);
            ticketGrid = new DataGridView();
            ticketsBindingSource = new BindingSource(components);
            garageBindingSource1 = new BindingSource(components);
            ticketsBindingSource1 = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)garageBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ticketGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ticketsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)garageBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ticketsBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // garageBindingSource
            // 
            garageBindingSource.DataSource = typeof(GarageControlCenter.Models.Garage);
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
            // ticketsBindingSource
            // 
            ticketsBindingSource.DataMember = "Tickets";
            ticketsBindingSource.DataSource = garageBindingSource;
            // 
            // garageBindingSource1
            // 
            garageBindingSource1.DataSource = typeof(GarageControlCenter.Models.Garage);
            // 
            // ticketsBindingSource1
            // 
            ticketsBindingSource1.DataMember = "Tickets";
            ticketsBindingSource1.DataSource = garageBindingSource;
            // 
            // TicketsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 438);
            Controls.Add(ticketGrid);
            Name = "TicketsForm";
            Text = "Tickets";
            FormClosing += TicketsForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)garageBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)ticketGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)ticketsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)garageBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ticketsBindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private BindingSource garageBindingSource;
        private DataGridView ticketGrid;
        private BindingSource garageBindingSource1;
        private BindingSource ticketsBindingSource;
        private BindingSource ticketsBindingSource1;
    }
}