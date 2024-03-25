using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HarvestResources : MonoBehaviour
{
    private readonly Vector3Int[] neighbourPositions =
    {
        Vector3Int.forward,
        Vector3Int.back,
        Vector3Int.right,
        Vector3Int.left,
        Vector3Int.forward + Vector3Int.right,
        Vector3Int.forward + Vector3Int.left,
        Vector3Int.back + Vector3Int.right,
        Vector3Int.back + Vector3Int.left
    };

    public Tilemap tilemap;

    public List<TileBase> GetTileNeighbours(Vector3Int position)
    {
        List<TileBase> tileNeighbours = new List<TileBase>();

        Vector3Int gridPosition = tilemap.WorldToCell(position);

        foreach (var neighbourPosition in neighbourPositions)
        {
            Vector3Int currentNeighbourPosition = gridPosition + neighbourPosition;

            Debug.Log(currentNeighbourPosition);
            Debug.Log(tilemap.HasTile(currentNeighbourPosition));

            if (tilemap.HasTile(currentNeighbourPosition))
            {
                var neighbour = tilemap.GetTile(currentNeighbourPosition);
                tileNeighbours.Add(neighbour);
                Debug.Log("Neighbour: " +  neighbour);
            }
        }

        return tileNeighbours;
    }

    void Start()
    {
        tilemap = GameObject.Find("Surface").GetComponent<Tilemap>();
        GetTileNeighbours(gameObject.GetComponent<Collector>().GetPosition());
    }

    void Update()
    {
        
    }
}
