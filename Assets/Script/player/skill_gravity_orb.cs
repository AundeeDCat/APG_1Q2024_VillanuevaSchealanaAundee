using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_gravity_orb : MonoBehaviour
{
    public float Intensity = 35, Range = 25, MinDepth = 0;
    float MaxDepth;
    Collider[] Bodies;

    void Start()
    {
        //StartCoroutine(TimedDespawn());
        this.transform.position = new Vector3(0, -50f, 0);
    }

    void Update()
    {
        ApplyReverseGravity();
    }

    void ApplyReverseGravity()
    {
        Bodies = Physics.OverlapSphere(transform.position, Range);
        foreach (Collider b in Bodies)
        {
            if (b.gameObject.tag == "Player")
            {
                Vector2 direction = transform.position - b.gameObject.transform.position;
                float distance = Vector2.Distance(this.transform.position, b.gameObject.transform.position);
                direction.Normalize();
                float DistanceIntensity = (distance / Range) * Intensity;

                Rigidbody rb = b.gameObject.GetComponent<Rigidbody>();
                rb.AddForce(direction * DistanceIntensity);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    IEnumerator TimedDespawn()
    {
        yield return new WaitForSeconds(1f);
        this.transform.position = new Vector3(0, -50f, 0);
        player_controls.spawnedOrb = false;
    }

    public void Spawn()
    {
        this.transform.position = player_controls.point;
        StartCoroutine(TimedDespawn());
    }
}
