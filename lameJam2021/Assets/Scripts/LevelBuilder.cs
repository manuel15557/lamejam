using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    private Level level = null;

    private Tile[][] tiles = null;
    private Enemy[] enemies = null;
    private Player[] players = null;

    public void SetLevel(Level level){
        this.level = level;
    }

    public void buildLevel()
    {
        if(level == null) { return; }

        //move the camera.
        Camera cam = Camera.main;
        cam.transform.position = level.cameraInfo.location;
        cam.transform.rotation = Quaternion.Euler(
                        level.cameraInfo.rotation.x,
                        level.cameraInfo.rotation.y,
                        level.cameraInfo.rotation.z);

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

        //construct the tile array.
        tiles = new Tile[MapWidth][];
        for(int i = 0; i < MapWidth; i++){
            tiles[i] = new Tile[MapLength];
        }

        //Debug.Log("MapWidth:" + MapWidth + " MapLengh:" + MapLength);

        //create tile parent
        GameObject tileParent = new GameObject();
        tileParent.name = "Tiles";
        tileParent.transform.parent = this.transform.parent;

        //spawn tiles
        for(int i = 0; i < level.tiles.Length; i++){
            if(level.tiles[i].type == TileType.NormalTile){
                //Debug.Log("curr x:" + level.tiles[i].x + " curr y:" + level.tiles[i].y);
                tiles[level.tiles[i].x][level.tiles[i].y]
                    = new NormalTile(
                        level.tiles[i].x, level.tiles[i].y,
                        level.tiles[i].specialInfo
                                    );
            } else if(level.tiles[i].type == TileType.None){
                continue;
            }

            
            tiles[level.tiles[i].x][level.tiles[i].y].Spawn();
            tiles[level.tiles[i].x][level.tiles[i].y].tile.transform.parent
                = tileParent.transform;
        }

        //create the mob array.
        enemies = new Enemy[level.enemies.Length];

        //create empty parent for the mobs.
        GameObject enemyParent = new GameObject();
        enemyParent.name = "Enemies";
        enemyParent.transform.parent = this.transform.parent;

        //spawn mobs
        for (int i = 0; i < level.enemies.Length; i++){
            if(level.enemies[i].type == EnemyType.Exploder){
                enemies[i] = new Exploder(
                    level.enemies[i].x,
                    level.enemies[i].y,
                    level.enemies[i].facingDirection
                    );
            }else if(level.enemies[i].type == EnemyType.None){
                continue;
            }

            enemies[i].Spawn();
            enemies[i].enemyObject.transform.parent =
                enemyParent.transform;
        }

        //create the player array
        players = new Player[level.allies.Length];

        //spawn allies
        for (int i = 0; i < level.allies.Length; i++)
        {
            GameObject ally = GameObject.Instantiate(Resources.Load("Prefabs/mainCharacter")) as GameObject;
            ally.GetComponent<Player>().setPosition(level.allies[i].x, level.allies[i].y);
            players[i] = ally.GetComponent<Player>();
        }
    }

    public Tile[][] GetTiles(){
        return tiles;
    }

    public Enemy[] GetEnemies(){
        return enemies;
    }

    public Player[] GetPlayers(){
        return players;
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