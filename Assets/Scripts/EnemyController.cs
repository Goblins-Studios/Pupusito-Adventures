using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private List<EnemyCharacter> Enemies { get; set; }
    private List<EnemyAI> EnemyIAs { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Enemies = new List<EnemyCharacter>();
        EnemyIAs = new List<EnemyAI>();
        InitiateIA();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateIA();
    }

    void InitiateIA()
    {
        foreach (var enemy in Enemies)
        {
            StartCoroutine(enemy.CheckContactWall());
        }
    }

    void UpdateIA()
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (EnemyIAs[i].EnemyUpdateMove())
            {
                Enemies[i].MoveRight();
            }
            else
            {
                Enemies[i].MoveLeft();
            }
        }
    }
}
