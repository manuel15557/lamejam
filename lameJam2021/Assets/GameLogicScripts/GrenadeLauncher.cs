using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : Weapon
{
    private int[,] possibleShots = new int[37, 2];


    public override bool checkFire(int x, int y)
    {
        
        for (int i = 0; i < 37; i++)
        {
            if((x == possibleShots[i,0]) & (y == possibleShots[i, 1]))
            {
                print("firing");
                fireAt(x, y);
                return true;
            }
        }
        return false;
    }

    public override void setPossibleShots(int curX, int curY)
    {
        int shotCounter = 0;
        for (int i = (curX-3); i < (curX+4); i++)
        {
            for (int j = (curY-3); j < (curY + 4); j++)
            {
                if(curX > i)
                {
                    if (curY % 2 == 0)
                    {
                        if (Math.Abs(curX - i) <= (3 - Math.Floor(Math.Abs(curY - j) / 2f)))
                        {
                            possibleShots[shotCounter, 0] = i;
                            possibleShots[shotCounter, 1] = j;
                            shotCounter++;
                        }
                    }
                    else
                    {
                        if (Math.Abs(curX - i) <= (3 - Math.Ceiling(Math.Abs(curY - j) / 2f)))
                        {
                            possibleShots[shotCounter, 0] = i;
                            possibleShots[shotCounter, 1] = j;
                            shotCounter++;
                        }
                    }
                }
                else if(curX <= i)
                {
                    if (curY%2 == 0)
                    {
                        if (Math.Abs(curX - i) <= (3 - Math.Ceiling(Math.Abs(curY - j) / 2f)))
                        {
                            possibleShots[shotCounter, 0] = i;
                            possibleShots[shotCounter, 1] = j;
                            shotCounter++;
                        }
                    }
                    else
                    {
                        if (Math.Abs(curX - i) <= (3 - Math.Floor(Math.Abs(curY - j) / 2f)))
                        {
                            possibleShots[shotCounter, 0] = i;
                            possibleShots[shotCounter, 1] = j;
                            shotCounter++;
                        }
                    }
                }
                    
            }
        }
    }

    public override void highlightPossibleShots()
    {
        for (int i = 0; i < 37; i++)
        {
            Game.current.highlightTile(possibleShots[i, 0], possibleShots[i, 1]);
        }
    }

    public override void unhighlighPossibleShots()
    {
        for (int i = 0; i < 37; i++)
        {
            Game.current.unhighlightTile(possibleShots[i, 0], possibleShots[i, 1]);
        }
    }

    private void fireAt(int x, int y)
    {
        int[,] areaOfEffect = new int[7, 2];

        areaOfEffect[0, 0] = x - 1;
        areaOfEffect[0, 1] = y;

        areaOfEffect[1, 1] = y + 1;

        areaOfEffect[2, 1] = y + 1;

        areaOfEffect[3, 0] = x + 1;
        areaOfEffect[3, 1] = y;

        areaOfEffect[4, 1] = y - 1;

        areaOfEffect[5, 1] = y - 1;

        areaOfEffect[6, 0] = x;
        areaOfEffect[6, 1] = y;

        if (y % 2 == 0)
        {
            areaOfEffect[1, 0] = x - 1;
            areaOfEffect[2, 0] = x;
            areaOfEffect[4, 0] = x;
            areaOfEffect[5, 0] = x - 1;
        }
        else
        {
            areaOfEffect[1, 0] = x;
            areaOfEffect[2, 0] = x + 1;
            areaOfEffect[4, 0] = x + 1;
            areaOfEffect[5, 0] = x;
        }

        for(int i = 0; i < 7; i++)
        {
            NormalTile tempTile = null;
            Game.current.paintTile(areaOfEffect[i, 0], areaOfEffect[i, 1]);

            print(Game.current.getTile(areaOfEffect[i, 0], areaOfEffect[i, 1]));
            if (Game.current.getTile(areaOfEffect[i, 0], areaOfEffect[i, 1]) != null)
            {
                if (Game.current.getTile(areaOfEffect[i, 0], areaOfEffect[i, 1]).GetTileType() == TileType.NormalTile)
                {
                    tempTile = Game.current.getTile(areaOfEffect[i, 0], areaOfEffect[i, 1]) as NormalTile;
                    if (tempTile.getEnemy() != null)
                    {
                        tempTile.getEnemy().damageEnemy();
                    }
                }
            }
            
        }
        EventManager.current.selectMoveHandler(0);
    }
}
