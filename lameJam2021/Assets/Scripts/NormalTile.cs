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

    private bool isHighlighted = false;

    public NormalTile(int xPos, int yPos, string specialInfo)
        : base(xPos, yPos, specialInfo)
{
        TileType = TileType.NormalTile;

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

    public override void highlightTile()
    {
        isHighlighted = true;
        tile.GetComponent<MeshRenderer>().material = Resources.Load("Materials/HighlightedHex") as Material;
    }

    public override void unhighlightTile()
    {
        isHighlighted = true;
        if (colour == TileColours.Blue)
        {
            tile.GetComponent<MeshRenderer>().material = Resources.Load("Materials/BlueHex") as Material;
        }
        else if (colour == TileColours.Yellow)
        {
            tile.GetComponent<MeshRenderer>().material = Resources.Load("Materials/YellowHex") as Material;
        }
        else if (colour == TileColours.None)
        {
            tile.GetComponent<MeshRenderer>().material = Resources.Load("Materials/BlankHex") as Material;
        }
    }

    public override void paintTile()
    {
        tile.GetComponent<MeshRenderer>().material = Resources.Load("Materials/BlueHex") as Material;
        colour = TileColours.Blue;
    }

    public Enemy getEnemy()
    {
        return Enemy;
    }
}
