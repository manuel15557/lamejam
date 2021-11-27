using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : Weapon
{
    public override void checkFire(int tx, int ty, int px, int py)
    {
        if ((Math.Abs(tx - px) + Math.Abs(ty - py)) <= 4)
        {
            //valid
        }
    }
}
