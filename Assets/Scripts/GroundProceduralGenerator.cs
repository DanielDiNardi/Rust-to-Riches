using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GroundProceduralGenerator
{
    public static HashSet<Vector3Int> SimpleRandomWalk(Vector3Int startPosition, int walkLength)
    {
        HashSet<Vector3Int> path = new HashSet<Vector3Int>();

        path.Add(startPosition);
        var previousPosition = startPosition;

        for (int i = 0; i < walkLength; i++)
        {
            var newPosition = previousPosition + Direction3D.GetRandomCardinalDirection();
            path.Add(newPosition);
            previousPosition = newPosition;
        }
        return path;
    }
}

public static class Direction3D
{
    public static List<Vector3Int> cardinalDirectionsList = new List<Vector3Int>
    {
        new Vector3Int(0, 0, 1), //FORWARD
        new Vector3Int(1, 0, 0), //RIGHT
        new Vector3Int(0, 0, -1), //BACK
        new Vector3Int(-1, 0, 0) //LEFT
    };

    public static Vector3Int GetRandomCardinalDirection()
    {
        return cardinalDirectionsList[Random.Range(0, cardinalDirectionsList.Count)];
    }
}