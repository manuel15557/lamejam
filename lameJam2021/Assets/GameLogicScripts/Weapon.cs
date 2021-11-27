using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public abstract void checkFire(int tx, int ty, int px, int py);

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
