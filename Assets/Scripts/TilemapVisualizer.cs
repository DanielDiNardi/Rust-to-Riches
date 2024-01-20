using System.Collections;
using System.Collections.Generic;
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
                PaintTiles(position, tilemap, tile);
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
