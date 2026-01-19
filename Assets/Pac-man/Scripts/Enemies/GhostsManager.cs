using System.Collections.Generic;
using UnityEngine;

namespace Pacman
{
    public class GhostsManager
    {
        public delegate void OnPlayerTouchNotifier();

        public event OnPlayerTouchNotifier PlayerTouchNotify;

        private readonly GameObject Player;
        private readonly List<Ghost> Ghosts;

        public GhostsManager(GameObject Player, List<Ghost> Ghosts)
        {
            this.Player = Player;
            this.Ghosts = Ghosts;
        }

        public void Start()
        {
            foreach (Ghost ghost in Ghosts)
            {
                ghost.Initialize(Player);
                ghost.GetOnPlayerTouch.AddListener(OnPlayerTouch);
            }
        }

        public void Stop()
        {
            foreach (Ghost ghost in Ghosts)
            {
                ghost.GetOnPlayerTouch.RemoveListener(OnPlayerTouch);
            }
        }

        private void OnPlayerTouch(GameObject Player)
        {
            PlayerTouchNotify?.Invoke();
        }
    }
}