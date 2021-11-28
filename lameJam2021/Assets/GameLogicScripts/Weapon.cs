using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public abstract bool checkFire(int x, int y);
    public abstract void setPossibleShots(int curX, int curY);
    public abstract void highlightPossibleShots();
    public abstract void unhighlighPossibleShots();

    public GameObject game;

    //public Tile[][] map;

    // Start is called before the first frame update
    void Start()
    {
        print("here");
        //map = game.getMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
