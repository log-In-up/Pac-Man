using UnityEngine;

namespace Pacman
{
    public class Patrolling : IState
    {
        private readonly Inky Owner;
        private readonly float PatrollingRadius;

        public Patrolling(Inky Owner, float PatrollingRadius)
        {
            this.Owner = Owner;
            this.PatrollingRadius = PatrollingRadius;
        }

        public void Enter()
        {
            SetNextDestination();
        }

        public void Exit()
        {
            Owner.Agent.SetDestination(Owner.transform.position);
        }

        public void Update()
        {
            if (Owner.Agent.remainingDistance <= Owner.Agent.stoppingDistance)
            {
                SetNextDestination();
            }

            if (Owner.PlayerDetected())
            {
                Owner.SwitchState(States.Chasing);
            }
        }

        private void SetNextDestination()
        {
            Vector3 position = NavMeshHelper.GetRandomPointOnNavMesh(Owner.transform.position, PatrollingRadius);

            Owner.Agent.SetDestination(position);
        }
    }
}