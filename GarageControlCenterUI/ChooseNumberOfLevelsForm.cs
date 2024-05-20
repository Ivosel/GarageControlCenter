namespace GarageControlCenterUI
{
    // A form to allow the user to choose the number of levels for the garage
    public partial class ChooseNumberOfLevelsForm : Form
    {

        public int SelectedNumberOfLevels { get; internal set; }
        public ChooseNumberOfLevelsForm()
        {
            InitializeComponent();
        }

        private void NumberOfLevelsOK_Click(object sender, EventArgs e)
        {
            // Check if the input is a valid integer between 1 and 5
            if (int.TryParse(NumberOfLevelsSelect.Text, out int selectedLevel) && selectedLevel >= 1 && selectedLevel <= 5)
            {
                SelectedNumberOfLevels = selectedLevel;
                DialogResult = DialogResult.OK;
            }

            else
            {
                // Display a warning message if the input is invalid
                MessageBox.Show("Please enter a number between 1 and 5.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
