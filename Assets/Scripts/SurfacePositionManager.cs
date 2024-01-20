using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SurfacePositionManager
{
    private static HashSet<Vector3Int> surfacePositions = new HashSet<Vector3Int>();

    public static void AddPosition(Vector3Int position)
    {
        surfacePositions.Add(position);
    }

    public static bool IsPositionInList(Vector3Int position)
    {
        return surfacePositions.Contains(position);
    }

    public static HashSet<Vector3Int> GetSurfacePositions()
    {
        return surfacePositions;
    }
}
