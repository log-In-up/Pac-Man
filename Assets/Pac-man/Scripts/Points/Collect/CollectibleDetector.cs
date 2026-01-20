using UnityEngine;

namespace Pacman
{
    public class CollectibleDetector : MonoBehaviour
    {
        public OnCollectEvent OnTouchCollectable = new OnCollectEvent();

        private const string COLLECTABLE = "Collectable";

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag(COLLECTABLE))
            {
                OnTouchCollectable.Invoke(collision.collider.gameObject);
            }
        }
    }
}