using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GarageControlCenter.Models;

namespace GarageControlCenterUI.Controls
{
    public partial class LevelGrid : UserControl
    {
        public Level selectedLevel;
        public List<SpotButton> spotButtons;

        public LevelGrid(Level level)
        {
            selectedLevel = level;
            spotButtons = new List<SpotButton>();
            CreateSpotButtons();
            CreateGrid(selectedLevel.Capacity);
            InitializeComponent();
        }

        private void CreateSpotButtons()
        {
            foreach (ParkingSpot spot in selectedLevel.Spots) { spotButtons.Add(new SpotButton(spot.Placement)); }
        }

        private void CreateGrid(int numberOfButtons)
        {
            SuspendLayout();
            Controls.Clear();

            int rows, columns;
            switch (numberOfButtons)
            {
                case int n when (n <= 50):
                    rows = 5;
                    columns = 10;
                    break;
                case int n when (n <= 100):
                    rows = 8;
                    columns = 15;
                    break;
                case int n when (n <= 150):
                    rows = 8;
                    columns = 20;
                    break;
                case int n when (n <= 200):
                    rows = 8;
                    columns = 25;
                    break;
                default:
                    throw new ArgumentException("Number of buttons exceeds maximum limit.");
            }

            // Create grid of SpotButtons
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int index = i * columns + j;

                    // Check if the index is within the range of buttons
                    if (index < spotButtons.Count)
                    {
                        var button = spotButtons[index];

                        int yCoordinate = i * (button.Height + 30);

                        if (((i+1)% 2 == 0) && i != 0)
                        {
                            yCoordinate += 30;
                        }

                        button.Location = new Point(j * button.Width, yCoordinate);

                        Controls.Add(button);
                    }
                }
            }

            ResumeLayout();
        }

        public void RefreshGrid(ParkingSpot spot)
        {
            foreach (SpotButton button in spotButtons.Where(button => button.Text == spot.Placement))
            {
                button.BackColor = spot.IsOccupied ? Color.Red : Color.LightGreen;
            }
        }
    }
}