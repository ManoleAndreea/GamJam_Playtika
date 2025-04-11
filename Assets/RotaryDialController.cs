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
            Vector2 dir = Input.mousePosition - dial.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;

            float delta = angle - startAngle;
            delta = Mathf.Clamp(delta, maxRotation, 0f);
            currentAngle = delta;
            dial.localEulerAngles = new Vector3(0, 0, currentAngle);
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

        Vector2 dir = Input.mousePosition - dial.position;
        startAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isDragging) return;
        isDragging = false;

        if (Mathf.Abs(currentAngle) < 20f)
        {
            returning = true;
            return;
        }

        int digit = Mathf.RoundToInt(Mathf.Abs(currentAngle) / 36f);
        digit = Mathf.Clamp(digit, 0, 9);

        if (Mathf.Abs(currentAngle - (digit * -36f)) <= snapThreshold)
        {
            puzzleScript.PressDigit(digit);
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
