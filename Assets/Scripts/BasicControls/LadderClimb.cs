using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimb : MonoBehaviour {
    public GameObject Mario;
    public GameObject MarioClimb;

    float playerPosition;
    public bool Inside = false;
    public bool goforword = false;
    float endgoal;
    public GameObject playGround;
    float ZplaygroundScale;
    float playerHeight;
    float ladder;
   
  
   

    // Use this for initialization
    void Start () {
        ZplaygroundScale =  playGround.transform.lossyScale.z;
        playerHeight = gameObject.transform.localScale.y / 2;
    }
	
	// Update is called once per frame
	void Update () {

        
        //goes Up if inside
        if(Inside == true && Input.GetKey("w"))
        {
           
            gameObject.transform.position += Vector3.up /7;
            gameObject.GetComponent<NonVRPlayerController>().Onladder = true;
        }
        //goes forword if at the end of the trigger
        if (goforword == true && Input.GetKey("w"))
        {
         
            gameObject.transform.position += Vector3.forward / 7;
      
        }
        //goes down if inside of trigger
        if (Inside == true && Input.GetKey("s"))
        {
            gameObject.transform.position += Vector3.down / 7;
           
        }
        //goes back if outside trigger else goes inside ladder and down
        if (goforword == true && Input.GetKey("s"))
        {
            gameObject.transform.position += Vector3.back / 7;
            if(gameObject.transform.position.z <= playerPosition)
            {
                Inside = true;
                goforword = false;
            }

        }
        // goes out of ladder mode if on middel of playground (the end destination) or back on the beginning
        if (gameObject.transform.position.z >= playerPosition + ZplaygroundScale || gameObject.transform.position.y <= ladder)
        {
            Inside = false;
            goforword = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<NonVRPlayerController>().Onladder = false;
            playerPosition = 0;

            MarioClimb.SetActive(false);
           

        }





    }

    private void OnTriggerStay(Collider other)
    {

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (  other.gameObject.tag == "Ladder" )
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            Inside = true;
            MarioClimb.SetActive(true);
            Mario.SetActive(false);

        }
  
    }
    private void OnTriggerEnter(Collider other)
    {

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (other.gameObject.tag == "Ladder" )
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            ladder = other.gameObject.transform.position.y;
        }
 
     

    }

    private void OnTriggerExit(Collider other)
    {

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (other.gameObject.tag == "Ladder" )
        {
        
            playerPosition = gameObject.transform.position.z; 
            Inside = false;
            goforword = true;
            }
      

        }

}







