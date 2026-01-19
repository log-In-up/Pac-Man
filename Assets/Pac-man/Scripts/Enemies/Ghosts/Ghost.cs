using UnityEngine;
using UnityEngine.AI;

namespace Pacman
{
    [RequireComponent(typeof(NavMeshAgent), typeof(SphereCollider))]
    public abstract class Ghost : MonoBehaviour
    {
        [SerializeField] private LayerMask HitLayers;

        private const string PLAYER = "Player";

        protected internal NavMeshAgent Agent;
        protected internal GameObject Player;
        private OnPlayerTouch OnPlayerTouch;
        private SphereCollider Collider;

        public OnPlayerTouch GetOnPlayerTouch
        {
            get
            {
                return OnPlayerTouch;
            }
        }

        public virtual void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            Collider = GetComponent<SphereCollider>();

            OnPlayerTouch = new OnPlayerTouch();
        }

        public virtual void Initialize(GameObject player)
        {
            Player = player;
        }

        protected internal bool PlayerDetected()
        {
            Vector3 offset = new Vector3(0.0f, 0.5f, 0.0f);
            Vector3 start = Agent.transform.position + offset;
            Vector3 target = Player.transform.position + offset;

            float distance = Vector3.Distance(start, target);
            Vector3 direction = (target - start).normalized;

            if (Physics.SphereCast(start, Collider.radius, direction, out RaycastHit hit, distance, HitLayers))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == Player)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag(PLAYER))
            {
                OnPlayerTouch.Invoke(collision.collider.gameObject);
            }
        }

        private void OnDrawGizmos()
        {
            if (Agent == null)
            {
                return;
            }

            if (Agent.hasPath && !Agent.pathPending)
            {
                Vector3[] corners = Agent.path.corners;
                Gizmos.color = Color.red;

                if (corners.Length < 2)
                {
                    Gizmos.DrawLine(transform.position, Player.transform.position);
                    return;
                }

                for (int i = 1; i < corners.Length; i++)
                {
                    Gizmos.DrawLine(corners[i - 1], corners[i]);
                }
            }
        }
    }
}