using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ModifiedRandomWalkResourceGenerator : MonoBehaviour
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
    private TilemapVisualizer tilemapVisualizer;

    [SerializeField]
    private HashSet<Vector3Int> resourcePositions = new HashSet<Vector3Int>();

    public void RunProceduralGeneration()
    {
        HashSet<Vector3Int> resourcePositions = RunRandomWalk();
        tilemapVisualizer.PaintFloorTiles(resourcePositions);
    }

    protected HashSet<Vector3Int> RunRandomWalk()
    {
        var floorPositions = SimpleRandomWalkGroundGenerator.floorPositions;
        startPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
        var currentPosition = startPosition;
        HashSet<Vector3Int> resourcePositions = new HashSet<Vector3Int>();
        for (int i = 0; i < iterations; i++)
        {
            var path = ResourceProceduralGenerator.FloorRandomWalk(
                currentPosition,
                walkLength,
                SimpleRandomWalkGroundGenerator.floorPositions
            );
            resourcePositions.UnionWith(path);
            
            if (startRandomlyEachIteration)
            {
                currentPosition = resourcePositions.ElementAt(Random.Range(0, resourcePositions.Count));
            }
        }
        return resourcePositions;
    }
}
