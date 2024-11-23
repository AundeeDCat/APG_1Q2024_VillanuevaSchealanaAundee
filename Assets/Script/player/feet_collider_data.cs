using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feet_collider_data : MonoBehaviour
{
    // Start is called before the first frame update
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
