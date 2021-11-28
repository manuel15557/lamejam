using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile
{
    public static float HexagonWidth = 1.75f;
    public TileType TileType = TileType.None;

    public int x;
    public int y;

    public GameObject tile = null;

    public void Spawn(){
        float newX = x * 1 * HexagonWidth;
        float newY = y * (1.5f/ Mathf.Sqrt(3)) * HexagonWidth;

        if(y % 2 == 0)
        {
            newX = (x * 1 * HexagonWidth) - (HexagonWidth/2);
        }

        tile = GameObject.Instantiate(GetTilePrefab());
        tile.AddComponent<TileClicker>();
        TileClicker tileClicker = tile.GetComponent<TileClicker>();
        tileClicker.setCoords(x, y);
        tile.transform.position = new Vector3(newY, 0, newX);
    }

    public TileType GetTileType()
    {
        return TileType;
    }

    public abstract GameObject GetTilePrefab();

    //ignore.
    void Start(){}
    void Update(){}
    //ignore.
}
