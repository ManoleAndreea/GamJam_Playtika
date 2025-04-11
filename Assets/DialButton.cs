using UnityEngine;
using UnityEngine.EventSystems;

public class DialButton : MonoBehaviour, IPointerDownHandler
{
    public int digit; // setat din Inspector
    public RotaryDialController dialController;

    public void OnPointerDown(PointerEventData eventData)
    {
        dialController.DialToDigit(digit);
    }
}
