namespace GarageControlCenterModels.Models
{
    public class ParkingSpot
    {
        public int Id { get;  set; }
        public Level LevelRef { get;  set; }
        public int LevelId { get;  set; }
        public bool IsOccupied { get; set; }
        public string Placement { get;  set; }

        public void ReserveSpot()
        {
            IsOccupied = true;
        }

        public void ReleaseSpot()
        {
            IsOccupied = false;
        }

        public ParkingSpot()
        {
        }

        // Constructor to initialize the spot with its position in the garage
        public ParkingSpot(int level, int spotNumber)
        {
            Placement = $"{level}-{spotNumber}";
        }
    }
}
