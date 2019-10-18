using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    public static Move Instance = new Move();

    public void ToRight(GameObject gameObject)
    {
        if (gameObject.GetComponent<SpriteRenderer>().flipX)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        gameObject.GetComponent<Animator>().SetBool("To Walk", true);
        gameObject.GetComponent<Transform>().Translate(Vector3.right * Time.deltaTime * 10);
    }

    public void ToLeft(GameObject gameObject)
    {
        if (!gameObject.GetComponent<SpriteRenderer>().flipX)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        gameObject.GetComponent<Animator>().SetBool("To Walk", true);
        gameObject.GetComponent<Transform>().Translate(Vector3.left * Time.deltaTime * 10);
    }

    public void Nothing(GameObject gameObject)
    {
        gameObject.GetComponent<Animator>().SetBool("To Walk", false);
    }

    private Move() { }
}
