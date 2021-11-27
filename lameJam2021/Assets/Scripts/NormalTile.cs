using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileColours
{
    Blue,
    Yellow
}

public class NormalTile : Tile
{
    TileColours colour;
    //monster
    //ally

    public NormalTile(int xPos, int yPos)
    {
        x = xPos;
        y = yPos;
    }

    public override GameObject GetTilePrefab()
    {
        return Resources.Load("Prefabs/Hexagon") as GameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
