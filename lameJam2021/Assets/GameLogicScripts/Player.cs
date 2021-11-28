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

    public void MakeMove(int x, int y)
    {
        if (curSelectMove == curSelectedMove.Move)
        {
            MoveCharacter(x, y);
        }
        else if(curSelectMove == curSelectedMove.GrenadeLauncher)
        {
            weapons[0].checkFire(x, y, xPos, yPos);
        }
    }

    public void MoveCharacter(int x, int y)
    {
        // Get tile at calculated coords
        Tile tile = Game.current.getTile(x, y);

        // If tile is one to which we can move
        if (tile.GetTileType() == TileType.NormalTile)
        {

            for (int i = 0; i < 6; i++)
            {
                int[] coords = CalculateMove(x, y, i);
                if (x == coords[0] && y == coords[1])
                {
                    // Move is valid! move there. (Alex working on this)
                }
            }
        }
    }
    private int[] CalculateMove(int x, int y, int dirVec)
    {
        // Start with current (x,y) coordinates
        int[] coords = { x, y };

        switch (dirVec)
        {
            case 0:
                coords[0]--;
                break;

            case 1:
                if (coords[1] % 2 == 0)
                {
                    coords[0]--;
                }
                coords[1]--;
                break;

            case 2:
                if (coords[1] % 2 != 0)
                {
                    coords[0]--;
                }
                coords[1]--;
                break;

            case 3:
                coords[0]++;
                break;

            case 4:
                if (coords[1] % 2 == 0)
                {
                    coords[0]--;
                }
                coords[1]++;
                break;

            case 5:
                if (coords[1] % 2 != 0)
                {
                    coords[0]++;
                }
                coords[1]++;
                break;
        }
        return coords;
    }
}
