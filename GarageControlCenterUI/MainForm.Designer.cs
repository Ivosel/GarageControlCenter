namespace GarageControlCenterUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            demonstrationToolStripMenuItem = new ToolStripMenuItem();
            entranceDemoToolStripMenuItem = new ToolStripMenuItem();
            exitDemoToolStripMenuItem = new ToolStripMenuItem();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            mainFormLayout = new TableLayoutPanel();
            parkingSpotGrid = new TableLayoutPanel();
            levelListLayout = new TableLayoutPanel();
            menuStrip1.SuspendLayout();
            mainFormLayout.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, demonstrationToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 29);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(61, 25);
            fileToolStripMenuItem.Text = "&Users";
            fileToolStripMenuItem.Click += fileToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(69, 25);
            editToolStripMenuItem.Text = "&Tickets";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // demonstrationToolStripMenuItem
            // 
            demonstrationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { entranceDemoToolStripMenuItem, exitDemoToolStripMenuItem });
            demonstrationToolStripMenuItem.Name = "demonstrationToolStripMenuItem";
            demonstrationToolStripMenuItem.Size = new Size(126, 25);
            demonstrationToolStripMenuItem.Text = "&Demonstration";
            // 
            // entranceDemoToolStripMenuItem
            // 
            entranceDemoToolStripMenuItem.Name = "entranceDemoToolStripMenuItem";
            entranceDemoToolStripMenuItem.Size = new Size(186, 26);
            entranceDemoToolStripMenuItem.Text = "Entrance Demo";
            entranceDemoToolStripMenuItem.Click += entranceDemoToolStripMenuItem_Click;
            // 
            // exitDemoToolStripMenuItem
            // 
            exitDemoToolStripMenuItem.Name = "exitDemoToolStripMenuItem";
            exitDemoToolStripMenuItem.Size = new Size(186, 26);
            exitDemoToolStripMenuItem.Text = "Exit Demo";
            exitDemoToolStripMenuItem.Click += exitDemoToolStripMenuItem_Click;
            // 
            // mainFormLayout
            // 
            mainFormLayout.ColumnCount = 2;
            mainFormLayout.Controls.Add(parkingSpotGrid, 1, 0);
            mainFormLayout.Controls.Add(levelListLayout, 0, 0);
            mainFormLayout.Dock = DockStyle.Fill;
            mainFormLayout.Location = new Point(0, 29);
            mainFormLayout.Name = "mainFormLayout";
            mainFormLayout.RowCount = 1;
            mainFormLayout.Size = new Size(800, 421);
            mainFormLayout.TabIndex = 1;
            // 
            // parkingSpotGrid
            // 
            parkingSpotGrid.ColumnCount = 1;
            parkingSpotGrid.Dock = DockStyle.Fill;
            parkingSpotGrid.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            parkingSpotGrid.Location = new Point(129, 3);
            parkingSpotGrid.Name = "parkingSpotGrid";
            parkingSpotGrid.RowCount = 1;
            parkingSpotGrid.Size = new Size(668, 415);
            parkingSpotGrid.TabIndex = 1;
            // 
            // levelListLayout
            // 
            levelListLayout.ColumnCount = 1;
            levelListLayout.Dock = DockStyle.Fill;
            levelListLayout.Location = new Point(3, 3);
            levelListLayout.Name = "levelListLayout";
            levelListLayout.RowCount = 1;
            levelListLayout.Size = new Size(120, 415);
            levelListLayout.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.Disable;
            ClientSize = new Size(800, 450);
            Controls.Add(mainFormLayout);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Garage Control Center";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            mainFormLayout.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem;
        private TableLayoutPanel mainFormLayout;
        private ToolStripMenuItem demonstrationToolStripMenuItem;
        private ToolStripMenuItem entranceDemoToolStripMenuItem;
        private ToolStripMenuItem exitDemoToolStripMenuItem;
        private TableLayoutPanel parkingSpotGrid;
        private TableLayoutPanel levelListLayout;
    }
}
