using System;
using UnityEngine;

namespace Pacman
{
    [Serializable]
    public struct MovementData
    {
        public Joystick Joystick;
        public GameObject Player;

        [Min(0.01f)]
        public float MovementSpeed;

        public LayerMask SelfLayer;
    }
}