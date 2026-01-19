using UnityEngine.SceneManagement;

namespace Pacman
{
    public class WinViewModel
    {
        private WinModel Model;

        public WinViewModel(WinModel Model)
        {
            this.Model = Model;
        }

        internal void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}