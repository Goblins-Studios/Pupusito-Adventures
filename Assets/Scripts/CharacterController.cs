using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
   PlayerCharacter PupusitoGreen;

    public GameObject PupusitoGreenInstance;

    // Start is called before the first frame update
    void Start()
    {
        PupusitoGreen = new PlayerCharacter(PupusitoGreenInstance);
        InitiateMovement();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }

    void InitiateMovement()
    {
        StartCoroutine(PupusitoGreen.CheckContactFloor());
    }

    void UpdateMovement()
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

        if (Input.GetKeyDown(KeyCode.W) && PupusitoGreen.ContactFloor)
        {
            PupusitoGreen.Jump();
        }

        PupusitoGreen.SetJumpingAnimation();
    }
}
