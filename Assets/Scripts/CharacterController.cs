using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Character PupusitoGreen;

    public GameObject PupusitoGreenInstance;

    public LayerMask FloorLayer;

    // Start is called before the first frame update
    void Start()
    {
        PupusitoGreen = new Character(PupusitoGreenInstance);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            PupusitoGreen.MoveLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            PupusitoGreen.MoveRight();
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            PupusitoGreen.Still();
        }

        if (Input.GetKey(KeyCode.W) && PupusitoGreen.ContactFloor)
        {
            PupusitoGreen.Jump();
        }
        StartCoroutine(PupusitoGreen.CheckContactFloor(FloorLayer));
        PupusitoGreen.SetJumpingAnimation();
    }
}
