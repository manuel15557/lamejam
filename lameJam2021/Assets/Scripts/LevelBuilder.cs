using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    private Level level = null;
    private Tile[][] tiles = null;

    public void SetLevel(Level level)
    {
        this.level = level;
    }

    public void buildLevel()
    {
        if(level == null) { return; }

        int MapWidth = 0;
        int MapLength = 0;

        //find out how big our tile array needs to be.
        for(int i = 0; i < level.tiles.Length; i++){
            if(level.tiles[i].x + 1 > MapWidth){
                MapWidth = level.tiles[i].x + 1;
            }
            if(level.tiles[i].y + 1 > MapLength)
            {
                MapLength = level.tiles[i].y + 1;
            }
        }

        //construct the array.
        tiles = new Tile[MapWidth][];
        for(int i = 0; i < MapWidth; i++){
            tiles[i] = new Tile[MapLength];
        }

        Debug.Log("MapWidth:" + MapWidth + " MapLengh:" + MapLength);

        //spawn tiles
        for(int i = 0; i < level.tiles.Length; i++){
            if(level.tiles[i].type == TileType.NormalTile){
                Debug.Log("curr x:" + level.tiles[i].x + " curr y:" + level.tiles[i].y);
                tiles[level.tiles[i].x][level.tiles[i].y]
                    = new NormalTile(level.tiles[i].x, level.tiles[i].y);
            }

            tiles[level.tiles[i].x][level.tiles[i].y].Spawn();
        }
    }

    public void hello()
    {

    }

    public void destoyLevel()
    {
        if(level == null) { return; }

        //TO DO
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
