using UnityEngine;

public class Exploder : Enemy
{
    public Exploder(int x_, int y_, Direction direction)
        : base(x_, y_, direction){
        type = EnemyType.Exploder;
    }

    public override GameObject GetEnemyPrefab(){
        GameObject exploderPrefab = Resources.Load("Prefabs/Exploder") as GameObject;
        exploderPrefab.name = "Exploder";
        return exploderPrefab;
    }

    public override void damageEnemy()
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

        for (int i = 0; i < 7; i++)
        {
            Game.current.paintTile(areaOfEffect[i, 0], areaOfEffect[i, 1]);
        }
        GameObject.Destroy(this.enemyObject);
    }
}
