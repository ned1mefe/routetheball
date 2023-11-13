using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private Sprite dashedSprite;
    [SerializeField]
    private Sprite greenSprite;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = dashedSprite;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            _spriteRenderer.sprite = greenSprite;
        }
    }
}
