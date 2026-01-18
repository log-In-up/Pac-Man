using UnityEngine;

namespace Pacman
{
    public class PointsModel
    {
        public uint CurrentPoints { get; private set; }
        public GameObject Player { get; private set; }

        public PointsModel(GameObject Player)
        {
            CurrentPoints = 0;
            this.Player = Player;
        }

        public void IncreasePointsBy(uint points)
        {
            CurrentPoints += points;
        }
    }
}