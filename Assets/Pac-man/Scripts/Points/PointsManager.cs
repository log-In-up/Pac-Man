using System.Collections.Generic;
using UnityEngine;

namespace Pacman
{
    public class PointsManager
    {
        public delegate void OnAllCollectablesNotifier();

        public event OnAllCollectablesNotifier AllCollectablesTaken;

        private readonly PointsView PointsView;

        private PointsModel PointsModel;
        private PointsViewModel PointsViewModel;

        public PointsManager(List<GameObject> Points, PointsView PointsView, GameObject Player)
        {
            this.PointsView = PointsView;

            PointsModel = new PointsModel(Player, Points);
            PointsViewModel = new PointsViewModel(PointsModel);

            this.PointsView.Initialize(PointsViewModel);
        }

        public void Start()
        {
            PointsViewModel.Notify += OnAllCollectiblesNotifier;
            PointsView.Launch();
        }

        private void OnAllCollectiblesNotifier()
        {
            AllCollectablesTaken?.Invoke();
        }

        public void Stop()
        {
            PointsViewModel.Notify -= OnAllCollectiblesNotifier;
            PointsView.Stop();
        }
    }
}