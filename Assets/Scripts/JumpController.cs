using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public GameObject Player;
    public Transform FloorChecker;
    public LayerMask FloorLayer;
    private bool ContactFloor = true;
    private readonly float jumpForce = 800;

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
    }

    void UpdateContactFloor()
    {
        ContactFloor = Physics2D.OverlapCircle(FloorChecker.position, 0.07f, FloorLayer);
    }
}
