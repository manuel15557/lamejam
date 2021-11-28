using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile{
    public TileType TileType = TileType.None;

    public int x;
    public int y;
    string specialInfo;

    public GameObject tile = null;

    public Tile(int xPos, int yPos, string sInfo)
    {
        x = xPos;
        y = yPos;
        this.specialInfo = sInfo;
    }

    public void Spawn(){
        float newX = x * 1 * def.HexagonWidth;
        float newY = y * (1.5f/ Mathf.Sqrt(3)) * def.HexagonWidth;

        if(y % 2 == 0)
        {
            newX = (x * 1 * def.HexagonWidth) + (def.HexagonWidth / 2);
        }

        tile = GameObject.Instantiate(GetTilePrefab());
        tile.AddComponent<TileClicker>();
        TileClicker tileClicker = tile.GetComponent<TileClicker>();
        tileClicker.setCoords(x, y);
        tile.transform.position = new Vector3(newX, 0, newY);
    }

    public TileType GetTileType()
    {
        return TileType;
    }

    public virtual void highlightTile()
    {
        // this class might need to be abstract
    }

    public abstract GameObject GetTilePrefab();
}
