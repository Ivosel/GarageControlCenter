namespace GarageControlCenter.Models
{
    // A class represenitng the barriers of the garage
    public class Barrier
    {
        public bool IsOpen = false;

        public void OpenBarrier()
        {
            IsOpen = true;
        }

        public void CloseBarrier()
        {
            IsOpen = false;
        }
    }
}
