using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public GameObject Player;
    public Transform FloorChecker;
    public LayerMask FloorLayer;
    private bool ContactFloor = true;
    private readonly float jumpForce = 1000;

    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        UpdateContactFloor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && ContactFloor)
        {
            Player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
        }

        Player.GetComponent<Animator>().SetBool("Jumping", !ContactFloor);
    }

    void UpdateContactFloor()
    {
        ContactFloor = Physics2D.OverlapCircle(FloorChecker.position, 0.07f, FloorLayer);
    }
}
