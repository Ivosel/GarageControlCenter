namespace GarageControlCenter.Models
{
    // A class representing a level in the garage which consists of parking spots
    public class Level
    {
        public int LevelNumber { get; set; }
        public int Capacity { get; set; }
        public List<ParkingSpot> Spots { get; set; }

        public Level()
        {
            Spots = new List<ParkingSpot>();
        }

        public int OccupiedSpots()
        {
            int occupiedCount = 0;
            foreach (var spot in Spots)
            {
                if (spot.IsOccupied)
                {
                    occupiedCount++;
                }
            }
            return occupiedCount;
        }

        public int FreeSpots()
        {
            return Capacity - OccupiedSpots();
        }
    }
}
