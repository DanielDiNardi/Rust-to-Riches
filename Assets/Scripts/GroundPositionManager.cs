using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GroundPositionManager
{
    private static HashSet<Vector3Int> groundPositions = new HashSet<Vector3Int>();

    public static void AddPosition(Vector3Int position)
    {
        groundPositions.Add(position);
    }

    public static bool IsPositionInList(Vector3Int position)
    {
        return groundPositions.Contains(position);
    }

    public static HashSet<Vector3Int> GetGroundPositions()
    {
        return groundPositions;
    }
}
