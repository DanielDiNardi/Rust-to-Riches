using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Tilemaps;
using Unity.VisualScripting;

public class ResourceGenerator : MonoBehaviour
{
    [SerializeField]
    private List<string> types = new List<string>
    {
        "Copper",
        "Iron",
        "Stone",
        "Tree"
    };
<<<<<<< HEAD

    [SerializeField]
    protected Vector3Int startPosition = Vector3Int.zero;

    [SerializeField]
    private int walkLength = 5;
    [SerializeField]
    public bool startRandomlyEachIteration = true;

=======
>>>>>>> 42fba7811bb2322ef0a7a9d2b5337f57da1ef178
    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    private TilemapVisualizer tilemapVisualizer;
    [SerializeField]
    private HashSet<Vector3Int> resourcePositions = new HashSet<Vector3Int>();
    [SerializeField]
    private int iterations = 10;
    [SerializeField]
    protected Vector3Int startPosition = Vector3Int.zero;
    public int walkLength = 10;
    public bool startRandomlyEachIteration = true;
    public HashSet<Vector3Int> ResourcePositions { get => resourcePositions; }

    public void RunProceduralGeneration()
    {
        foreach (var type in types)
        {
            int numOfClusterTypes = Random.Range(2, 7);

            for (int i = 0; i < numOfClusterTypes; i++)
            {
                resourcePositions = RunRandomWalk();
                if (resourcePositions.Count > 0)
                {
                    tilemapVisualizer.PaintTileType(tilemap, resourcePositions, type);
                }
                else
                {
                    Debug.Log("No more available positions");

                
                }
            }
            
        }
    }

    protected HashSet<Vector3Int> RunRandomWalk()
    {
        var availableSurfacePositions = AvailablePositionsManager.GetAvailablePositions();

        if (availableSurfacePositions.Count <= 0) return new HashSet<Vector3Int>();

        startPosition = availableSurfacePositions.ElementAt(Random.Range(0, availableSurfacePositions.Count));
        var currentPosition = startPosition;

        HashSet<Vector3Int> resourcePositions = new HashSet<Vector3Int>();

        for (int i = 0; i < iterations; i++)
        {
            var path = ResourceRandomWalk(
                currentPosition,
                walkLength,
                availableSurfacePositions
            );

            resourcePositions.UnionWith(path);

<<<<<<< HEAD
                var path = ResourceRandomWalk(
                    currentPosition,
                    walkLength
                );
                resourcePositions.UnionWith(path);

                if (startRandomlyEachIteration && path.Count != 0)
                {
                    currentPosition = resourcePositions.ElementAt(Random.Range(0, resourcePositions.Count));
                }

            return resourcePositions;
        }
        else
        {
            return new HashSet<Vector3Int>();
=======
            if (startRandomlyEachIteration && path.Count == 0) break;

            currentPosition = resourcePositions.ElementAt(Random.Range(0, resourcePositions.Count));
>>>>>>> 42fba7811bb2322ef0a7a9d2b5337f57da1ef178
        }
        return resourcePositions;
    }

    public static HashSet<Vector3Int> ResourceRandomWalk(
        Vector3Int startPosition,
        int walkLength
    )
    {
        HashSet<Vector3Int> path = new HashSet<Vector3Int>();
        path.Add(startPosition);

        SurfacePositionManager.AddPosition(startPosition);
        var previousPosition = startPosition;

        GameObject obj = new GameObject();
        obj.transform.parent = GameObject.Find("Surface").transform;
        obj.AddComponent<Cluster>();
        obj.GetComponent<Cluster>().PopulateClusterInfo();

        for (int i = 0; i < walkLength; i++)
        {
            var newPosition = previousPosition + Direction3D.GetRandomCardinalDirection();

            if (!path.Contains(newPosition) && AvailablePositionsManager.GetAvailablePositions().Contains(newPosition))
            {
                path.Add(newPosition);
                SurfacePositionManager.AddPosition(newPosition);
                previousPosition = newPosition;
            }

        }
        return path;
    }
}
