using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controls : MonoBehaviour
{
    Rigidbody playerBody;

    float Xaccleration = 30f;
    float XspeedLimit = 30f;
    float XspeedMultiplier = 1f;

    float YjumpHeight = 30f;
    float Ygravity = -1f;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Move_Right();
        }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Move_Left();
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Jump();
        }

        //else Idle();


        Debug.Log(playerBody.velocity);
        WorldGravity();
    }

    void Move_Right()
    {
        if (playerBody.velocity.x < XspeedLimit)
        {
            playerBody.AddForce(new Vector3(Xaccleration, 0, 0), ForceMode.Acceleration);

        }
    }    
    
    void Move_Left()
    {
        if (playerBody.velocity.x > -XspeedLimit)
        {
            playerBody.AddForce(new Vector3(-Xaccleration, 0, 0), ForceMode.Acceleration);
        }
    }

    void Jump()
    {
        if (playerBody.velocity.y == 0)
        {
            playerBody.AddForce(new Vector3(0, YjumpHeight, 0), ForceMode.VelocityChange);
        }
    }

    void WorldGravity()
    {
        if (playerBody.velocity.y != 0)
        {
            playerBody.AddForce(new Vector3(0, Ygravity, 0), ForceMode.VelocityChange);
        }
    }
}
// - 1f * XspeedMultiplier