using System.ComponentModel;
using TMPro;
using UnityEngine;

namespace Pacman
{
    public class PointsView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI PointsText;

        private PointsViewModel ViewModel;

        public void Initialize(PointsViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        private void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(PointsViewModel.GetCurrentPoints))
            {
                PointsText.text = ViewModel.GetCurrentPoints.ToString();
            }
        }

        public void Launch()
        {
            ViewModel.PropertyChanged += PropertyChanged;
        }

        public void Stop()
        {
            ViewModel.PropertyChanged -= PropertyChanged;
        }
    }
}