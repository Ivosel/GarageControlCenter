using System.ComponentModel.DataAnnotations;

namespace GarageControlCenterBackend.Models
{
    public class Garage
    {
        [Key]
        public int Id { get; private set; }
        [Required]
        public string Name { get; private set; }
        public List<Level> Levels { get; private set; }
        public int TotalCapacity { get; private set; }
        public List<GarageUser> Users { get; private set; }
        public List<Ticket> Tickets { get; private set; }

        private Garage() { }

        public Garage(List<int> spotsPerLevelList, string name)
        {
            Name = name;
            Tickets = new List<Ticket>();
            Users = new List<GarageUser>();
            Levels = new List<Level>();

            // Create levels and parking spots on each level according to the list received
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
            TotalCapacity = Levels.Sum(level => level.Capacity);
        }

        public override string ToString()
        {
            return Name;
        }

        // Return the total number of occupied spots
        public int TotalOccupiedSpots()
        {
            return Levels.Sum(level => level.OccupiedSpots());
        }

        // Return the total number of free spots
        public int TotalFreeSpots()
        {
            return Levels.Sum(level => level.FreeSpots());
        }

        public Ticket GetTicket(int ticketNumber)
        {
            return Tickets.FirstOrDefault(t => t.Id == ticketNumber);
        }

        public GarageUser GetUser(int userId)
        {
            return Users.FirstOrDefault(u => u.Id == userId);
        }
    }
}
