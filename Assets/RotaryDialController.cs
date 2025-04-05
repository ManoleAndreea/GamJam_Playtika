using UnityEngine;
using UnityEngine.EventSystems;

public class RotaryDialController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform dial;
    public float returnSpeed = 300f;
    public float maxRotation = -324f;
    public float snapThreshold = 20f;
    public PhoneDialPuzzle puzzleScript;

    private bool isDragging = false;
    private float currentAngle = 0f;
    private float startAngle = 0f;
    private bool returning = false;

void Update()
{
    if (isDragging)
    {
        Vector2 from = Vector2.up; // Referință de la verticală
        Vector2 current = (Input.mousePosition - dial.position).normalized;

        float angle = Vector2.SignedAngle(from, current);
        float delta = angle - startAngle;
        delta = Mathf.Clamp(delta, maxRotation, 0f);

        currentAngle = delta;
        dial.localEulerAngles = new Vector3(0, 0, currentAngle);

        Debug.Log($"[RotaryDial] Dragging... Angle: {currentAngle}");
    }
    else if (returning)
    {
        currentAngle = Mathf.MoveTowards(currentAngle, 0f, returnSpeed * Time.deltaTime);
        dial.localEulerAngles = new Vector3(0, 0, currentAngle);

        if (Mathf.Approximately(currentAngle, 0f))
            returning = false;
    }
}

public void OnPointerDown(PointerEventData eventData)
{
    if (returning) return;
    isDragging = true;

    Vector2 from = Vector2.up;
    Vector2 start = (Input.mousePosition - dial.position).normalized;

    startAngle = Vector2.SignedAngle(from, start);
    Debug.Log("[RotaryDial] Pointer DOWN. StartAngle: " + startAngle);
}

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isDragging) return;
        isDragging = false;

        Debug.Log("[RotaryDial] Pointer UP. FinalAngle: " + currentAngle);

        // am crescut pragul de rotire ca să nu fie prea strict
        if (Mathf.Abs(currentAngle) < 20f)
        {
            Debug.Log("[RotaryDial] Rotire prea mică, ignorat.");
            returning = true;
            return;
        }

        int digit = Mathf.RoundToInt(Mathf.Abs(currentAngle) / 36f);
        digit = Mathf.Clamp(digit, 0, 9);

        if (Mathf.Abs(currentAngle - (digit * -36f)) <= snapThreshold)
        {
            Debug.Log("[RotaryDial] Ai format cifra: " + digit);
            puzzleScript.PressDigit(digit);
        }
        else
        {
            Debug.Log("[RotaryDial] Nu s-a nimerit exact pe cifra. Unghi actual: " + currentAngle + ", cifra calculată: " + digit);
        }

        returning = true;
    }

    public void DialToDigit(int digit)
    {
        if (returning || isDragging) return;

        Debug.Log("CLICK pe cifra: " + digit);

        float angle = -36f * digit;
        currentAngle = angle;
        dial.localEulerAngles = new Vector3(0, 0, currentAngle);

        puzzleScript.PressDigit(digit);
        returning = true;
    }
}
