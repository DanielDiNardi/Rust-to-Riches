using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourcePositionManager
{
    private static HashSet<Vector3Int> resourcePositions = new HashSet<Vector3Int>();

    public static void AddPosition(Vector3Int position)
    {
        resourcePositions.Add(position);
    }

    public static bool IsPositionInList(Vector3Int position)
    {
        return resourcePositions.Contains(position);
    }
}
