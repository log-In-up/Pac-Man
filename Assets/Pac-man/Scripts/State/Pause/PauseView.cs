using UnityEngine;
using UnityEngine.UI;

namespace Pacman
{
    public class PauseView : MonoBehaviour
    {
        [SerializeField] private Button PauseButton;

        private PauseViewModel ViewModel;

        public void Initialize(PauseViewModel ViewModel)
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