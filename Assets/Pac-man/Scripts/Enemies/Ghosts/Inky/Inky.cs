using System.Collections.Generic;
using UnityEngine;

namespace Pacman
{
    public class Inky : Ghost
    {
        [SerializeField, Min(0.01f)] private float PatrollingRadius = 10.0f;

        private IState State;
        private Dictionary<States, IState> StateMap;

        public override void Awake()
        {
            base.Awake();

            StateMap = new Dictionary<States, IState>
            {
                { States.Chasing, new Chasing(this) },
                { States.Patrolling, new Patrolling(this, PatrollingRadius) }
            };

            SwitchState(States.Patrolling);
        }

        private void Update()
        {
            State.Update();
        }

        public void SwitchState(States state)
        {
            State?.Exit();

            State = StateMap[state];
            State.Enter();
        }
    }
}