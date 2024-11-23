using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public Material[] CheckpointColors;
    public int checkpointNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = CheckpointColors[0];
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<Renderer>().material = CheckpointColors[1];

            player_controls.currentspawn = checkpointNumber;
        }
    }
}
