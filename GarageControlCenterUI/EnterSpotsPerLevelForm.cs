namespace GarageControlCenterUI
{
    // A form to allow the user to enter the number of spots per level for the garage
    public partial class EnterSpotsPerLevelForm : Form
    {
        private int numberOfLevels;
        private List<TextBox> spotsTextBoxes;

        // Event raised when the user requests to create a garage with the entered spots per level
        public event EventHandler<List<int>> CreateGarageRequested;

        public EnterSpotsPerLevelForm(int numberOfLevels)
        {
            InitializeComponent();
            this.numberOfLevels = numberOfLevels;
            spotsTextBoxes = new List<TextBox>();
            Load += EnterSpotsPerLevelForm_Load; // Subscribe to the form load event
        }

        // Event handler for the form load event
        private void EnterSpotsPerLevelForm_Load(object sender, EventArgs e)
        {
            // Generate labels and textboxes for each level
            for (int i = 1; i <= numberOfLevels; i++)
            {
                var label = new Label
                {
                    Text = $"Level {i}:",
                    Size = new Size(50, 20)
                };
                var textBox = new TextBox();

                label.Anchor = AnchorStyles.None;
                textBox.Anchor = AnchorStyles.None;

                // Add label and textbox to the form
                tableLayoutPanel.Controls.Add(label);
                tableLayoutPanel.Controls.Add(textBox);
                spotsTextBoxes.Add(textBox);
            }

            // Set properties for the CreateGarageButton
            CreateGarageButton.Anchor = AnchorStyles.None;
            CreateGarageButton.TabIndex = 100;
            CreateGarageButton.Margin = new Padding(0, 30, 0, 10);
            tableLayoutPanel.SetColumnSpan(CreateGarageButton, 2);
            tableLayoutPanel.Controls.Add(CreateGarageButton);
            tableLayoutPanel.Padding = new Padding(20);

        }

        // Event handler for the CreateGarageButton click event
        private void CreateGarageButton_Click(object sender, EventArgs e)
        {
            // Get the list of spots per level entered by the user
            if (GetSpotsPerLevelList().Count == numberOfLevels)
            {
                List<int> spotsPerLevelList = GetSpotsPerLevelList();

                // Raise the CreateGarageRequested event with the list of spots per level
                CreateGarageRequested?.Invoke(this, spotsPerLevelList);

                Close();
            }
        }

        // Retrieve the list of spots per level entered by the user
        private List<int> GetSpotsPerLevelList()
        {
            var result = new List<int>();

            foreach (var textBox in spotsTextBoxes)
            {
                if (int.TryParse(textBox.Text, out int spots))
                {
                    // Check if the value is within the range of 1 to 200
                    if (spots >= 1 && spots <= 200)
                    {
                        result.Add(spots);
                    }
                    else
                    {
                        // Handle out of range input
                        MessageBox.Show($"Maximum capacity per level is 200 parking spots!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox.Clear();
                        break;
                    }
                }
                else
                {
                    // Handle non-integer input
                    MessageBox.Show($"Please enter only numbers.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox.Clear();
                    break;
                }
            }
            return result;
        }
    }
}
