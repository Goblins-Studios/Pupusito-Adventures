using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    protected Transform WallCheckerRight { get; set; }
    protected Transform WallCheckerLeft { get; set; }
    public bool ContactWallRight { get; private set; }
    public bool ContactWallLeft { get; private set; }

    public IEnumerator CheckContactWall()
    {
        WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
        while (true)
        {
            ContactWallRight = Physics2D.OverlapCircle(WallCheckerRight.position, 0.07f, LayerMask.GetMask("Brick"));
            ContactWallLeft = Physics2D.OverlapCircle(WallCheckerLeft.position, 0.07f, LayerMask.GetMask("Brick"));
            yield return waitForFixedUpdate;
        }
    }

    public EnemyCharacter(GameObject Instance) : base (Instance)
    {
        // Busca Wall Checker Right en los hijos de la instancia
        for (int i = 0; i < Instance.GetComponent<Transform>().childCount; i++)
        {
            if (Instance.GetComponent<Transform>().GetChild(i).name == "Wall Checker Right")
                WallCheckerRight = Instance.GetComponent<Transform>().GetChild(i);
        }

        // Busca Wall Checker Left en los hijos de la instancia
        for (int i = 0; i < Instance.GetComponent<Transform>().childCount; i++)
        {
            if (Instance.GetComponent<Transform>().GetChild(i).name == "Wall Checker Left")
            {
                WallCheckerLeft = Instance.GetComponent<Transform>().GetChild(i);
            }
        }
    }
}
