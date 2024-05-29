namespace GarageControlCenterBackend.Models
{
    public class Garage
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Level> Levels { get; private set; }
        public int TotalCapacity { get; private set; }
        public List<GarageUser> Users { get; private set; }
        public List<Ticket> Tickets { get; private set; }

        private Garage() { }

        public Garage(List<int> spotsPerLevelList, string name)
        {
            // spotsPerLevellist recieved from a GUI form
            Name = name;
            Tickets = new List<Ticket>();
            Users = new List<GarageUser>();
            Levels = new List<Level>();

            // Create levels and parking spots on each level according to the list recieved
            for (int i = 0; i < spotsPerLevelList.Count; i++)
            {
                var level = new Level(i + 1, spotsPerLevelList[i]);

                for (int j = 1; j <= spotsPerLevelList[i]; j++)
                {
                    var spot = new ParkingSpot(i + 1, j);
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

        public override string ToString()
        {
            return Name;
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
