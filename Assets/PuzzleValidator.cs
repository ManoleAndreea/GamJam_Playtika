using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PuzzleValidator : MonoBehaviour
{
    public Transform gridRoot;

    public void ValidatePuzzle()
    {
        var allCells = gridRoot.GetComponentsInChildren<CellManual>().ToList();

        // 1. Verificăm dacă există celule neatinse
        if (allCells.Any(cell => !cell.IsActive))
        {
            Debug.LogWarning("❌ Nu ai tras firul prin toate pătrățelele!");
            return;
        }

        // 2. Găsim celulele cu checkpoint-uri
        var checkpoints = allCells
            .Where(cell => cell.checkpointNumber > 0)
            .OrderBy(cell => cell.checkpointNumber)
            .ToList();

        // 3. Verificăm dacă checkpoint-urile există și sunt în ordine
        for (int i = 1; i <= 6; i++)
        {
            if (!checkpoints.Any(c => c.checkpointNumber == i))
            {
                Debug.LogWarning($"❌ Lipsește checkpoint-ul {i}");
                return;
            }
        }

        Debug.Log("✅ Puzzle complet și valid!");
    }
}
