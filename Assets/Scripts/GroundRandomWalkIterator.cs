using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GroundRandomWalkIterator : MonoBehaviour
{
    [SerializeField]
    protected Vector3Int startPosition = Vector3Int.zero;

    [SerializeField]
    private int iterations = 10;
    [SerializeField]
    public int walkLength = 10;
    [SerializeField]
    public bool startRandomlyEachIteration = true;

    [SerializeField]
    private GroundTilemapVisualizer tilemapVisualizer;

    public static HashSet<Vector3Int> floorPositions = new HashSet<Vector3Int>();

    public void RunProceduralGeneration()
    {
        floorPositions = RunRandomWalk();
        tilemapVisualizer.PaintFloorTiles(floorPositions);
    }

    protected HashSet<Vector3Int> RunRandomWalk()
    {
        var currentPosition = startPosition;
        HashSet<Vector3Int> floorPositions = new HashSet<Vector3Int>();
        for (int i = 0; i < iterations; i++)
        {
            var path = GroundProceduralGenerator.SimpleRandomWalk(currentPosition, walkLength);
            floorPositions.UnionWith(path);
            if (startRandomlyEachIteration)
            {
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
            }
        }
        return floorPositions;
    }
}
