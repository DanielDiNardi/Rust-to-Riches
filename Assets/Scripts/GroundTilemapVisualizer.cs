using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundTilemapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap;

    [SerializeField]
    private TileBase floorTile;

    public void PaintFloorTiles(IEnumerable<Vector3Int> floorPosition)
    {
        PaintTiles(floorPosition, floorTilemap, floorTile);
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
