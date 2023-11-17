using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    private readonly float stopTreshold = 0.1f;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    private bool isStopped() => rigidbody2d.velocity.magnitude < stopTreshold;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isStopped()) return;

        GameManager.instance.PlayerDie();
    }

    public void WinEffect()
    {
        rigidbody2d.velocity = new Vector2(0, 5);
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 3f);
    }
}
