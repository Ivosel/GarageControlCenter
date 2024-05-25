using GarageControlCenterBackend.Models;

namespace GarageControlCenterUI.Controls
{
    // A custom button control to display the status of specific levels
    public partial class LevelButton : Button
    {
        // Property to store the associated level
        public Level Level { get; set; }
        private List<Label> labels;
        public LevelButton(Level level)
        {
            Level = level;
            CreateLabels();
            InitializeButton();
        }

        // Initialize the button layout
        private void InitializeButton()
        {
            Tag = Level;
            Margin = new Padding(10, 10, 10, 10);
            BackColor = Color.White;

            // Create a TableLayoutPanel to organize button elements
            var tableLayoutPanel = CreateTableLayoutPanel();

            // Add labels and indicators to the TableLayoutPanel
            tableLayoutPanel.Controls.Add(labels[0], 0, 0);
            tableLayoutPanel.Controls.Add(labels[1], 0, 1);
            tableLayoutPanel.Controls.Add(labels[2], 1, 2);
            tableLayoutPanel.Controls.Add(labels[3], 0, 2);
            tableLayoutPanel.Controls.Add(labels[4], 1, 3);
            tableLayoutPanel.Controls.Add(labels[5], 0, 3);

            tableLayoutPanel.SetColumnSpan(tableLayoutPanel.GetControlFromPosition(0, 0), 2);

            // Add the TableLayoutPanel to the LevelButton
            Controls.Add(tableLayoutPanel);

            // Attach event handlers for mouse clicks and mouse enter/leave events
            tableLayoutPanel.MouseClick += ClickAnywhere;
            tableLayoutPanel.MouseEnter += TableLayoutPanel_MouseEnter;
            tableLayoutPanel.MouseLeave += TableLayoutPanel_MouseLeave;
        }

        private void TableLayoutPanel_MouseLeave(object? sender, EventArgs e)
        {
            BackColor = Color.White;
        }

        private void TableLayoutPanel_MouseEnter(object? sender, EventArgs e)
        {
            BackColor = Color.LightGray;
        }

        // Create a TableLayoutPanel with specified properties
        private TableLayoutPanel CreateTableLayoutPanel()
        {
            return new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                ColumnCount = 2,
                RowCount = 5,
                ColumnStyles =
                {
                    new ColumnStyle(SizeType.Percent, 20),
                    new ColumnStyle(SizeType.Percent, 80)
                }
            };
        }

        // Create a label with specified properties
        private Label CreateLabel(string text, FontStyle style, AnchorStyles anchor, int fontSize, Padding margin)
        {
            var label = new Label
            {
                Text = text,
                AutoSize = true,
                Anchor = anchor,
                Font = new Font("Arial", fontSize, style),
                Margin = margin,
            };

            // Attach event handlers for mouse clicks and mouse enter/leave events
            label.MouseClick += ClickAnywhere;
            label.MouseEnter += TableLayoutPanel_MouseEnter;
            label.MouseLeave += TableLayoutPanel_MouseLeave;

            return label;
        }

        // Create an indicator label with specified color
        private Label CreateIndicator(Color color)
        {
            var label = new Label
            {
                Text = "●",
                AutoSize = true,
                Anchor = AnchorStyles.Right,
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = color
            };

            // Attach event handlers for mouse clicks and mouse enter/leave events
            label.MouseClick += ClickAnywhere;
            label.MouseEnter += TableLayoutPanel_MouseEnter;
            label.MouseLeave += TableLayoutPanel_MouseLeave;

            return label;
        }

        // Function to enable the class to recieve clicks on all of its elements (acting as a button)
        private void ClickAnywhere(object sender, MouseEventArgs e)
        {
            PerformClick();
        }

        private void CreateLabels()
        {
            labels = new List<Label>();

            // Determine the colors for the indicators based on the level's status
            Color usedIndicatorColor = Level.OccupiedSpots() != Level.Capacity ? Color.LightGray : Color.Red;
            Color freeIndicatorColor = Level.FreeSpots() > 0 ? Color.Green : Color.LightGray;

            Label levelLabel = CreateLabel($"Level {Level.LevelNumber}", FontStyle.Bold, AnchorStyles.None, 12, new Padding(0, 20, 0, 0));
            Label spacer = CreateLabel($"", FontStyle.Bold, AnchorStyles.None, 10, new Padding(0));
            Label usedSpotsLabel = CreateLabel($"Used: {Level.OccupiedSpots()}", FontStyle.Regular, AnchorStyles.Left, 10, new Padding(0));
            Label usedSpotsIndicator = CreateIndicator(usedIndicatorColor);
            Label freeSpotsLabel = CreateLabel($"Free: {Level.FreeSpots()}", FontStyle.Regular, AnchorStyles.Left, 10, new Padding(0));
            Label freeSpotsIndicator = CreateIndicator(freeIndicatorColor);

            labels.Add(levelLabel);
            labels.Add(spacer);
            labels.Add(usedSpotsLabel);
            labels.Add(usedSpotsIndicator);
            labels.Add(freeSpotsLabel);
            labels.Add(freeSpotsIndicator);
        }

        public void RefreshLabels()
        {
            Color usedIndicatorColor = Level.OccupiedSpots() != Level.Capacity ? Color.LightGray : Color.Red;
            Color freeIndicatorColor = Level.FreeSpots() > 0 ? Color.Green : Color.LightGray;


            labels[2].Text = $"Used: {Level.OccupiedSpots()}";
            labels[3].ForeColor = usedIndicatorColor;
            labels[4].Text = $"Free: {Level.FreeSpots()}";
            labels[5].ForeColor = freeIndicatorColor;
        }
    }
}
