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
            if (int.TryParse(NumberOfLevelsSelect.Text, out int selectedNumber) && selectedNumber >= 1 && selectedNumber <= 5)
            {
                info.SelectedNumberOfLevels = selectedNumber;
                info.Name = GarageNameTextBox.Text;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please enter a number between 1 and 5.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    public class GarageInfo
    {
        public int SelectedNumberOfLevels { get; set; }
        public string Name { get; set; }
    }
}
