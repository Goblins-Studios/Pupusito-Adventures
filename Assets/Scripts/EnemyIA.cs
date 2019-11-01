using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA
{
    Enemy Enemy;
    bool LookingRight = true;

    public bool EnemyUpdateMove()
    {
        if (Enemy.ContactWallRight && LookingRight)
        {
            LookingRight = false;
        }
        if (Enemy.ContactWallLeft && !LookingRight)
        {
            LookingRight = true;
        }
        return LookingRight;
    }

    public EnemyIA(Enemy enemy)
    {
        Enemy = enemy;
    }
}
