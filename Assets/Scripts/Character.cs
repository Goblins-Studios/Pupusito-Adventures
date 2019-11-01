using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Character
{
    protected GameObject Instance { get; set; }
    protected Transform FloorChecker { get; set; }
    public bool ContactFloor { get; private set; }
    protected readonly float Velocity = 15;
    protected readonly float JumpForce = 2000;

    public void MoveRight()
    {
        if (Instance.GetComponent<SpriteRenderer>().flipX)
        {
            Instance.GetComponent<SpriteRenderer>().flipX = false;
        }
        Instance.GetComponent<Animator>().SetBool("To Walk", true);
        Instance.GetComponent<Transform>().Translate(Vector3.right * Time.deltaTime * Velocity);
    }

    public void MoveLeft()
    {
        if (!Instance.GetComponent<SpriteRenderer>().flipX)
        {
            Instance.GetComponent<SpriteRenderer>().flipX = true;
        }
        Instance.GetComponent<Animator>().SetBool("To Walk", true);
        Instance.GetComponent<Transform>().Translate(Vector3.left * Time.deltaTime * Velocity);
    }

    public void Still()
    {
        Instance.GetComponent<Animator>().SetBool("To Walk", false);
    }

    public void Jump()
    {
        Instance.GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpForce);
    }

    public IEnumerator CheckContactFloor()
    {
        WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
        while (true)
        {
            ContactFloor = Physics2D.OverlapCircle(FloorChecker.position, 0.07f, LayerMask.GetMask("Brick"));
            yield return waitForFixedUpdate;
        }
    }

    public void SetJumpingAnimation()
    {
        Instance.GetComponent<Animator>().SetBool("Jumping", !ContactFloor);
    }

    public Character(GameObject instance)
    {
        Instance = instance;

        // Busca el Floor Checker hijo y lo asigna a la variable FloorChecker
        for (int i = 0; i < Instance.GetComponent<Transform>().childCount; i++)
        {
            if (Instance.GetComponent<Transform>().GetChild(i).name == "Floor Checker")
            { 
                FloorChecker = Instance.GetComponent<Transform>().GetChild(i);
            }
        }
    }
}
