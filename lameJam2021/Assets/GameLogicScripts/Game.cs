using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game current;

    public Level[] allLevels = null;
    public Level curLevel = null;

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
        curLevel = GameObject.Instantiate(allLevels[activeLevel]);
    }

    public void deconstructLevel(int levelNum)
    {
        curLevel.deconstructLevel();
        Destroy(curLevel); //dangerous!
        curLevel = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int checkTile(int x, int y)
    {
        return 0;
        //return an int representing the tile at position x,y
    }

    public Tile getTile(int x, int y)
    {
        //return the tile at position x,y
        return curLevel.GetTiles()[x][y];
    }

    public void highlightTile(int x, int y)
    {
        //print(curLevel[activeLevel].GetTiles()[1][14]);
        if ((curLevel.GetTiles().Length > x) & (curLevel.GetTiles()[0].Length > y))
        {
            if (curLevel.GetTiles()[x][y] != null)
            {
                curLevel.GetTiles()[x][y].highlightTile();
            }
        }
    }
}
