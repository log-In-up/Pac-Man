using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Pacman
{
    public class PointsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public delegate void OnAllCollectablesNotifier();

        public event OnAllCollectablesNotifier Notify;

        public uint GetCurrentPoints => Model.CurrentPoints;

        private readonly PointsModel Model;
        private readonly CollectibleDetector PlayerCollectibleDetector;

        public PointsViewModel(PointsModel Model)
        {
            this.Model = Model;

            PlayerCollectibleDetector = Model.Player.GetComponent<CollectibleDetector>();

            PlayerCollectibleDetector.OnTouchCollectable.AddListener(OnTouchCollectable);
        }

        ~PointsViewModel()
        {
            PlayerCollectibleDetector.OnTouchCollectable.RemoveListener(OnTouchCollectable);
        }

        public void OnTouchCollectable(GameObject collectable)
        {
            Model.IncreasePointsBy(1);

            OnPropertyChanged(nameof(GetCurrentPoints));

            collectable.SetActive(false);

            if (Model.TotalPoints == Model.CurrentPoints)
            {
                Notify?.Invoke();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}