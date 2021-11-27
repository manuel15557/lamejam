using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    NormalTile,
    WallTile,
    AcidTile
}

[System.Serializable]
public struct TileInfo
{
    public TileType type;
    public int x;
    public int y;
    public string specialInfo;
}

public enum EnemyType
{
    Boomer
}

[System.Serializable]
public struct EnemyInfo
{
    public EnemyType type;
    public int x;
    public int y;
}

public enum WeaponType
{
    GrenadeLauncher,
    PaintGun
}

[System.Serializable]
public struct AllyInfo
{
    public WeaponType[] weaponTypes;
    public int[] ammoAmt;
    public int movementPoints;
    public int x;
    public int y;
}

public class Level : MonoBehaviour
{
    public TileInfo[] tiles;
    public EnemyInfo[] enemies;
    public AllyInfo[] allies;

    private LevelBuilder LevelBuilder = null;

    public void buildLevel()
    {
        if(LevelBuilder != null) { return; }
        LevelBuilder = (LevelBuilder)((new GameObject()).AddComponent<LevelBuilder>());
        LevelBuilder.SetLevel(this);
        LevelBuilder.buildLevel();
    }

    // Start is called before the first frame update
    void Start()
    {
        buildLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
