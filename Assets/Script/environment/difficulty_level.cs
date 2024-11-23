using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficulty_level : MonoBehaviour
{
    public static float timePassed = 0;
    public Material[] liquidMaterial; 

    float mediumSpeed = 0.1f;
    float mediumWaitTime = 30f;

    Vector3 hardMin = new Vector3(0, 0, 0);
    Vector3 hardMax = new Vector3(0, 1, 0);
    float timeToMax = 60;
    float hardWaitTime = 10f;

    int Difficulty = 1;

    float yPos;
    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        timePassed += Time.deltaTime;

        if (Difficulty == 0) Easy();
        if (Difficulty == 1) Medium();
        if (Difficulty == 2) Hard();

        //Debug.Log(yPos);
    }
    void Easy()
    {
        GetComponent<Renderer>().material = liquidMaterial[0];
    }

    void Medium()
    {
        GetComponent<Renderer>().material = liquidMaterial[1];

        if (timePassed > mediumWaitTime && player_controls.currentspawn >= 1)
        {
            rb.velocity = new Vector3(0, mediumSpeed, 0);
        }
    }

    void Hard()
    {
        GetComponent<Renderer>().material = liquidMaterial[2];

        if (timePassed > hardWaitTime)
        {
            rb.velocity = Vector3.Lerp(hardMin, hardMax, timePassed - hardWaitTime / timeToMax);
        }
    }
}
