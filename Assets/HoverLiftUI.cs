using UnityEngine;
using UnityEngine.EventSystems;

public class HoverLiftUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float liftAmount=10f;
    public float speed=10f;

    private Vector3 originalPos;
    private RectTransform rectTransform;
    private bool hovering=false;

    void Start()
    {
        rectTransform=GetComponent<RectTransform>();
        originalPos=rectTransform.anchoredPosition;
    }

    void Update()
    {
        Vector3 targetPos=hovering 
            ? originalPos+new Vector3(0, liftAmount, 0)
            : originalPos;

        rectTransform.anchoredPosition=Vector3.Lerp(rectTransform.anchoredPosition, targetPos, Time.deltaTime*speed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovering=true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovering=false;
    }
}
