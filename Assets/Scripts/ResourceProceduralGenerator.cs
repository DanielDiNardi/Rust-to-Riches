using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceProceduralGenerator
{
    public static HashSet<Vector3Int> FloorRandomWalk(
        Vector3Int startPosition,
        int walkLength,
        HashSet<Vector3Int> floorPositions
    )
    {
        HashSet<Vector3Int> path = new HashSet<Vector3Int>();

        path.Add(startPosition);
        var previousPosition = startPosition;

        for (int i = 0; i < walkLength; i++)
        {
            var newPosition = previousPosition + Direction3D.GetRandomCardinalDirection();
            if (floorPositions.Contains(newPosition) && !(path.Contains(newPosition)))
            {
                path.Add(newPosition);
                previousPosition = newPosition;
            }
            
        }
        return path;
    }
}