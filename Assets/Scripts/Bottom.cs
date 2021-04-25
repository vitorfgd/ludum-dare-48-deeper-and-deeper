using UnityEngine;

public class Bottom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Character>() != null)
        {
            GameManager.Instance.Success = true;
        }
    }
}
