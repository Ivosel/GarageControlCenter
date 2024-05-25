namespace GarageControlCenterUI
{
    // A form to allow the user to choose the number of levels for the garage
    public partial class ChooseNumberOfLevelsForm : Form
    {

        public GarageInfo info;
        public ChooseNumberOfLevelsForm()
        {
            info = new GarageInfo();
            InitializeComponent();
        }

        private void NumberOfLevelsOK_Click(object sender, EventArgs e)
        {
            // Check if the input is a valid integer between 1 and 5
            if (int.TryParse(NumberOfLevelsSelect.Text, out int selectedNumber) && selectedNumber >= 1 && selectedNumber <= 5)
            {
                info.SelectedNumberOfLevels = selectedNumber;
                info.Name = GarageNameTextBox.Text;
                DialogResult = DialogResult.OK;
            }

            else
            {
                // Display a warning message if the input is invalid
                MessageBox.Show("Please enter a number between 1 and 5.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    public class GarageInfo
    {
        public int SelectedNumberOfLevels;
        public string Name;
    }
}
