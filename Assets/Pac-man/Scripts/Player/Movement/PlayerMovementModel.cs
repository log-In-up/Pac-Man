using UnityEngine;

namespace Pacman
{
    public class PlayerMovementModel
    {
        public Joystick Joystick { get; private set; }
        public GameObject Player { get; private set; }
        public float MovementSpeed { get; private set; }
        public LayerMask SelfLayer { get; private set; }

        public PlayerMovementModel(MovementData data)
        {
            Joystick = data.Joystick;
            Player = data.Player;
            MovementSpeed = data.MovementSpeed;
            SelfLayer = data.SelfLayer;
        }
    }
}