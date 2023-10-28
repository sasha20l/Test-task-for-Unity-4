using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody rb;

    public float moveHorizontal;
    public float moveVertical;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical")*-1;



        //if (moveHorizontal != 0 || moveVertical != 0)
        //print(moveHorizontal + " " + moveVertical);
        Vector3 movement = new Vector3(moveVertical, 0.0f, moveHorizontal);
        rb.AddForce(movement * speed);

        moveHorizontal = 0f;
        moveVertical = 0f;

    }
}
