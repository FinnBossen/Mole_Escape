using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {
    Transform targetPathNode;
    public int pathNodeIndex = 0;
    public bool rotates = true;
    public GameObject Mario;
    NonVRPlayerController MarioControl;
    float speed = 5f;
    bool goToHalfLadder = false;
    bool interruptDown = false;
    bool interruptUp = false;
    bool goup = true;
    int firsttime = 0;
    Vector3 dir;
    // Use this for initialization
    void Start () {
       MarioControl = Mario.GetComponent<NonVRPlayerController>();
	}
	
	// Update is called once per frame
	void Update () {

        /*
        if (interruptUp )
        {
            GetNextPathNode();
            interruptUp = false;
            interruptDown = true;
            Debug.Log("Hallo" + targetPathNode.position);
            dir =targetPathNode.position - Mario.transform.localPosition;

        }

        if (interruptDown )
        {
            GetLastPathNode();
            interruptDown = false;
            interruptUp = true;
            Debug.Log("Hallo"+targetPathNode.position);
            dir = targetPathNode.position - Mario.transform.localPosition;
        }

      */
         
        
    }

    void GetNextPathNode()
    {
        if (pathNodeIndex < gameObject.transform.childCount)
        {
            if (pathNodeIndex == 2)
            {
                firsttime = 1;
            }

            targetPathNode = gameObject.transform.GetChild(pathNodeIndex);
            pathNodeIndex++;

           
        }
        else
        {
            targetPathNode = null;
           
        }
    }


    void GetLastPathNode()
    {
        if (pathNodeIndex > 0)
        {
          
       
            pathNodeIndex--;
            targetPathNode = gameObject.transform.GetChild(pathNodeIndex);
              
          

        }
        else
        {
            targetPathNode = null;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Mario = other.gameObject;
            MarioControl = other.gameObject.GetComponent<NonVRPlayerController>();
            if (MarioControl.goUpKeyPressed && goup)
            {
                if (targetPathNode != null)
                {
                    //Debug.Log(targetPathNode.position);
                }
                if(!MarioControl.isGrounded && !MarioControl.Onladder)
                {
                    goToHalfLadder = true;
                   
                }

                if (interruptUp)
                {
                    if (pathNodeIndex > gameObject.transform.childCount)
                    {


                        pathNodeIndex--;
                    }
                    else
                    {
                        pathNodeIndex++;
                    }
                    targetPathNode = gameObject.transform.GetChild(pathNodeIndex);
                    Debug.Log("godup" + pathNodeIndex);
                    interruptUp = false;
                    interruptDown = true;
                }

                    MarioControl.Onladder = true;

                Mario.GetComponent<Rigidbody>().isKinematic = true;
                Mario.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                if (targetPathNode == null)
                {

                    interruptDown = true;

                    if (goToHalfLadder)
                    {
                        goToHalfLadder = false;
                        targetPathNode = gameObject.transform.GetChild(1);
                        pathNodeIndex = 1;
                        interruptDown = true;

                    }
                    else {
                    GetNextPathNode();
                    interruptDown = true;
                    }
                    if (targetPathNode == null)
                    {
                        // We've run out of path!
                        Mario.GetComponent<Rigidbody>().isKinematic = false;
                        Mario.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionX;
                        MarioControl.Onladder = false;
                        goup = false;
                        return;

                    }
                }

                dir = targetPathNode.position - Mario.transform.localPosition;

                float distThisFrame = speed * Time.deltaTime;

                if (dir.magnitude <= distThisFrame)
                {
                    // We reached the node
                    targetPathNode = null;
                }
                else
                {
                    // TODO: Consider ways to smooth this motion.

                    // Move towards node
                    Mario.transform.Translate(dir.normalized * distThisFrame, Space.World);


                }
            }

            if (MarioControl.goDownKeyPressed)
            {
                goup = true;
                if (targetPathNode != null) { 
               // Debug.Log(targetPathNode.position);
                }
                MarioControl.Onladder = true;
                Mario.GetComponent<Rigidbody>().isKinematic = true;
                Mario.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;

                if (interruptDown)
                {
                    if (firsttime != 0 )
                    {

                        Debug.Log("goDOwn Before" + pathNodeIndex);
                        pathNodeIndex = pathNodeIndex - 1;
                        if (pathNodeIndex == 2)
                        {
                            pathNodeIndex = 1;
                        }
                    }
                    else
                    {
                    
                        pathNodeIndex = firsttime;
                        firsttime = 1;
                            
                    }
                    targetPathNode = gameObject.transform.GetChild(pathNodeIndex);
                    interruptDown = false;
                    interruptUp = true;
                    Debug.Log("goDOwn" + pathNodeIndex);
                }


                if (targetPathNode == null)
                {
                   
                    GetLastPathNode();
                    interruptUp = true;

                    if (targetPathNode == null)
                    {
                        // We've run out of path!
                        Mario.GetComponent<Rigidbody>().isKinematic = false;
                        Mario.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionX;
                        MarioControl.Onladder = false;
                        goup = true;
                        return;
                        
                    }
                }
           




                dir = targetPathNode.position - Mario.transform.localPosition;

                float distThisFrame = speed * Time.deltaTime;

                if (dir.magnitude <= distThisFrame)
                {
                    // We reached the node
                    targetPathNode = null;
                }
                else
                {
                    // TODO: Consider ways to smooth this motion.

                    // Move towards node
                    Mario.transform.Translate(dir.normalized * distThisFrame, Space.World);


                }
            }

        }


    }
    private void OnTriggerExit(Collider other)
    {
        Mario.GetComponent<Rigidbody>().isKinematic = false;
        Mario.transform.rotation = Quaternion.identity;
        Mario.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        Mario.GetComponent<Rigidbody>().isKinematic = false;
        Mario.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionX;
        MarioControl.Onladder = false;
        MarioControl.MarioClimb.SetActive(false);
        MarioControl.MarioJump.SetActive(false);
        MarioControl.Mario.SetActive(true);

        firsttime = 0;
        goup = true;



    }



}
