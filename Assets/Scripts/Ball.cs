using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    private readonly float stopTreshold = 0.1f;
    private readonly float stopLimit = 1.2f;
    private float stopDuration;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        stopDuration = 0;
        rigidbody2d.sleepMode = RigidbodySleepMode2D.NeverSleep;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (rigidbody2d.velocity.magnitude < stopTreshold)
        {
            stopDuration += Time.fixedDeltaTime;

            if (stopDuration < stopLimit) return;

            GameManager.instance.PlayerDie();
        }
        else stopDuration = 0;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        stopDuration = 0;
    }

    public void WinEffect()
    {
        rigidbody2d.velocity = new Vector2(0, 17);
        GetComponent<Collider2D>().enabled = false;
        rigidbody2d.gravityScale = 5;
        Destroy(gameObject, 5f);

    }
}
