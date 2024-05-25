using GarageControlCenterBackend.Models;

namespace GarageControlCenterUI.Controls
{
    // A custom button control to display the total occupancy status of the garage
    public partial class TotalButton : Button
    {
        private Garage Garage { get; set; }
        private List<Label> labels;

        public TotalButton(Garage garage)
        {
            Garage = garage;
            CreateLabels();
            InitializeButton();
        }

        // Initialize the button layout
        private void InitializeButton()
        {
            BackColor = Color.White;
            Size = new Size(200, 180);
            Margin = new Padding(20, 3, 3, 3);

            // Create a Panel to contain the button elements
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
                ColumnCount = 2,
                RowCount = 6,
                ColumnStyles =
                {
                    new ColumnStyle(SizeType.Percent, 35),
                    new ColumnStyle(SizeType.Percent, 65)
                }
            };

            // Create a PictureBox to display the garage icon
            PictureBox pictureBox = new PictureBox
            {
                Margin = new Padding(0, 10, 0, 0),
                Anchor = AnchorStyles.None,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Resources.GarageIcon
            };

            // Add button elements to the TableLayoutPanel
            tableLayoutPanel.Controls.Add(pictureBox, 0, 0);
            tableLayoutPanel.Controls.Add(labels[0], 0, 1);
            tableLayoutPanel.Controls.Add(labels[1], 0, 2);
            tableLayoutPanel.Controls.Add(labels[2], 1, 3);
            tableLayoutPanel.Controls.Add(labels[3], 0, 3);
            tableLayoutPanel.Controls.Add(labels[4], 1, 4);
            tableLayoutPanel.Controls.Add(labels[5], 0, 4);

            tableLayoutPanel.SetColumnSpan(tableLayoutPanel.GetControlFromPosition(0, 1), 2);
            tableLayoutPanel.SetColumnSpan(tableLayoutPanel.GetControlFromPosition(0, 0), 2);

            // Add the TableLayoutPanel to the Panel, and the Panel to the TotalButton
            panel.Controls.Add(tableLayoutPanel);
            Controls.Add(panel);
        }

        // Create a label with specified properties
        private Label CreateLabel(string text, FontStyle style, AnchorStyles anchor, int fontSize)
        {
            var label = new Label
            {
                Anchor = anchor,
                Text = text,
                AutoSize = true,
                Font = new Font("Arial", fontSize, style)
            };
            return label;
        }

        // Create an indicator label with specified color
        private Label CreateIndicator(Color color)
        {
            var label = new Label
            {
                Anchor = AnchorStyles.Right,
                Text = "●",
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = color
            };
            return label;
        }

        private void CreateLabels()
        {
            labels = new List<Label>();

            // Determine the colors for the indicators based on the level's status
            Color usedIndicatorColor = Garage.TotalOccupiedSpots() != Garage.TotalCapacity ? Color.LightGray : Color.Red;
            Color freeIndicatorColor = Garage.TotalFreeSpots() > 0 ? Color.Green : Color.LightGray;

            Label garageLabel = CreateLabel($"Garage", FontStyle.Bold, AnchorStyles.None, 16);
            Label spacer = CreateLabel($"", FontStyle.Bold, AnchorStyles.None, 12);
            Label usedSpotsLabel = CreateLabel($"Used: {Garage.TotalOccupiedSpots()}", FontStyle.Regular, AnchorStyles.Left, 12);
            Label usedSpotsIndicator = CreateIndicator(usedIndicatorColor);
            Label freeSpotsLabel = CreateLabel($"Free: {Garage.TotalFreeSpots()}", FontStyle.Regular, AnchorStyles.Left, 12);
            Label freeSpotsIndicator = CreateIndicator(freeIndicatorColor);

            labels.Add(garageLabel);
            labels.Add(spacer);
            labels.Add(usedSpotsLabel);
            labels.Add(usedSpotsIndicator);
            labels.Add(freeSpotsLabel);
            labels.Add(freeSpotsIndicator);
        }

        public void RefreshLabels()
        {
            Color usedIndicatorColor = Garage.TotalOccupiedSpots() != Garage.TotalCapacity ? Color.LightGray : Color.Red;
            Color freeIndicatorColor = Garage.TotalFreeSpots() > 0 ? Color.Green : Color.LightGray;

            labels[2].Text = $"Used: {Garage.TotalOccupiedSpots()}";
            labels[3].ForeColor = usedIndicatorColor;
            labels[4].Text = $"Free: {Garage.TotalFreeSpots()}";
            labels[5].ForeColor = freeIndicatorColor;
        }
    }
}
