using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject EnemyGameObject;
    EnemyCharacter enemy;
    EnemyIA enemyIA;


    // Start is called before the first frame update
    void Start()
    {
        enemy = new EnemyCharacter(EnemyGameObject);
        enemyIA = new EnemyIA(enemy);
        InitiateIA();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateIA();
    }

    void InitiateIA()
    {
        StartCoroutine(enemy.CheckContactWall());
    }

    void UpdateIA()
    {
        if (enemyIA.EnemyUpdateMove())
        {
            enemy.MoveRight();
        }
        else
        {
            enemy.MoveLeft();
        }
    }
}
