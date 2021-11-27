using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum curSelectedMove
{
    Nothing,
    Move,
    PaintGun,
    GrenadeLauncher
} //the currently selected action on the action bar.

public class Player : MonoBehaviour
{
    private int direction; //represents the direction the model needs to face 0-5 being the 6 possible directions
    curSelectedMove curSelectMove;

    private int xPos;
    private int yPos;

    public Weapon[] weapons;

    public GameObject playerObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void makeMove(int x, int y)
    {
        if (curSelectMove == curSelectedMove.Move)
        {
            moveCharacter(x, y);
        }
        else if(curSelectMove == curSelectedMove.GrenadeLauncher)
        {
            weapons[0].checkFire(x, y, xPos, yPos);
        }
    }

    public void moveCharacter(int x, int y)
    {
        // steal kians code for enemy movement
    }
}
