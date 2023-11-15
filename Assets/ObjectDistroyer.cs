using UnityEngine;

public class ObjectDistroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            GameManager.instance.PlayerDie();
        }
    }

}