using UnityEngine;

namespace Pacman
{
    public class PlayerManager : MonoBehaviour
    {
        public MovementData movementData;

        private PlayerMovementModel playerMovementModel;
        private PlayerMovementViewModel movementViewModel;

        private void Start()
        {
            playerMovementModel = new PlayerMovementModel(movementData);
            movementViewModel = new PlayerMovementViewModel(playerMovementModel);
        }

        private void FixedUpdate()
        {
            movementViewModel.FixedUpdate();
        }
    }
}