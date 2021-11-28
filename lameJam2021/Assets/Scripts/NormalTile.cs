using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileColours
{
    Blue,
    Yellow,
    None
}

public class NormalTile : Tile
{
    TileColours colour;
    Enemy Enemy = null;
    Player Player = null;

    public NormalTile(int xPos, int yPos, string specialInfo)
{
        TileType = TileType.NormalTile;
        x = xPos;
        y = yPos;

        if (specialInfo.Equals("b")){
            colour = TileColours.Blue;
        }else if (specialInfo.Equals("y")){
            colour = TileColours.Yellow;
        }else{
            colour = TileColours.None;
        }
    }

    public void setEnemy(Enemy enemy){
        this.Enemy = enemy;
    }

    public void setPlayer(Player player){
        this.Player = player;
    }

    public override GameObject GetTilePrefab()
    {
        GameObject tilePrefab = Resources.Load("Prefabs/Hexagon") as GameObject;

        if(colour == TileColours.Blue){
            tilePrefab.GetComponent<MeshRenderer>().material =
                Resources.Load("Materials/BlueHex") as Material;
        }
        else if(colour == TileColours.Yellow){
            tilePrefab.GetComponent<MeshRenderer>().material =
                Resources.Load("Materials/YellowHex") as Material;
        }else if(colour == TileColours.None){
            tilePrefab.GetComponent<MeshRenderer>().material =
                Resources.Load("Materials/BlankHex") as Material;
        }

        tilePrefab.name = "Normal Tile (" + x + ", " + y + ")";

        return tilePrefab;
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
