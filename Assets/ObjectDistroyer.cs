using UnityEngine;

public class ObjectDistroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            Destroy(collision.gameObject);
            GameManager.instance.PlayerDie();
        }
    }

}