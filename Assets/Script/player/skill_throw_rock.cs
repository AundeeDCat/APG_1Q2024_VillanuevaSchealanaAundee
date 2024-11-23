using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_throw_rock : MonoBehaviour
{
    float xVelocity, yVelocity, zVelocity;
    public float setTime;

    public Rigidbody rb;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        this.transform.position = new Vector3(0, -50f, 0);
    }

    IEnumerator TimedDespawn()
    {
        yield return new WaitForSeconds(5f);
        this.transform.position = new Vector3(0, -50f, 5);
        player_controls.throwRock = false;
    }

    public void Throw()
    {
        this.transform.position = player.gameObject.transform.position + new Vector3(0f, 0f, -2f);
        player_controls.point += new Vector3(0f, 0f, -2f);
        rb.velocity = Vector3.zero;

        StartCoroutine(TimedDespawn());

        setTime = EstimateTime();

        xVelocity = xVelocityCalc(setTime);
        yVelocity = yVelocityCalc(setTime);
        zVelocity = zVelocityCalc(setTime);

        rb.velocity = new Vector3(xVelocity, yVelocity, zVelocity);
    }

//Trajectory Calculations
    float xVelocityCalc(float time)
    {
        float targetX = player_controls.point.x - this.transform.position.x;

        return targetX / time;
    }


    float yVelocityCalc(float time)
    {
        float targetY = player_controls.point.y - this.transform.position.y;

        return (targetY + 0.5f * 9.8f * time * time) / time; ;
    }


    float zVelocityCalc(float time)
    {
        float targetZ = player_controls.point.z - this.transform.position.z;

        return targetZ / time;
    }

    float EstimateTime()
    {
        float targetY = player_controls.point.y - this.transform.position.y;

        return (targetY / 10);
    }
}
