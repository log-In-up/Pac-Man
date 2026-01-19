using System.Collections.Generic;
using UnityEngine;

namespace Pacman
{
    public class GhostsManager : MonoBehaviour
    {
        [SerializeField] private GameObject Player;
        [SerializeField] private List<Ghost> Ghosts;

        private void Start()
        {
            foreach (Ghost ghost in Ghosts)
            {
                ghost.Initialize(Player);
                ghost.GetOnPlayerTouch.AddListener(OnPlayerTouch);
            }
        }

        private void OnDisable()
        {
            foreach (Ghost ghost in Ghosts)
            {
                ghost.GetOnPlayerTouch.RemoveListener(OnPlayerTouch);
            }
        }

        private void OnPlayerTouch(GameObject Player)
        {
        }
    }
}