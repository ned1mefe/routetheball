using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private Sprite dashedSprite;
    [SerializeField]
    private Sprite greenSprite;

    private SpriteRenderer _spriteRenderer;


    public bool achieved { get; private set; }
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = dashedSprite;
        achieved = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            _spriteRenderer.sprite = greenSprite;
            achieved = true;
        }

        GameManager.instance.CheckPlayerWin();
    }

    public void Reset()
    {
        _spriteRenderer.sprite = dashedSprite;
        achieved=false;
    }
}
