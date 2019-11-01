using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Character
{
    public int Lives { private get; set; }
    private GameObject Instance { get; set; }
    private Transform FloorChecker { get; set; }
    public bool ContactFloor { get; private set; }

    public void MoveRight()
    {
        if (Instance.GetComponent<SpriteRenderer>().flipX)
        {
            Instance.GetComponent<SpriteRenderer>().flipX = false;
        }
        Instance.GetComponent<Animator>().SetBool("To Walk", true);
        Instance.GetComponent<Transform>().Translate(Vector3.right * Time.deltaTime * 10);
    }

    public void MoveLeft()
    {
        if (!Instance.GetComponent<SpriteRenderer>().flipX)
        {
            Instance.GetComponent<SpriteRenderer>().flipX = true;
        }
        Instance.GetComponent<Animator>().SetBool("To Walk", true);
        Instance.GetComponent<Transform>().Translate(Vector3.left * Time.deltaTime * 10);
    }

    public void Still()
    {
        Instance.GetComponent<Animator>().SetBool("To Walk", false);
    }

    public void Jump()
    {
        Instance.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
    }

    public IEnumerator CheckContactFloor(int FloorLayer)
    {
        WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
        while (true)
        {
            ContactFloor = Physics2D.OverlapCircle(FloorChecker.position, 0.07f, FloorLayer);
            yield return waitForFixedUpdate;
        }
    }

    public void SetJumpingAnimation()
    {
        Instance.GetComponent<Animator>().SetBool("Jumping", !ContactFloor);
    }

    public Character(GameObject Instance)
    {
        this.Instance = Instance;
        Lives = 2;

        // Busca el Floor Checker hijo y lo asigna a la variable FloorChecker
        for (int i = 0; i < Instance.GetComponent<Transform>().childCount; i++)
        {
            if (Instance.GetComponent<Transform>().GetChild(i).name == "Floor Checker")
                FloorChecker = Instance.GetComponent<Transform>().GetChild(i);
        }
    }
}
