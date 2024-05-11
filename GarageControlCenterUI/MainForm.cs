using GarageControlCenter.Models;
using GarageControlCenterUI.Controls;
using System.ComponentModel;

namespace GarageControlCenterUI
{
    // A class for the main form of the application
    [DesignerCategory("Form")]
    public partial class MainForm : Form
    {
        public Garage myGarage;
        private List<LevelGrid> levelGrids;
        private List<Button> overviewControls;
        private List<LevelButton> levelButtons;
        public TicketsForm ticketsForm;
        private EntryDemonstration entryDemo;
        private ExitDemonstration exitDemo;
        private UsersForm usersForm;

        public MainForm()
        {
            InitializeComponent();
            StartApp();
        }

        private void StartApp()
        {
            // Display a welcome message and prompt the user to choose a garage
            DialogResult result = MessageBox.Show("Welcome to the garage control center!", "Choose a garage", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Prompt the user to choose the number of levels for the garage
                int numLevels = ChooseNumberOfLevelsDialog();
                if (numLevels > 0)
                {
                    // Prompt the user to enter the spots per level for the garage
                    EnterSpotsPerLevelForm enterSpotsForm = new EnterSpotsPerLevelForm(numLevels);
                    enterSpotsForm.CreateGarageRequested += EnterSpotsForm_CreateGarageRequested;

                    if (enterSpotsForm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Garage created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                // Implement logic to open an existing garage
            }

            // Initialize the tickets form
            ticketsForm = new TicketsForm(myGarage.Tickets);
            ticketsForm.RefreshTickets();
            usersForm = new UsersForm(myGarage.Users);
            usersForm.RefreshUsers();


            entryDemo = new EntryDemonstration(this);
            exitDemo = new ExitDemonstration(this);

            entryDemo.SubscribeToCustomerEntryEvent(HandleCustomerEntry);
            exitDemo.SubscribeToCustomerExitEvent(HandleCustomerExit);

            levelGrids = new List<LevelGrid>();
            levelButtons = new List<LevelButton>();

            foreach (Level level in myGarage.Levels)
            {
                levelGrids.Add(new LevelGrid(level));
                levelButtons.Add(new LevelButton(level));
            }

            overviewControls = new List<Button>();

            // Create overview buttons and add them to the list of button controls
            TotalButton totalButton = new TotalButton(myGarage);
            BarrierButton entrance = new BarrierButton("entrance");
            BarrierButton exit = new BarrierButton("exit");
            PaymentMachineButton paymentMachine = new PaymentMachineButton(this);

            overviewControls.Add(totalButton);
            overviewControls.Add(entrance);
            overviewControls.Add(exit);
            overviewControls.Add(paymentMachine);

            PopulateLevelButtons(); // Populate the level buttons on the main form
            OverviewButton_Click(this, EventArgs.Empty); // Show the overview (HOME) on the main form
        }



        // Method to prompt the user to choose the number of levels for the garage
        private int ChooseNumberOfLevelsDialog()
        {
            using (var levelForm = new ChooseNumberOfLevelsForm())
            {
                return levelForm.ShowDialog() == DialogResult.OK ? levelForm.SelectedNumberOfLevels : 0;
            }
        }

        // Event handler for when the spots per level form requests to create a garage
        private void EnterSpotsForm_CreateGarageRequested(object sender, List<int> spotsPerLevelList)
        {
            myGarage = new Garage(spotsPerLevelList); // Create a new garage instance
        }

        // Populate the level buttons on the main form
        public void PopulateLevelButtons()
        {
            levelListLayout.Controls.Clear();

            // Create the overview button
            Button overviewButton = new Button();
            overviewButton.Text = "HOME";
            overviewButton.Width = levelListLayout.Width - 10;
            overviewButton.Height = levelListLayout.Width - 10;
            overviewButton.Font = new Font("Arial", 14, FontStyle.Bold);
            overviewButton.FlatAppearance.BorderSize = 3;
            overviewButton.FlatStyle = FlatStyle.Flat;
            overviewButton.BackColor = Color.LightGray;
            overviewButton.ForeColor = Color.Black;
            overviewButton.Margin = new Padding(10, 10, 10, 50);
            overviewButton.Click += new EventHandler(OverviewButton_Click); // Event handler for overview button click
            levelListLayout.Controls.Add(overviewButton); // Add the overview button to the layout

            // Create buttons for each level in the garage
            foreach (LevelButton levelButton in levelButtons)
            {
                levelButton.Click += LevelButton_Click; // Event handler for level button click
                levelButton.Width = levelListLayout.Width - 10;
                levelButton.Height = levelListLayout.Width - 10;
                levelListLayout.Controls.Add(levelButton);
            }
        }
        private void UpdateUI(ParkingSpot chosenSpot)
        {
            var levelButton = levelButtons.FirstOrDefault(b => b.Level.LevelNumber == int.Parse(chosenSpot.Placement[0].ToString()));
            var levelGrid = levelGrids.FirstOrDefault(g => g.selectedLevel.LevelNumber == int.Parse(chosenSpot.Placement[0].ToString()));
            TotalButton total = overviewControls.OfType<TotalButton>().FirstOrDefault();

            total.RefreshLabels();
            levelButton.RefreshLabels();
            levelGrid.RefreshGrid(chosenSpot);
        }

        // Event handler for overview button click
        private void OverviewButton_Click(object sender, EventArgs e)
        {
            parkingSpotGrid.Controls.Clear();

            // Add total button, entrance barrier button, exit barrier button, and payment machine button to the parking spot grid
            foreach (Button b in overviewControls)
            {
                parkingSpotGrid.Controls.Add(b);
            }
        }

        // Event handler for level button click
        private void LevelButton_Click(object sender, EventArgs e)
        {
            if (sender is Button levelButton && levelButton.Tag is Level selectedLevel)
            {
                PopulateParkingSpots(selectedLevel); // Populate parking spots for the selected level
            }
        }

        // Method to populate parking spots for a selected level
        public void PopulateParkingSpots(Level selectedLevel)
        {
            parkingSpotGrid.Controls.Clear();
            parkingSpotGrid.Controls.Add(levelGrids[selectedLevel.LevelNumber - 1]);
        }

        // Event handler for the entrance demonstration menu item click
        private void entranceDemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the entry demonstration form
            entryDemo.Show();
        }

        // Event handler for the exit demonstration menu item click
        private void exitDemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the exit demonstration form
            exitDemo.Show();
        }

        // Event handler for the edit menu item click
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ticketsForm.Show();
        }
        private void HandleCustomerExit(object? sender, ExitDemonstration.CustomerExitEventArgs e)
        {
            UpdateUI(e.ChosenSpot);
        }

        private void HandleCustomerEntry(object? sender, EntryDemonstration.CustomerEntryEventArgs e)
        {
            UpdateUI(e.ChosenSpot);
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usersForm.Show();
        }
    }
}
