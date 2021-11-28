using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game current;

    public Level[] curLevel = null;

    private void Awake()
    {
        current = this;
    }
    private void Start()
    {
        //Level curLevel = (new GameObject()).AddComponent<Level>();
        curLevel[0] = GameObject.Instantiate(curLevel[0]);
        //curLevel = levelObject.GetComponent<Level>();
        print("curLevel is instantiated " + curLevel);
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
        print(curLevel);
        return curLevel[0].GetTiles()[x][y];
    }
}
