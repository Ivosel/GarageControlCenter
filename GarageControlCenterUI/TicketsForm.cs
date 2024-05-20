using GarageControlCenterModels.Models;
using System.ComponentModel;

namespace GarageControlCenterUI
{
    // A form to display a list view of current present tickets and their parameters
    public partial class TicketsForm : Form
    {
        List<Ticket> TicketList;
        private BindingList<Ticket> bindingTicketList;
        private BindingSource ticketBindingSource;
        public TicketsForm(List<Ticket> tickets)
        {
            TicketList = tickets;
            InitializeComponent();

            bindingTicketList = new BindingList<Ticket>(TicketList);
            ticketBindingSource = new BindingSource(bindingTicketList, null);
            ticketGrid.DataSource = ticketBindingSource;
        }

        // Refresh the list with new values
        public void RefreshTickets()
        {
            bindingTicketList.ResetBindings();
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
