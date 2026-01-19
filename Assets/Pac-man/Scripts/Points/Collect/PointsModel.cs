using System.Collections.Generic;
using UnityEngine;

namespace Pacman
{
    public class PointsModel
    {
        public uint CurrentPoints { get; private set; }
        public uint TotalPoints { get; private set; }
        public GameObject Player { get; private set; }

        public PointsModel(GameObject Player, List<GameObject> points)
        {
            CurrentPoints = 0;
            TotalPoints = (uint)points.Count;
            this.Player = Player;
        }

        public void IncreasePointsBy(uint points)
        {
            CurrentPoints += points;
        }
    }
}