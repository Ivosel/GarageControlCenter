namespace GarageControlCenterModels.Models
{
    public class Garage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Level> Levels { get; set; }
        public int TotalCapacity { get; set; }
        public List<User> Users { get; set; }
        public List<Ticket> Tickets { get; set; }

        public Garage()
        {
            Tickets = new List<Ticket>();
            Users = new List<User>();
            Levels = new List<Level>();
        }

        public Garage(List<int> spotsPerLevelList)
        {
            // spotsPerLevellist recieved from a GUI form
            Tickets = new List<Ticket>();
            Users = new List<User>();
            Levels = new List<Level>();

            // Create levels and parking spots on each level according to the list recieved
            for (int i = 0; i < spotsPerLevelList.Count; i++)
            {
                var level = new Level
                {
                    LevelNumber = i + 1,
                    Capacity = spotsPerLevelList[i],
                    Spots = new List<ParkingSpot>()
                };

                for (int j = 1; j <= spotsPerLevelList[i]; j++)
                {
                    var spot = new ParkingSpot(i + 1, j)
                    {
                        // Mark all spots as free initially
                        IsOccupied = false
                    };

                    level.Spots.Add(spot);
                }

                Levels.Add(level);
            }

            // Calculate garage's total capacity by adding all levels' capacity
            foreach (Level level in Levels)
            {
                TotalCapacity += level.Capacity;
            }
        }

        // Return a number of total spots occupied
        public int TotalOccupiedSpots()
        {
            int totalOccupiedSpots = 0;
            foreach (Level level in Levels)
            {
                totalOccupiedSpots += level.OccupiedSpots();
            }
            return totalOccupiedSpots;
        }

        // Return a number of total free spots
        public int TotalFreeSpots()
        {
            int totalFreeSpots = 0;
            foreach (Level level in Levels)
            {
                totalFreeSpots += level.FreeSpots();
            }
            return totalFreeSpots;
        }
    }
}
