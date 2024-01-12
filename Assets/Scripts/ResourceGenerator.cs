using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ResourceRandomWalkIterator : MonoBehaviour
{
    [SerializeField]
    private List<string> resources = new List<string>
    {
        "Sphere",
        "Capsule",
        "Cylinder"
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
    private ResourceTilemapVisualizer tilemapVisualizer;

    [SerializeField]
    private HashSet<Vector3Int> resourcePositions = new HashSet<Vector3Int>();

    public void RunProceduralGeneration()
    {
        foreach (var resource in resources)
        {
            HashSet<Vector3Int> resourcePositions = RunRandomWalk();
            tilemapVisualizer.PaintResourceTiles(resourcePositions, resource);
        }
    }

    protected HashSet<Vector3Int> RunRandomWalk()
    {
        var floorPositions = GroundRandomWalkIterator.floorPositions;
        startPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
        var currentPosition = startPosition;
        HashSet<Vector3Int> resourcePositions = new HashSet<Vector3Int>();
        for (int i = 0; i < iterations; i++)
        {
            var path = ResourceRandomWalk(
                currentPosition,
                walkLength,
                floorPositions
            );
            resourcePositions.UnionWith(path);
            
            if (startRandomlyEachIteration && path.Count != 0)
            {
                currentPosition = resourcePositions.ElementAt(Random.Range(0, resourcePositions.Count));
            }
            else
            {
                break;
            }
        }
        return resourcePositions;
    }

    public static HashSet<Vector3Int> ResourceRandomWalk(
        Vector3Int startPosition,
        int walkLength,
        HashSet<Vector3Int> floorPositions
    )
    {
        HashSet<Vector3Int> path = new HashSet<Vector3Int>();


        if (!ResourcePositionManager.IsPositionInList(startPosition))
        {
            path.Add(startPosition);
            ResourcePositionManager.AddPosition(startPosition);
        }
        else
        {
            return new HashSet<Vector3Int>();
        }

        var previousPosition = startPosition;

        for (int i = 0; i < walkLength; i++)
        {
            var newPosition = previousPosition + Direction3D.GetRandomCardinalDirection();
            if (floorPositions.Contains(newPosition) && !path.Contains(newPosition) && !ResourcePositionManager.IsPositionInList(newPosition))
            {
                path.Add(newPosition);
                ResourcePositionManager.AddPosition(newPosition);
                previousPosition = newPosition;
            }

        }
        return path;
    }
}
