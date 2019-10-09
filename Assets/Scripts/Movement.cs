using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NewBehaviourScript
{
    public static void Derecha(GameObject gameObject)
    {
        if (Input.GetKey("D"))
        {
            if (gameObject.GetComponent<SpriteRenderer>().flipX)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            gameObject.GetComponent<Animator>().SetBool("To Walk", true);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.2f, 0));
        }

        if (Input.GetKey("A"))
        {
            if (!gameObject.GetComponent<SpriteRenderer>().flipX)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            gameObject.GetComponent<Animator>().SetBool("To Walk", true);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-0.2f, 0));
        }

        if(Input.GetKeyUp("A") || Input.GetKeyUp("D"))
        {
            gameObject.GetComponent<Animator>().SetBool("To Walk", false);
        }

    }
}
