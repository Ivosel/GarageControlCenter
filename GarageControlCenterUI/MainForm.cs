using GarageControlCenterBackend.Services;
using GarageControlCenterBackend.Models;
using GarageControlCenterUI.Controls;
using System.ComponentModel;

namespace GarageControlCenterUI
{
    // A class for the main form of the application
    [DesignerCategory("Form")]
    public partial class MainForm : Form
    {
        public readonly GarageService garageService;
        private readonly UserService userService;
        public Garage myGarage;
        public TicketsForm ticketsForm;
        private UsersForm usersForm;
        private EntryDemonstration entryDemo;
        private ExitDemonstration exitDemo;
        private List<LevelGrid> levelGrids;
        private List<Button> overviewControls;
        private List<LevelButton> levelButtons;

        public MainForm(GarageService garageService, UserService userService)
        {
            this.garageService = garageService;
            this.userService = userService;
            InitializeComponent();
            StartApp();
        }

        private void StartApp()
        {
            while (true)
            {
                if (TryCreateOrSelectGarage())
                {
                    break;
                }
            }

            InitializeForms();
            SubscribeToEvents();
            InitializeControls();
        }

        private bool TryCreateOrSelectGarage()
        {
            using (SelectGarageDialog createGarageDialog = new SelectGarageDialog())
            {
                DialogResult result = createGarageDialog.ShowDialog();

                if (result == DialogResult.Yes)
                {
                    GarageInfo info = ChooseNumberOfLevelsDialog();
                    if (info.SelectedNumberOfLevels > 0)
                    {
                        EnterSpotsPerLevelForm enterSpotsForm = new EnterSpotsPerLevelForm(info.SelectedNumberOfLevels);
                        enterSpotsForm.CreateGarageRequested += (s, spotsPerLevelList) => EnterSpotsForm_CreateGarageRequested(s, info.Name, spotsPerLevelList);

                        if (enterSpotsForm.ShowDialog() == DialogResult.OK)
                        {
                            MessageBox.Show("Garage created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            enterSpotsForm.Dispose();
                            return true;
                        }
                    }
                }
                else if (result == DialogResult.No)
                {
                    using (GarageListDialog selectGarageDialog = new GarageListDialog(garageService))
                    {
                        if (selectGarageDialog.ShowDialog() == DialogResult.OK)
                        {
                            myGarage = selectGarageDialog.SelectedGarage;
                            selectGarageDialog.Dispose();
                            return true;
                        }
                    }
                }
                else
                {
                    Application.Exit();
                    Environment.Exit(0);
                    return false;
                }
            }
            return false;
        }

        private void InitializeForms()
        {
            ticketsForm = new TicketsForm(myGarage.Tickets);
            usersForm = new UsersForm(myGarage, userService);
            entryDemo = new EntryDemonstration(myGarage, garageService, userService);
            exitDemo = new ExitDemonstration(myGarage, garageService, userService);
        }

        private void InitializeControls()
        {
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

            InitializeOverviewButton();
            InitializeLevelButtons();
            OverviewButton_Click(this, EventArgs.Empty);
        }

        private void SubscribeToEvents()
        {
            entryDemo.SubscribeToCustomerEntryEvent(HandleCustomerEntry);
            exitDemo.SubscribeToCustomerExitEvent(HandleCustomerExit);
        }

        // Method to prompt the user to choose the number of levels for the garage
        private GarageInfo ChooseNumberOfLevelsDialog()
        {
            using (var levelForm = new ChooseNumberOfLevelsForm())
            {
                return levelForm.ShowDialog() == DialogResult.OK ? levelForm.info : new GarageInfo();
            }
        }

        // Event handler for when the spots per level form requests to create a garage
        private async void EnterSpotsForm_CreateGarageRequested(object sender, string name, List<int> spotsPerLevelList)
        {
            myGarage = new Garage(spotsPerLevelList, name); // Create a new garage instance
            await garageService.AddGarageAsync(myGarage);
        }

        // Populate the level buttons on the main form
        private void InitializeOverviewButton()
        {
            Button overviewButton = new Button
            {
                Text = "HOME",
                Width = levelListLayout.Width - 10,
                Height = levelListLayout.Width - 10,
                Font = new Font("Arial", 14, FontStyle.Bold),
                FlatAppearance = { BorderSize = 3 },
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.LightGray,
                ForeColor = Color.Black,
                Margin = new Padding(10, 10, 10, 50)
            };
            overviewButton.Click += OverviewButton_Click;
            levelListLayout.Controls.Add(overviewButton);
        }

        private void InitializeLevelButtons()
        {
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
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateUI(chosenSpot)));
                return;
            }

            var levelButton = levelButtons.FirstOrDefault(b => b.Level.LevelNumber == int.Parse(chosenSpot.Placement[0].ToString()));
            var levelGrid = levelGrids.FirstOrDefault(g => g.selectedLevel.LevelNumber == int.Parse(chosenSpot.Placement[0].ToString()));
            var total = overviewControls.OfType<TotalButton>().FirstOrDefault();

            total?.RefreshLabels();
            levelButton?.RefreshLabels();
            levelGrid?.RefreshGrid(chosenSpot);
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
        private async Task HandleCustomerExit(object? sender, ExitDemonstration.CustomerExitEventArgs e)
        {
            ticketsForm.RefreshTickets();
            await garageService.ReleaseParkingSpotAsync(e.ChosenSpot);
            UpdateUI(e.ChosenSpot);
        }

        private async Task HandleCustomerEntry(object? sender, EntryDemonstration.CustomerEntryEventArgs e)
        {
            ticketsForm.RefreshTickets();
            await garageService.OccupyParkingSpotAsync(e.ChosenSpot);
            UpdateUI(e.ChosenSpot);
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usersForm.Show();
        }
    }
}
