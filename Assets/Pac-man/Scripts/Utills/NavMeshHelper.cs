using UnityEngine;
using UnityEngine.AI;

namespace Pacman
{
    public class NavMeshHelper
    {
        public static Vector3 GetRandomPointOnNavMesh(Vector3 origin, float radius)
        {
            Vector3 randomDirection = Random.insideUnitSphere * radius;
            randomDirection += origin;

            if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, radius, NavMesh.AllAreas))
            {
                return hit.position;
            }

            return origin;
        }
    }
}