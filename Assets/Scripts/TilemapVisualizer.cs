using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{

    [SerializeField]
    private List<TileBase> resourceTiles;

    public void PaintTileType(Tilemap tilemap, IEnumerable<Vector3Int> position, string type)
    {
        foreach (var tile in resourceTiles)
        {
            if (tile.name == type)
            {
                PaintTiles(position, tilemap, tile, type);
            }
        }
        
    }

    private void PaintTiles(IEnumerable<Vector3Int> positions, Tilemap tilemap, TileBase tile, string type)
    {
        foreach (var position in positions)
        {
            PaintSingleTile(tilemap, tile, position, type);
        }
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector3Int position, string type)
    {
        var tilePosition = tilemap.WorldToCell(position);
        tilemap.SetTile(tilePosition, tile);
        GameObject obj = tilemap.GetInstantiatedObject(tilePosition);
        if (obj.GetComponent<Resource>() != null)
        {
            obj.GetComponent<Resource>().PopulateResourceInfo(type, position, "clu-" + IdManager.GetClusterID());
            Debug.Log(
                "\n" + 
                "ID: " + obj.GetComponent<Resource>().GetId() + 
                "\n" + 
                "TYPE: " + obj.GetComponent<Resource>().GetType() +
                "\n" +
                "OUTPUT: " + obj.GetComponent<Resource>().GetOutput() +
                "\n" +
                "POSITION: " + obj.GetComponent<Resource>().GetPosition() +
                "\n" +
                "CLUSTERID: " + obj.GetComponent<Resource>().GetClusterId()
            );
        }
    }
}
