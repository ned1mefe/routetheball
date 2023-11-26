using UnityEngine;
using UnityEngine.EventSystems;

public class DragablePlatform : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasgroup;
    private readonly Vector3 inGameScale = new(115f, 160f, 0);

    void Awake()
    {
        canvas = GetComponentInParent<Canvas>();    
        rectTransform = GetComponent<RectTransform>();
        canvasgroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.localScale = inGameScale;
        canvasgroup.blocksRaycasts = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasgroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}