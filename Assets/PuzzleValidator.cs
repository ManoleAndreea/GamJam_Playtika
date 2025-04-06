using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PuzzleValidator : MonoBehaviour
{
    public Transform gridRoot;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ValidatePuzzle();
        }
    }

    public void ValidatePuzzle()
    {
        var allCells = gridRoot.GetComponentsInChildren<CellManual>().ToList();

        // DEBUG: Vezi toate celulele și stările lor
        foreach (var cell in allCells)
        {
            Debug.Log($"[DEBUG] Cell: {cell.name}, Active: {cell.IsActive}, Checkpoint: {cell.checkpointNumber}");
        }

        // 1. Trebuie să fi tras firul prin toate pătrățelele
        if (allCells.Any(cell => !cell.IsActive))
        {
            Debug.LogWarning("❌ Nu ai tras firul prin toate pătrățelele!");
            return;
        }

        // 2. Găsim doar celulele ACTIVE care au checkpoint-uri
        var activeCheckpoints = allCells
            .Where(cell => cell.checkpointNumber > 0 && cell.IsActive)
            .OrderBy(cell => cell.checkpointNumber)
            .ToList();

        // 3. Verificăm dacă checkpoint-urile 1 → 6 au fost atinse efectiv
        for (int i = 1; i <= 6; i++)
        {
            if (!activeCheckpoints.Any(c => c.checkpointNumber == i))
            {
                Debug.LogWarning($"❌ Lipsește checkpoint-ul {i} sau nu are fir pe el!");
                return;
            }
        }

        Debug.Log("✅ Puzzle complet și valid!");
    }
}
