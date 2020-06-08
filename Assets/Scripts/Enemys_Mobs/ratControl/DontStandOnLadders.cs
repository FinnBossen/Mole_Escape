using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontStandOnLadders : MonoBehaviour
{

    public GameObject Rat;
    private ratController controller;
    bool GoAwayFromLadder = false;
    bool GoAwayFromSpawn = false;
    public GameObject Walking;
    public GameObject Idle;
    public int Ladders = 0;
    public GameObject WhiteWalking;
    public GameObject WhiteIdle;
    private float contactTime;
   private voxelloop WalkingAnim;
    private voxelloop IdleAnim;
    public int Spawns = 0;
    private voxelloop WhiteWalkingAnim;
    private voxelloop WhiteIdleAnim;
    private bool CanChangeDirection =false;

    public bool HadChangedDirection = false;
    // Start is called before the first frame update
    void Start()
    {
        WalkingAnim = Walking.GetComponent<voxelloop>();
        IdleAnim = Idle.GetComponent<voxelloop>();
        WhiteWalkingAnim = WhiteWalking.GetComponent<voxelloop>();
        WhiteIdleAnim = WhiteIdle.GetComponent<voxelloop>();
        controller = Rat.GetComponent<ratController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (GoAwayFromLadder)
        {
            if (controller.Moving == false && controller.SomethingTargeted == false)
            {

                WalkingAnim.animActivated = true;
                WhiteWalkingAnim.animActivated = true;
                IdleAnim.animActivated = false;
                WhiteIdleAnim.animActivated = false;
                controller.Moving = true;

             
            }


            if (CanChangeDirection)
            {
                Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                controller.Direction = !controller.Direction;
                controller.RatBody.transform.Rotate(0, -180, 0);
                HadChangedDirection = true;
                CanChangeDirection = false;
            }


        }

        if (GoAwayFromSpawn)
        {


            if (controller.Moving == false)
            {

                WalkingAnim.animActivated = true;
                WhiteWalkingAnim.animActivated = true;
                IdleAnim.animActivated = false;
                WhiteIdleAnim.animActivated = false;
                controller.Moving = true;
                controller.SomethingTargeted = false;

            }
          




            if (CanChangeDirection)
            {
                Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                controller.Direction = !controller.Direction;
                controller.RatBody.transform.Rotate(0, -180, 0);
                HadChangedDirection = true;
                CanChangeDirection = false;
            }


        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("LadderDown")|| other.CompareTag("LadderUp"))
        {

            Ladders++;
            if(Ladders > 0)
            {
                GoAwayFromLadder = true;
            }
                   
                

           

         
        }

        if (other.CompareTag("Spawn"))
        {

            Spawns++;
            if (Spawns > 0)
            {
                GoAwayFromSpawn = true;
            }

        }

        if (other.CompareTag("Curve"))
        {
            Debug.Log("dsadfaffsdssfsssssssssssssssssssssssssssssssssssssssssssssssss");

            if (!CanChangeDirection)
            {
                CanChangeDirection = true;
            }





        }



    }

 



    IEnumerator ReactivateDirectionChanger(int time )
    {
       
        yield return new WaitForSeconds(time);
        CanChangeDirection = true;
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("LadderDown") || other.CompareTag("LadderUp"))
        {
            Ladders--;
            if (controller.Moving == true && GoAwayFromLadder == true )
            {
                Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                

                if(Ladders == 0) {
                    controller.Moving = false;

                    GoAwayFromLadder = false;

                    WalkingAnim.animActivated = false;
                    WhiteWalkingAnim.animActivated =false;
                    IdleAnim.animActivated = true;
                    WhiteIdleAnim.animActivated = true;


                    if (HadChangedDirection) { 
                    controller.Direction = !controller.Direction;
                    controller.RatBody.transform.Rotate(0, -180, 0);
                    HadChangedDirection = false;
                    }
                }
            }
            
        }

        if (other.CompareTag("Spawn") )
        {
            Spawns--;
            if (controller.Moving == true && GoAwayFromSpawn == true)
            {
                Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");


                if (Spawns == 0)
                {
                    controller.Moving = false;

                    GoAwayFromSpawn = false;

                    WalkingAnim.animActivated = false;
                    WhiteWalkingAnim.animActivated = false;
                    IdleAnim.animActivated = true;
                    WhiteIdleAnim.animActivated = true;

                    if (controller.PlayersTargeted.Count > 0) { 
                    controller.SomethingTargeted = true;
                    }
                    if (HadChangedDirection)
                    {
                        controller.Direction = !controller.Direction;
                        controller.RatBody.transform.Rotate(0, -180, 0);
                        HadChangedDirection = false;
                    }
                }
            }

        }
    }
    
}


