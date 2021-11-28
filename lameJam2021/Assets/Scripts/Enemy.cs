using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Enemy{
    public Direction dirVec;
    public int stepsize; //delete?
    public int x;
    public int y;

    public GameObject enemyObject;

    public EnemyType type = EnemyType.None;

    public Enemy(int x_, int y_, Direction direction)
    {
        x = x_;
        y = y_;
        dirVec = direction;
        EventManager.current.advanceTimeEvent += Move;
    }

    public void Spawn(){
        Tile currTile = Game.current.getTile(x, y);

        enemyObject = GameObject.Instantiate(GetEnemyPrefab());
        enemyObject.transform.position
            = new Vector3(currTile.tile.transform.position.x,
                          def.HexagonHeight,
                          currTile.tile.transform.position.z);
        rotateToCurrDirection();
    }

    public abstract GameObject GetEnemyPrefab();

    public abstract void damageEnemy();

    protected void rotateToCurrDirection(){
        enemyObject.transform.RotateAround
        (
        new Vector3(enemyObject.transform.position.x,
                    enemyObject.transform.position.y,
                    enemyObject.transform.position.z),
        new Vector3(0, 1, 0),
        (60 * (int)dirVec)
        );
    }

    #region Movement
    void Move()
    {
        // Calculate the coords of the move based on current x,y and dirVec (and step size in future??)
        int[] coords = CalculateMove(x, y, dirVec);

        // Get tile at calculated coords
        Tile tile = Game.current.getTile(coords[0], coords[1]);

        // If tile is one to which we can move
        if (tile.GetTileType() == TileType.NormalTile)
        {
            // move there. (Alex working on this)
        }
        // if not valid, try the opposite direction
        else
        {
            int oppDirVec = ((int)dirVec + 3) % 6;

            // Attempt move in opposite direction
            coords = CalculateMove(x, y, (Direction)oppDirVec);

            // Get tile at calculated coords
            tile = Game.current.getTile(coords[0], coords[1]);

            // If THIS NEW tile is one to which we can move
            if (tile.GetTileType() == TileType.NormalTile)
            {
                // move there. (Alex working on this)
            }
            else
            {
                // if STILL not valid, consume turn (Mayvbe remain station as a move similar to play mechanic?)
            }
        }
    }

    private int[] CalculateMove(int x, int y, Direction dirVec)
    {
        // Start with current (x,y) coordinates
        int[] coords = { x, y };

        switch (dirVec)
        {
            case Direction.Left:
                coords[0]--;
                break;

            case Direction.TopLeft:
                if (coords[1] % 2 == 0)
                {
                    coords[0]--;
                }
                coords[1]--;
                break;

            case Direction.TopRight:
                if (coords[1] % 2 != 0)
                {
                    coords[0]--;
                }
                coords[1]--;
                break;

            case Direction.Right:
                coords[0]++;
                break;

            case Direction.BottomRight:
                if (coords[1] % 2 == 0)
                {
                    coords[0]--;
                }
                coords[1]++;
                break;

            case Direction.BottomLeft:
                if (coords[1] % 2 != 0)
                {
                    coords[0]++;
                }
                coords[1]++;
                break;
        }
        return coords;
    }
    #endregion
}
