using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Tilemaps;

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

    [SerializeField]
    protected Vector3Int startPosition = Vector3Int.zero;

    [SerializeField]
    private int iterations = 1;
    [SerializeField]
    public int walkLength = 1;
    [SerializeField]
    public bool startRandomlyEachIteration = true;

    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    private TilemapVisualizer tilemapVisualizer;
    [SerializeField]
    private HashSet<Vector3Int> resourcePositions = new HashSet<Vector3Int>();

    public void RunProceduralGeneration()
    {
        foreach (var type in types)
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

    protected HashSet<Vector3Int> RunRandomWalk()
    {
        var availableSurfacePositions = AvailablePositionsManager.GetAvailablePositions();

        if (availableSurfacePositions.Count > 0)
        {
            startPosition = availableSurfacePositions.ElementAt(Random.Range(0, availableSurfacePositions.Count));
            var currentPosition = startPosition;

            HashSet<Vector3Int> resourcePositions = new HashSet<Vector3Int>();

            for (int i = 0; i < iterations; i++)
            {
                var path = ResourceRandomWalk(
                    currentPosition,
                    walkLength
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
        else
        {
            return new HashSet<Vector3Int>();
        }
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
