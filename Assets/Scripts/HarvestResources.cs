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

    public List<GameObject> GetTileNeighbours(Vector3Int position)
    {
        List<GameObject> tileNeighbours = new List<GameObject>();

        Vector3Int gridPosition = tilemap.WorldToCell(new Vector3(position.x, position.y, position.z));

        foreach (var neighbourPosition in neighbourPositions)
        {
            Vector3Int currentNeighbourPosition = neighbourPosition + new Vector3Int(gridPosition.x, gridPosition.z, gridPosition.y);

            var neighbour = tilemap.GetInstantiatedObject(currentNeighbourPosition);
            Debug.Log(neighbour);
            if(neighbour != null)
            {
                tileNeighbours.Add(neighbour);
            }
        }

        return tileNeighbours;
    }

    void Start()
    {
        tilemap = GameObject.Find("Surface").GetComponent<Tilemap>();
        foreach(var neighbour in GetTileNeighbours(gameObject.GetComponent<Collector>().GetPosition()))
        {
            Debug.Log(neighbour);
        }
    }

    void Update()
    {
        
    }
}
