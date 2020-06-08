using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderController : MonoBehaviour {

    public GameObject player;
    public bool ladder = false;

    void Start ()
    {
       
	}
	
	void Update ()
    {
        /*if (ladder)
        {
            player.transform.Translate(0.0f, 6.0f * Time.deltaTime, 0.0f);
        }*/
    }

    private void OnTriggerStay(Collider player)
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ladder = true;
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3.0f, player.transform.position.z + 3.0f);
        }   

        if (Input.GetKeyUp(KeyCode.W))
        {
            ladder = false;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        ladder = false;
    }
}
