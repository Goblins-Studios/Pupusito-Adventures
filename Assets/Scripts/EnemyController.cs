using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Enemy;
    private List<EnemyCharacter> Enemies { get; set; }
    private List<EnemyAI> EnemyAIs { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Enemies = new List<EnemyCharacter>();
        EnemyAIs = new List<EnemyAI>();

        StartCoroutine(GenerateEnemy(Enemy, new List<Vector2> { new Vector2(-18, -17)}, new List<float> {3f, 1f, 3f}));
        InitiateAI();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateAI();
    }

    void InitiateAI()
    {
        foreach (var enemy in Enemies)
        {
            StopCoroutine(enemy.CheckContactWall());
            StartCoroutine(enemy.CheckContactWall());
        }
    }

    void UpdateAI()
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (EnemyAIs[i].EnemyCanMoveToRight())
            {
                // El argumento es 1 porque reperesenta a la derecha en el eje horizontal
                Enemies[i].Move(1);
            }
            else
            {
                // El argumento es -1 porque reperesenta a la izquierda en el eje horizontal
                Enemies[i].Move(-1);
            }
        }
    }

    IEnumerator GenerateEnemy(GameObject enemy, List<Vector2> positions, List<float> times)
    {
        GameObject enemyGameObjectClone;
        EnemyCharacter enemyCharacter;
        EnemyAI enemyAI;
        int positionsIndex;
        int timesIndex;

        while (true)
        {
            positionsIndex = 0; //Random.Range(0, positions.Count);
            timesIndex = 0; //Random.Range(0, times.Count);

            enemyGameObjectClone = Instantiate(enemy);
            enemyGameObjectClone.GetComponent<Transform>().position = positions[positionsIndex];

            enemyCharacter = new EnemyCharacter(enemyGameObjectClone);
            Enemies.Add(enemyCharacter);
            enemyAI = new EnemyAI(enemyCharacter);
            EnemyAIs.Add(enemyAI);

            InitiateAI();

            yield return new WaitForSeconds(times[timesIndex]);
        }
    }
}
