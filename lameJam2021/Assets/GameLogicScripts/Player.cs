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
    curSelectedMove curSelectMove = curSelectedMove.Nothing;

    private int xPos = 1;
    private int yPos = 1;

    public Weapon[] weapons;

    public GameObject playerObject;

    public int[,] possibleMoves = new int[6, 2];


    // Start is called before the first frame update
    void Start()
    {
        //possibleMoves = new int[6, 2];
        EventManager.current.selectTileEvent += MakeMove;
        EventManager.current.selectMoveEvent += setMove;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMove(int id)
    {
        if (id == 0)
        {
            curSelectMove = curSelectedMove.Nothing;
        }
        if (id == 1)
        {
            curSelectMove = curSelectedMove.Move;
            setPossibleMoves();
        }
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
        print(tile.GetTileType());
        if (tile.GetTileType() == TileType.NormalTile)
        {

            
            for (int i = 0; i < 6; i++)
            {
                if (x == possibleMoves[i,0] && y == possibleMoves[i, 1])
                {
                    // Move is valid! move there. (Alex working on this)
                    setPosition(x, y);
                    break;
                }
            }
            
            
        }
        
    }

    /*
    private int[] CalculateMove(int x, int y, int dirVec)
    {
        // Start with current (x,y) coordinates
        int[] coords = { x, y };

        switch (dirVec)
        {
            case 0:
                print("checking if position " + coords[0] + " " + coords[1] + "is left to the player");
                coords[0]++;
                break;

            case 1:
                print("checking if position " + coords[0] + " " + coords[1] + "is up left to the player");
                if (coords[1] % 2 != 0)
                {
                    coords[0]++;
                }
                coords[1]--;
                break;

            case 2:
                print("checking if position " + coords[0] + " " + coords[1] + "is up right to the player");
                if (coords[1] % 2 == 0)
                {
                    coords[0]--;
                }
                coords[1]--;
                break;

            case 3:
                print("checking if position " + coords[0] + " " + coords[1] + "is right to the player");
                coords[0]--;
                break;

            case 4:
                print("checking if position " + coords[0] + " " + coords[1] + "is down right to the player");
                if (coords[1] % 2 == 0)
                {
                    coords[0]--;
                }
                coords[1]++;
                break;

            case 5:
                print("checking if position " + coords[0] + " " + coords[1] + "is down left to the player");
                if (coords[1] % 2 != 0)
                {
                    coords[0]++;
                }
                coords[1]++;
                break;
        }
        return coords;
    }
    */

    public void setPosition(int x, int y)
    { 
        Tile tile = Game.current.getTile(x, y);
        this.transform.position = tile.tile.transform.position;
        this.transform.position = new Vector3(this.transform.position.x, 2, this.transform.position.z);
        xPos = x;
        yPos = y;
        setPossibleMoves();
    }


    private void setPossibleMoves()
    { 
        possibleMoves[0, 0] = xPos - 1;
        possibleMoves[0, 1] = yPos;

        possibleMoves[1, 1] = yPos + 1;

        possibleMoves[2, 1] = yPos + 1;

        possibleMoves[3, 0] = xPos + 1;
        possibleMoves[3, 1] = yPos;

        possibleMoves[4, 1] = yPos - 1;

        possibleMoves[5, 1] = yPos - 1;

        if (yPos % 2 == 0)
        {
            possibleMoves[1, 0] = xPos - 1;
            possibleMoves[2, 0] = xPos;
            possibleMoves[4, 0] = xPos;
            possibleMoves[5, 0] = xPos - 1;
        }
        else
        {
            possibleMoves[1, 0] = xPos;
            possibleMoves[2, 0] = xPos + 1;
            possibleMoves[4, 0] = xPos + 1;
            possibleMoves[5, 0] = xPos;
        }

        if(curSelectMove == curSelectedMove.Move)
        {
            highlightPossibleMoves();
        }
    }


    private void highlightPossibleMoves()
    {
        for (int i = 0; i < 6; i++)
        {
            Game.current.highlightTile(possibleMoves[i, 0], possibleMoves[i, 1]);
        }
    }


    protected void rotateToCurrDirection()
    {
        this.transform.RotateAround
        (
        new Vector3(this.transform.position.x,
                    this.transform.position.y,
                    this.transform.position.z),
        new Vector3(0, 1, 0),
        (60 * (int)direction)
        );
    }
}
