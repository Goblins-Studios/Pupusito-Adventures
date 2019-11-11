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
    void FixedUpdate()
    {
        UpdateMovement();
    }

    void InitiateMovement()
    {
        StartCoroutine(PupusitoGreen.CheckContactFloor());
    }

    void UpdateMovement()
    {
        PupusitoGreen.Move(Input.GetAxis("Horizontal Player1"));

        if ((Input.GetAxis("Jump Player1") > 0) && PupusitoGreen.ContactFloor)
        {
            PupusitoGreen.Jump();
        }

        PupusitoGreen.SetJumpingAnimation();
    }
}
