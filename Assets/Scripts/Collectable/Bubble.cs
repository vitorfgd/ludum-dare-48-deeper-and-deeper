using UnityEngine;

namespace Collectable
{
    public class Bubble : Collectables
    {
        [SerializeField]
        private float _capacity;

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            
            if (other.GetComponent<Character>() == null)
            {
                return;
            }
            
            Character.Air = _capacity;
        }
    }
}
