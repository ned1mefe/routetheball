using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
        }
    }
}
