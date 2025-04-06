using UnityEngine;

public class GridBuilder : MonoBehaviour
{
    public GameObject cellPrefab;         // prefab-ul tău „Celula”
    public Transform gridRoot;            // GameObject-ul gol „GridRoot”
    public Vector2Int gridSize = new Vector2Int(5, 5);
    public float spacing = 1.1f;          // distanța între celule

    public Vector2 startPosition = new Vector2(0, 0); // punctul din stânga-sus al grilei

    [ContextMenu("Generate Grid")]
    public void GenerateGrid()
    {
        ClearGrid(); // curățăm înainte

        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                Vector2 position = startPosition + new Vector2(x * spacing, -y * spacing);
                GameObject cell = Instantiate(cellPrefab, position, Quaternion.identity, gridRoot);
                cell.name = $"Celula ({x},{y})";
            }
        }
    }

    public void ClearGrid()
    {
        if (gridRoot == null) return;

        for (int i = gridRoot.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(gridRoot.GetChild(i).gameObject);
        }
    }
}
