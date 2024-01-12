using System.Collections.Generic;
using UnityEngine;

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