namespace GarageControlCenterBackend.Models
{
    public class Barrier
    {
        public bool IsOpen { get; private set; } = false;

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
