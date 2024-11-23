using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vine_collider_data : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player_controls.onFloor = true;
            player_controls.jumping = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player_controls.onFloor = false;
        }
    }
}
