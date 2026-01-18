using UnityEngine;

namespace Pacman
{
    public class CollectibleDetector : MonoBehaviour
    {
        public OnCollectEvent OnTouchCollectable;

        private const string COLLECTABLE = "Collectable";

        private void Awake()
        {
            OnTouchCollectable = new OnCollectEvent();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag(COLLECTABLE))
            {
                OnTouchCollectable.Invoke(collision.collider.gameObject);
            }
        }
    }
}