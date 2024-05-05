using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarageControlCenterUI.Controls
{
    public partial class BarrierButton : Button
    {
        // A custom button control for operating the garage's barriers
        private readonly string BarrierType;

        public BarrierButton(string barrierType)
        {
            BarrierType = barrierType;
            InitializeButton();
        }

        // Initialize the button layout
        private void InitializeButton()
        {
            BackColor = Color.White;
            Size = new Size(200, 180);
            Margin = new Padding(20, 3, 3, 3);

            // Create a panel to contain the button elements
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(3)
            };

            // Create a TableLayoutPanel to organize button elements
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                RowCount = 6,
                ColumnCount = 1,
                AutoSize = true
            };

            // Create a PictureBox to display an icon
            PictureBox pictureBox = new PictureBox
            {
                Margin = new Padding(0, 10, 0, 0),
                Anchor = AnchorStyles.None,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Image.FromFile(@"Images\BarrierIcon.png")
            };

            // Create a label for the barrier type
            Label nameLabel = CreateLabel($"{BarrierType.ToUpper()}", FontStyle.Bold, ContentAlignment.MiddleCenter, 16);
            nameLabel.Dock = DockStyle.Top;

            // Create a button to open the barrier
            Button openButton = CreateButton("Open");
            openButton.Anchor = AnchorStyles.Top;
            openButton.Width = (int)(tableLayoutPanel.Width * 0.5);
            openButton.Click += OpenButton_Click;

            // Create a button to close the barrier
            Button closeButton = CreateButton("Close");
            closeButton.Anchor = AnchorStyles.Top;
            closeButton.Width = (int)(tableLayoutPanel.Width * 0.5);
            closeButton.Click += CloseButton_Click;

            // Add controls to the TableLayoutPanel
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel.Controls.Add(pictureBox, 0, 0);
            tableLayoutPanel.Controls.Add(nameLabel, 0, 1);
            tableLayoutPanel.Controls.Add(new Label(), 0, 2);
            tableLayoutPanel.Controls.Add(openButton, 0, 3);
            tableLayoutPanel.Controls.Add(closeButton, 0, 4);

            // Add TableLayoutPanel to the panel
            panel.Controls.Add(tableLayoutPanel);
            Controls.Add(panel);
        }

        // Create a label with specified properties
        private Label CreateLabel(string text, FontStyle style, ContentAlignment alignment, int fontSize)
        {
            var label = new Label
            {
                Text = text,
                AutoSize = true,
                TextAlign = alignment,
                Font = new Font("Arial", fontSize, style)
            };
            return label;
        }

        // Create a button with specified text
        private Button CreateButton(string text)
        {
            var button = new Button
            {
                Text = text,
            };
            return button;
        }

        // Event handler for the Open button click event
        private void OpenButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Opening {BarrierType} barrier.");
        }

        // Event handler for the Close button click event
        private void CloseButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Closing {BarrierType} barrier.");
        }
    }
}
