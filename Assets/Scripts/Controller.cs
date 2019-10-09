using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject pupusito;

    // Start is called before the first frame update
    void Start ()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Move.Instance.ToLeft(pupusito);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Move.Instance.ToRight(pupusito);
        }

        if (Input.GetKeyUp(KeyCode.A) ||  Input.GetKeyUp(KeyCode.D))
        {
            Move.Instance.Nothing(pupusito);
        }
    }
}
