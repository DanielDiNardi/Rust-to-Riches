using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Tilemaps;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField]
    private List<string> types = new List<string>
    {
        "Cube"
    };

    [SerializeField]
    protected Vector3Int startPosition = Vector3Int.zero;

    [SerializeField]
    private int iterations = 10;
    [SerializeField]
    public int walkLength = 10;
    [SerializeField]
    public bool startRandomlyEachIteration = true;

    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    private TilemapVisualizer tilemapVisualizer;

    public static HashSet<Vector3Int> groundPositions = new HashSet<Vector3Int>();

    public void RunProceduralGeneration()
    {
        foreach (var type in types)
        {
            groundPositions = RunRandomWalk();
            tilemapVisualizer.PaintTileType(tilemap, groundPositions, type);
        }
            
    }

    protected HashSet<Vector3Int> RunRandomWalk()
    {
        var currentPosition = startPosition;
        HashSet<Vector3Int> groundPositions = new HashSet<Vector3Int>();
        for (int i = 0; i < iterations; i++)
        {
            var path = GroundRandomWalk(currentPosition, walkLength);
            groundPositions.UnionWith(path);
            if (startRandomlyEachIteration)
            {
                currentPosition = groundPositions.ElementAt(Random.Range(0, groundPositions.Count));
            }
        }
        return groundPositions;
    }

    public static HashSet<Vector3Int> GroundRandomWalk(Vector3Int startPosition, int walkLength)
    {
        HashSet<Vector3Int> path = new HashSet<Vector3Int>();

        path.Add(startPosition);
        GroundPositionManager.AddPosition(startPosition);
        var previousPosition = startPosition;

        for (int i = 0; i < walkLength; i++)
        {
            var newPosition = previousPosition + Direction3D.GetRandomCardinalDirection();
            if (!GroundPositionManager.IsPositionInList(newPosition))
            {
                path.Add(newPosition);
                GroundPositionManager.AddPosition(newPosition);
                previousPosition = newPosition;
            }
        }
        return path;
    }
}
