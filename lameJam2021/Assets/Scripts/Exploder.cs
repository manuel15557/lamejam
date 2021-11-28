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
}
