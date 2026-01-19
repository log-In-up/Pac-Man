using System;
using UnityEngine;
using UnityEngine.UI;

namespace Pacman
{
    public class LooseView : MonoBehaviour
    {
        [SerializeField] private Button RestartButton;

        private LooseViewModel ViewModel;

        public void Initialize(LooseViewModel ViewModel)
        {
            this.ViewModel = ViewModel;

            RestartButton.onClick.AddListener(OnClickRestart);
        }

        public void Deinitialize()
        {
            RestartButton.onClick.RemoveListener(OnClickRestart);
        }

        private void OnClickRestart()
        {
            ViewModel.Restart();
        }
    }
}