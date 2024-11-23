using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controls : MonoBehaviour
{
    Rigidbody playerBody;
    public Material[] playerMaterial;

    float Xaccleration = 30f;
    float XspeedLimit = 30f;

    public static float XspeedMultiplier = 1f;
    public static float YgravMultiplier = 1f;

    float YjumpHeight = 30f;
    float Ygravity = -1f;

    public Vector3[] spawnpoint;
    public static int currentspawn = 0;

    public static bool onFloor = false;
    public static bool jumping = false;

    public static bool spawnedOrb = false;
    public static bool orbPower = false;

    public static bool throwRock = false;
    public static bool rockPower = false;

    public Camera cam;
    public static Vector3 point = new Vector3();
    public GameObject gravityOrb;
    public GameObject throwableRock;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();

        Respawn();
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

        if (Input.GetKey(KeyCode.Space))
        {
            MouseAim();
        }

        //Debug.Log(playerBody.velocity);
        //Debug.Log(onFloor);
        AddedGravityIntesity();

    }

    void Move_Right()
    {
        if (playerBody.velocity.x < XspeedLimit)
        {
            playerBody.AddForce(new Vector3(Xaccleration * XspeedMultiplier, 0, 0), ForceMode.Acceleration);
        }
    }    
    
    void Move_Left()
    {
        if (playerBody.velocity.x > -XspeedLimit)
        {
            playerBody.AddForce(new Vector3(-Xaccleration * XspeedMultiplier, 0, 0), ForceMode.Acceleration);
        }
    }

    void Jump()
    {
        if (!jumping && onFloor)
        {
            playerBody.AddForce(new Vector3(0, YjumpHeight, 0), ForceMode.VelocityChange);
            jumping = true;
        }
    }

    void AddedGravityIntesity()
    {
        if (playerBody.velocity.y != 0 && !onFloor)
        {
            playerBody.AddForce(new Vector3(0, Ygravity * YgravMultiplier, 0), ForceMode.VelocityChange);
        }
    }
    
    void MouseAim()
    {
        Vector2 mousePos = Input.mousePosition;

        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 25));
        point.z = 0;

        if (!spawnedOrb && orbPower)
        {
            gravityOrb.GetComponent<skill_gravity_orb>().Spawn();
            GetComponent<Renderer>().material = playerMaterial[0];

            XspeedMultiplier = 1f;
            YgravMultiplier = 1f;

            orbPower = false;
            spawnedOrb = true;
        }
        
        else if (!throwRock && rockPower)
        {
            throwableRock.GetComponent<skill_throw_rock>().Throw();
            GetComponent<Renderer>().material = playerMaterial[0];

            XspeedMultiplier = 1f;
            YgravMultiplier = 1f;
            XspeedLimit = 30f;

            rockPower = false;
            throwRock = true;
        }
    }

    public void Respawn()
    {
        playerBody.velocity = new Vector3(0, 0, 0);
        transform.position = spawnpoint[currentspawn];
    }

    public void RockPowerUp()
    {
        rockPower = true;
        XspeedMultiplier = 0.5f;
        YgravMultiplier = 2f;
        GetComponent<Renderer>().material = playerMaterial[1];
    }

    public void OrbPowerUp()
    {
        orbPower = true;
        XspeedMultiplier = 2.5f;
        XspeedLimit = 50f;
        YgravMultiplier = 0.25f;
        GetComponent<Renderer>().material = playerMaterial[2];
    }
}