using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;

public class PuzzleValidator : MonoBehaviour
{
    public Transform gridRoot; // Obiectul GridRoot
    public int gridWidth = 5;
    public int gridHeight = 5;

    // Soluția corectă (modifică după nevoi)
    private int[,] correctSolution = new int[5, 5]
    {
        {2, 1, 2, 5, 2},
        {6, 5, 2, 2, 2},
        {2, 2, 2, 6, 2},
        {2, 3, 2, 5, 2},
        {3, 1, 1, 4, 2 }
    };

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ValidatePuzzle();
        }
    }

    void ValidatePuzzle()
{
    var allCells = gridRoot.GetComponentsInChildren<CellManual>();
    bool valid = true;

    foreach (var cell in allCells)
    {
        int x = Mathf.RoundToInt(cell.transform.localPosition.x);
        int y = Mathf.RoundToInt(cell.transform.localPosition.y);

        // VERIFICARE INDEX VALABIL
        if (x < 0 || x >= gridWidth || y < 0 || y >= gridHeight)
        {
            Debug.LogWarning($"⚠️ Celula ({x},{y}) este în afara limitelor grilei!");
            continue;
        }

        int actualState = GetState(cell);
        int expectedState = correctSolution[x, y];

        Debug.Log($"Cell ({x},{y}): actual = {actualState}, expected = {expectedState}");

        if (actualState != expectedState)
        {
            Debug.LogWarning($"❌ Celula de la ({x},{y}) are stare greșită! Așteptat: {expectedState}, Găsit: {actualState}");

            valid = false;
        }
    }

    if (valid)
       {
        Debug.Log("✅ Puzzle corect!");
        SceneManager.LoadScene("Scena6");
       } 
    else
        Debug.LogWarning("❌ Puzzle greșit.");
}


    int GetState(CellManual cell)
    {
        return typeof(CellManual)
            .GetField("state", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .GetValue(cell) is int value ? value : 0;
    }
}
