using UnityEngine;
using UnityEngine.UI;

namespace Pacman
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private Button PauseButton;

        private GameViewModel ViewModel;

        public void Initialize(GameViewModel ViewModel)
        {
            this.ViewModel = ViewModel;

            PauseButton.onClick.AddListener(OnPauseButtonClick);
        }

        public void Deinitialize()
        {
            PauseButton.onClick.RemoveListener(OnPauseButtonClick);
        }

        private void OnPauseButtonClick()
        {
            ViewModel.SwitchPause();
        }
    }
}