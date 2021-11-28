using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game current;

    public Level[] curLevel = null;

    private int activeLevel;

    private void Awake()
    {
        current = this;
    }
    private void Start()
    {
        //FIX THIS IN ORDER TO ACCESS OTHER LEVELS

        //Level curLevel = (new GameObject()).AddComponent<Level>();
        curLevel[0] = GameObject.Instantiate(curLevel[0]);
        //curLevel = levelObject.GetComponent<Level>();
        print("curLevel is instantiated " + curLevel);

        activeLevel = 0;
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
        return curLevel[activeLevel].GetTiles()[x][y];
    }

    public void highlightTile(int x, int y)
    {
        //print(curLevel[activeLevel].GetTiles()[1][14]);
        if ((curLevel[activeLevel].GetTiles().Length > x) & (curLevel[activeLevel].GetTiles()[0].Length > y))
        {
            if (curLevel[activeLevel].GetTiles()[x][y] != null)
            {
                curLevel[activeLevel].GetTiles()[x][y].highlightTile();
            }
        }
    }
}
