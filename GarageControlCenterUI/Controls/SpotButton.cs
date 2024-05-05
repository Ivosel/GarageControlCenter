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
    public partial class SpotButton : Button
    {
        string Location;
        public SpotButton(string location)
        {
            Location = location;
            InitializeButton();
        }

        private void InitializeButton()
        {
            Text = $"{Location}";
            Size = new Size(60, 80);
            Enabled = false;
            Margin = new Padding(0);
            BackColor = Color.LightGreen;
        }
    }
}
