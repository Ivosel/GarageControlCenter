using System.ComponentModel.DataAnnotations;

namespace GarageControlCenterBackend.Models
{
    public class Level
    {
        public int Id { get; private set; }
        public int GarageId { get; private set; }
        public Garage GarageRef { get; private set; }
        public int LevelNumber { get; private set; }
        public int Capacity { get; private set; }
        public List<ParkingSpot> Spots { get; private set; }

        private Level() { }

        public Level(int levelNumber, int capacity)
        {
            LevelNumber = levelNumber;
            Capacity = capacity;
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
