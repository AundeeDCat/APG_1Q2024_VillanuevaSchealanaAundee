using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground_collider_data : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            player_controls.onFloor = true;
            player_controls.jumping = false;
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            player_controls.onFloor = false;
        }
    }
}
