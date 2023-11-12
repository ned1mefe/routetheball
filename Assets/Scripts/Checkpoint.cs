using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered OnTriggerEnter2D");
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("Collided");
            gameObject.SetActive(false);
        }
    }

}
