using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orb_station : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<player_controls>().OrbPowerUp();
        }
    }
}
