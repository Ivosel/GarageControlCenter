using GarageControlCenterBackend.Models;

namespace GarageControlCenterUI.Controls
{
    public partial class SpotButton : Button
    {
        private ParkingSpot parkingSpot;
        public SpotButton(ParkingSpot spot)
        {
            parkingSpot = spot;
            InitializeButton();
        }

        private void InitializeButton()
        {
            Text = parkingSpot.Placement;
            Size = new Size(60, 80);
            Enabled = false;
            Margin = new Padding(0);
            BackColor = parkingSpot.IsOccupied ? Color.Red : Color.LightGreen;
        }
    }
}
