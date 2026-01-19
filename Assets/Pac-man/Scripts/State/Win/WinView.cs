using UnityEngine;
using UnityEngine.UI;

namespace Pacman
{
    public class WinView : MonoBehaviour
    {
        [SerializeField] private Button PlayAgainButton;

        private WinViewModel ViewModel;

        public void Initialize(WinViewModel ViewModel)
        {
            this.ViewModel = ViewModel;

            PlayAgainButton.onClick.AddListener(OnClickRestart);
        }

        public void Deinitialize()
        {
            PlayAgainButton.onClick.RemoveListener(OnClickRestart);
        }

        private void OnClickRestart()
        {
            ViewModel.Restart();
        }
    }
}