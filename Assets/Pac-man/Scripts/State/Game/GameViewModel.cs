namespace Pacman
{
    public class GameViewModel
    {
        public delegate void PauseHandler();

        public event PauseHandler Notify;

        private GameModel Model;

        public GameViewModel(GameModel Model)
        {
            this.Model = Model;
        }

        internal void SwitchPause()
        {
            Notify?.Invoke();
        }
    }
}