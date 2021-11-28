using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public static Game current;

    public Level[] allLevels = null;
    protected Level curLevel = null;

    private int activeLevel;


    private Tile[][] tiles = null;
    private Enemy[] enemies = null;
    private Player[] players = null;

    private void Awake(){
        current = this;
    }
    private void Start(){
        EventManager.current.startLevelEvent += loadLevel;
        EventManager.current.deconstructLevelEvent += deconstructLevel;
    }

    public void loadLevel(int levelNum){
        activeLevel = levelNum;
        curLevel = GameObject.Instantiate(allLevels[activeLevel])
            .GetComponent<Level>();

        tiles = curLevel.GetTiles();
        enemies = curLevel.GetEnemies();
        players = curLevel.GetPlayers();

        if(players == null)
        {
            print("ERROR: there is no player in the level save file.");
        }

        updateHUD();
    }

    public void updateHUD()
    {
        //EventManager.current.hud.transform
        //    .GetChild(0).GetChild(0)
        //    .GetComponent<TextMeshProUGUI>().text =

        //    GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>().ammo + " Grenades";
        //EventManager.current.hud.transform
        //    .GetChild(0).GetChild(1)
        //    .GetComponent<TextMeshProUGUI>().text =
        //    GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>().energy + " Points";
        //EventManager.current.hud.transform
        //    .GetChild(0).GetChild(2)
        //    .GetComponent<TextMeshProUGUI>().text = "5 HP"; //hard coded for now
    }

    public void deconstructLevel()
    {
        if(curLevel == null) { return; }
        Destroy(curLevel);
        curLevel = null;
    }

    // Update is called once per frame
    void Update(){
        if(curLevel == null) { return; }
    }

    public int checkTile(int x, int y)
    {
        return 0;
        //return an int representing the tile at position x,y
    }

    public Tile getTile(int x, int y)
    {
        //return the tile at position x,y
        if ((curLevel.GetTiles().Length > x) & (curLevel.GetTiles()[0].Length > y))
        {
            if ((x >= 0) & (y >= 0))
            {
                return curLevel.GetTiles()[x][y];
            }
        }
        return null;
    }

    public void highlightTile(int x, int y)
    {
        //print(curLevel.GetTiles()[1][14]);
        if ((curLevel.GetTiles().Length > x) & (curLevel.GetTiles()[0].Length > y))
        {
            if ((x >= 0) & (y >= 0))
            {
                if (curLevel.GetTiles()[x][y] != null)
                {
                    curLevel.GetTiles()[x][y].highlightTile();
                }
            }
        }
    }

    public void unhighlightTile(int x, int y)
    {
        //print(curLevel.GetTiles()[1][14]);
        if ((curLevel.GetTiles().Length > x) & (curLevel.GetTiles()[0].Length > y))
        {
            if ((x >= 0) & (y >= 0))
            {
                if (curLevel.GetTiles()[x][y] != null)
                {
                    curLevel.GetTiles()[x][y].unhighlightTile();
                }
            }
        }
    }

    public void paintTile(int x, int y)
    {
        //print(curLevel.GetTiles()[1][14]);
        if ((curLevel.GetTiles().Length > x) & (curLevel.GetTiles()[0].Length > y))
        {
            if ((x >= 0) & (y >= 0))
            {
                if (curLevel.GetTiles()[x][y] != null)
                {
                    curLevel.GetTiles()[x][y].paintTile();
                }
            }
        }
    }
}
