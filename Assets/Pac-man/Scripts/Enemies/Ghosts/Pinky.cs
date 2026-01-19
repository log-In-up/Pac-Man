using UnityEngine;
using UnityEngine.AI;

namespace Pacman
{
    public class Pinky : Ghost
    {
        [SerializeField, Min(0.01f)] private float AheadRange = 2.0f;

        private bool IsAheadPositionIsReached;

        public override void Awake()
        {
            base.Awake();

            IsAheadPositionIsReached = false;
        }

        private void Update()
        {
            Vector3 Position = Player.transform.position;

            if (Agent.hasPath && !IsAheadPositionIsReached)
            {
                if (Agent.remainingDistance > 0.1f)
                {
                    Position = GetAheadPosition();
                }
                else
                {
                    IsAheadPositionIsReached = true;
                }
            }

            Agent.SetDestination(Position);
        }

        private Vector3 GetAheadPosition()
        {
            Vector3 Target = Player.transform.position + (Player.transform.forward * AheadRange);

            if (NavMesh.SamplePosition(Target, out NavMeshHit hit, AheadRange, NavMesh.AllAreas))
            {
                Target = hit.position;
            }

            return Target;
        }
    }
}