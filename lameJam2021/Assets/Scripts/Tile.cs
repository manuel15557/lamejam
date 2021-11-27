using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile
{
    public static float HexagonWidth = 1.75f;

    public int x;
    public int y;

    public GameObject tile = null;

    public void Spawn(){
        float newX = x * 1 * HexagonWidth;
        float newY = y * (1.5f/ Mathf.Sqrt(3)) * HexagonWidth;

        if(y % 2 == 0)
        {
            newX = (x * 1 * HexagonWidth) + (HexagonWidth/2);
        }

        tile = GameObject.Instantiate(GetTilePrefab());
        tile.transform.position = new Vector3(newX, 0, newY);
    }

    public abstract GameObject GetTilePrefab();

    //ignore.
    void Start(){}
    void Update(){}
    //ignore.
}
