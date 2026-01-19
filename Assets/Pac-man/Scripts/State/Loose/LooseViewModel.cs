using UnityEngine.SceneManagement;

namespace Pacman
{
    public class LooseViewModel
    {
        private LooseModel Model;

        public LooseViewModel(LooseModel Model)
        {
            this.Model = Model;
        }

        internal void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}