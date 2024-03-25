using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSelector : MonoBehaviour
{
    private Color originalColor;
    private Renderer tileRenderer;
    private bool hasImprovement = false;
    private Tilemap tilemap;
    [SerializeField]
    private Dictionary<PlayerControls.Improvements, TileBase> tiles;
    [SerializeField]
    private GameObject playerControlsGameObject;
    private PlayerControls playerControls;
    public Color highlightColor = Color.red;
    public static TileSelector SelectedTile { get; private set; }
    public GameObject improvement;

    private void PlaceImprovement()
    {
        SelectedTile.hasImprovement = true;
        //Debug.Log("Placing improvement");
        Vector3 positionToPlace = SelectedTile.transform.position;

        Debug.Log(positionToPlace);

        var tilePosition = tilemap.WorldToCell(positionToPlace);

        Debug.Log(tilePosition);

        var tile = tiles[playerControls.selectedImprovementType];
        tilemap.SetTile(tilePosition, tile);
        tilemap.GetInstantiatedObject(tilePosition).GetComponent<Collector>().PopulateCollectorInfo(tilePosition);
    }

    private void HandleMouseClick()
    {
        if (Input.GetMouseButton(0) && SelectedTile != null && SelectedTile.hasImprovement == false)
        {
            SelectedTile.PlaceImprovement();
        }
    }

    private void LoadTiles()
    {
        var sphereTile = AssetDatabase.LoadAssetAtPath<TileBase>("Assets/Tiles/Improvements/Sphere.asset");
        var cubeTile = AssetDatabase.LoadAssetAtPath<TileBase>("Assets/Tiles/Improvements/Cube.asset");

        if (sphereTile == null || cubeTile == null)
        {
            Debug.LogError("Tile not found");
        }

        tiles = new Dictionary<PlayerControls.Improvements, TileBase>
        {
            { PlayerControls.Improvements.Sphere, sphereTile },
            { PlayerControls.Improvements.Cube, cubeTile }
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject tilemapGameObject = GameObject.Find("Surface");

        if (!tilemapGameObject.TryGetComponent(out tilemap))
        {
            Debug.LogError("Tilemap not found");
        }

        tileRenderer = GetComponent<Renderer>();
        originalColor = tileRenderer.material.color;

        LoadTiles();

        playerControlsGameObject = GameObject.Find("PlayerControls");

        if (!playerControlsGameObject.TryGetComponent(out playerControls))
        {
            Debug.LogError("PlayerControls not found");
        }
    }

    void OnMouseEnter()
    {
        tileRenderer.material.color = highlightColor;
        SelectedTile = this;
    }

    void OnMouseExit()
    {
        tileRenderer.material.color = originalColor;
    }

    void Update()
    {
        HandleMouseClick();
    }
}
