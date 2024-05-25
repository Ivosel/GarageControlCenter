using GarageControlCenterBackend.Services;
using GarageControlCenterBackend.Models;

namespace GarageControlCenterUI
{
    public partial class GarageListDialog : Form
    {
        private List<Garage> Garages;
        GarageService garageService;
        public Garage SelectedGarage { get; private set; }
        public GarageListDialog(GarageService service)
        {
            garageService = service;
            InitializeComponent();
            SelectGarageButton.Enabled = false;
            PopulateGarageList();
        }

        private async Task PopulateGarageList()
        {
            Garages = await garageService.GetAllGaragesAsync();
            foreach (var garage in Garages)
            {
                GaragesListBox.Items.Add(garage);
            }
            SelectGarageButton.Enabled = true;
            Refresh();
        }

        private void SelectGarageButton_Click(object sender, EventArgs e)
        {
            if (GaragesListBox.SelectedItem != null)
            {
                SelectedGarage = (Garage)GaragesListBox.SelectedItem;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please select a garage.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
