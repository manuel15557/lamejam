using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileClicker : MonoBehaviour
{
    private int xPos;
    private int yPos;


    public void setCoords(int x, int y)
    {
        xPos = x;
        yPos = y;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        print("tile clicked");
        //print(EventManager.current);
        EventManager.current.selectTileHandler(xPos, yPos);
    }
}
