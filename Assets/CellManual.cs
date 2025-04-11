using UnityEngine;

public class CellManual : MonoBehaviour
{
    public Sprite[] sprites;
    private int state = 0;
    private SpriteRenderer sr;

    public int gridX;
    public int gridY;


    public int checkpointNumber = 0;
    public bool IsActive => state != 0;

    // ✅ Adaugă coordonatele pentru validare
    public int x;
    public int y;

    void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        UpdateVisual();
    }

    void OnMouseDown()
    {
        Debug.Log($"CLICK DETECTAT pe {name} → stare {state}");
        state = (state + 1) % sprites.Length;
        UpdateVisual();
    }

    void UpdateVisual()
    {
        if (sprites != null && sprites.Length > 0 && sr != null)
            sr.sprite = sprites[state];
    }
}
