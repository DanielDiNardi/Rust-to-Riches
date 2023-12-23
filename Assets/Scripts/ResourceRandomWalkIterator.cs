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
            var path = ResourceProceduralGenerator.GroundRandomWalk(
                currentPosition,
                walkLength,
                floorPositions
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
