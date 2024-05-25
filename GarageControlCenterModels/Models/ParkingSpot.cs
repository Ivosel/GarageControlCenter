namespace GarageControlCenterBackend.Models
{
    public class ParkingSpot
    {
        public int Id { get; private set; }
        public Level LevelRef { get; private set; }
        public int LevelId { get; private set; }
        public bool IsOccupied { get; private set; }
        public string Placement { get; private set; }

        public void ReserveSpot()
        {
            IsOccupied = true;
        }

        public void ReleaseSpot()
        {
            IsOccupied = false;
        }

        private ParkingSpot() { }

        // Constructor to initialize the spot with its position in the garage
        public ParkingSpot(int levelId, int spotNumber)
        {
            Placement = $"{levelId}-{spotNumber}";
            IsOccupied = false;
        }
    }
}
