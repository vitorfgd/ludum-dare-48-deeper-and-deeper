using UnityEngine;

namespace Collectable
{
    [RequireComponent(typeof(Collider2D))]
    public class Collectables : MonoBehaviour
    {
        protected Character Character;
        
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            Character = other.GetComponent<Character>();
            if (Character == null)
            {
                return;
            }
            
            Destroy(gameObject);
        }
    }
}
