using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game current;

    public Level[] allLevels = null;
    protected Level curLevel = null;

    private int activeLevel;

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
        //TO DO EventManager.current.hud
    }

    public void deconstructLevel(int levelNum)
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
