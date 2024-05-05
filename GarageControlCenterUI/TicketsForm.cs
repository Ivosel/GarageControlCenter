using GarageControlCenter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarageControlCenterUI
{
    // A form to display a list view of current present tickets and their parameters
    public partial class TicketsForm : Form
    {
        List<Ticket> TicketList;
        public TicketsForm(List<Ticket> tickets)
        {
            TicketList = tickets;
            InitializeComponent();
        }

        // Refresh the list with new values
        public void RefreshTickets()
        {
            var bindingList = new BindingList<Ticket>(TicketList);
            ticketGrid.DataSource = new BindingSource(bindingList, null);
        }

        private void TicketsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
