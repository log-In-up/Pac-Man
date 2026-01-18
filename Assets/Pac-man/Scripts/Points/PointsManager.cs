using UnityEngine;

namespace Pacman
{
    public class PointsManager : MonoBehaviour
    {
        [SerializeField] private PointsView PointsView;
        [SerializeField] private GameObject Player;

        private PointsModel PointsModel;
        private PointsViewModel PointsViewModel;

        private void Awake()
        {
            PointsModel = new PointsModel(Player);
            PointsViewModel = new PointsViewModel(PointsModel);
        }

        private void Start()
        {
            PointsView.Initialize(PointsViewModel);

            PointsView.Launch();
        }

        private void OnDisable()
        {
            PointsView.Stop();
        }
    }
}