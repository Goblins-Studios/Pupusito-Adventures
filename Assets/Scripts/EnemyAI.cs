using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI
{
    EnemyCharacter Enemy;
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

    public EnemyAI(EnemyCharacter enemy)
    {
        Enemy = enemy;
    }
}
