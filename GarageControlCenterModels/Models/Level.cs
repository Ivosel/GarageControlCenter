namespace GarageControlCenterModels.Models
{
    public class Level
    {
        public int Id { get;  set; }
        public int GarageId { get; set; }
        public Garage GarageRef { get; set; }
        public int LevelNumber { get; set; }
        public int Capacity { get; set; }
        public List<ParkingSpot> Spots { get;  set; }

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
