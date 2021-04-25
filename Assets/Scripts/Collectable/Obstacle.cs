using UnityEngine;

namespace Collectable
{
    public class Obstacle : Collectables
    {
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);

            if (other.GetComponent<Character>() == null)
            {
                return;
            }
            
            GameManager.Instance.Success = false;
        }
    }
}
