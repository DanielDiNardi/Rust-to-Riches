using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Tilemaps;

public class StructureGenerator : MonoBehaviour
{
    [SerializeField]
    private List<string> types = new List<string>
    {
        "Cube"
    };

    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    private TilemapVisualizer tilemapVisualizer;

    [SerializeField]
    private HashSet<Vector3Int> resourcePositions = new HashSet<Vector3Int>();

    [SerializeField]
    protected Vector3Int startPosition = Vector3Int.zero;

    public int walkLength = 1;

    public bool startRandomlyEachIteration = true;

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

            HashSet<Vector3Int> structurePositions = new HashSet<Vector3Int> { startPosition };

            return structurePositions;
        }

        return new HashSet<Vector3Int>();
    }
}
