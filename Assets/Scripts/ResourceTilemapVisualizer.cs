using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ResourceTilemapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap resourceTilemap;

    [SerializeField]
    private List<TileBase> resourceTiles;

    public void PaintResourceTiles(IEnumerable<Vector3Int> resourcePosition, string resource)
    {
        foreach (var tile in resourceTiles)
        {
            if (tile.name == resource)
            {
                PaintTiles(resourcePosition, resourceTilemap, tile);
            }
        }
        
    }

    private void PaintTiles(IEnumerable<Vector3Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions)
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector3Int position)
    {
        var tilePosition = tilemap.WorldToCell(position);
        tilemap.SetTile(tilePosition, tile);
    }
}
