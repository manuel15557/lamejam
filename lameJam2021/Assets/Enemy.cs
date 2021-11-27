using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using Tile;

public class Enemy : MonoBehaviour
{

    private int dirVec;
    private int stepsize;
    private int x;
    private int y;

    private int[] allowableTiles = {0, 1, 3};

    public Enemy(int x_, int y_, int direction)
    {
        x = x_;
        y = y_;
        dirVec = direction;
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.current.advanceTimeEvent += Move();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move()
    {
        // Calculate the coords of the move based on current x,y and dirVec (and step size in future??)
        int[] coords = CalculateMove(x, y, dirVec);

        // Get tile at calculated coords
        Tile tile = Game.current.getTile(coords[0], coords[1]);

        // If tile is one to which we can move
        if (Array.Exists(allowableTiles, tile.type))
        {
            // move there. (Alex working on this)
        }
        // if not valid, try the opposite direction
        else
        {
            int oppDirVec = (dirVec + 3) % 6;

            // Attempt move in opposite direction
            coords = CalculateMove(x, y, oppDirVec);

            // Get tile at calculated coords
            Tile tile = Game.current.getTile(coords[0], coords[1]);

            // If THIS NEW tile is one to which we can move
            if (Array.Exists(allowableTiles, tile.type))
            {
                // move there. (Alex working on this)
            }
            else
            {
                // if STILL not valid, consume turn (Mayvbe remain station as a move similar to play mechanic?)
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
