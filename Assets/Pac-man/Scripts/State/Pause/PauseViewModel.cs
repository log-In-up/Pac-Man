namespace Pacman
{
    public class PauseViewModel
    {
        public delegate void PauseHandler();

        public event PauseHandler Notify;

        private PauseModel Model;

        public PauseViewModel(PauseModel Model)
        {
            this.Model = Model;
        }

        internal void SwitchPause()
        {
            Notify?.Invoke();
        }
    }
}