using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AvailablePositionsManager
{
    private static HashSet<Vector3Int> availablePositions = new HashSet<Vector3Int>();

    public static HashSet<Vector3Int> GetAvailablePositions()
    {
        availablePositions = GroundPositionManager.GetGroundPositions();
        availablePositions.ExceptWith(SurfacePositionManager.GetSurfacePositions());

        return availablePositions;
    }
}
