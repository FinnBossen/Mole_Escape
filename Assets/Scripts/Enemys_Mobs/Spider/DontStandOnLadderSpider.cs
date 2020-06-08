using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontStandOnLadderSpider : MonoBehaviour
{

    public GameObject SpiderControl;
    private SpiderController controller;
    bool GoAwayFromLadder = false;
    bool GoAwayFromSpawn = false;
    public GameObject SpiderHorizontally;
    public int Spawns = 0;
    public int Ladders = 0;

    private float contactTime;
 
    private bool CanChangeDirection = false;

    public bool HadChangedDirection = false;
    // Start is called before the first frame update
    void Start()
    {
     
        controller = SpiderControl.GetComponent<SpiderController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Ladders > 0)
        {
            if (controller.Moving == false && controller.Onladder == false)
            {
                controller.MoveAwayFromLadder = true;
                GoAwayFromLadder = true;
            }
        }

        if (Spawns > 0)
        {
            if (controller.Moving == false && controller.Onladder == false)
            {
                controller.MoveAwayFromLadder = true;
                GoAwayFromSpawn = true;
            }
        }

        if (GoAwayFromLadder)
        {
            if (controller.Moving == false )
            {
        
                controller.Moving = true;
              

            }


            if (CanChangeDirection)
            {
                Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                controller.horizontally = !controller.horizontally;
                SpiderHorizontally.transform.Rotate(0, -180, 0);
                HadChangedDirection = true;
                CanChangeDirection = false;
            }


        }


        if (GoAwayFromSpawn)
        {


            if (controller.Moving == false)
            {
           
                controller.Moving = true;

            }





            if (CanChangeDirection)
            {
                Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                controller.horizontally = !controller.horizontally;
                SpiderHorizontally.transform.Rotate(0, -180, 0);
                HadChangedDirection = true;
                CanChangeDirection = false;
            }


        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LadderDown") || other.CompareTag("LadderUp"))
        {

            Ladders++;
        





        }

        if (other.CompareTag("Spawn"))
        {

            Spawns++;
       

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





    IEnumerator ReactivateDirectionChanger(int time)
    {

        yield return new WaitForSeconds(time);
        CanChangeDirection = true;
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("LadderDown") || other.CompareTag("LadderUp"))
        {
            Ladders--;
            if (controller.Moving == true && GoAwayFromLadder == true)
            {
                Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");


                if (Ladders == 0)
                {
                    controller.MoveAwayFromLadder = false;
                    controller.Moving = false;

                    GoAwayFromLadder = false;

              


                    if (HadChangedDirection)
                    {
                        controller.horizontally = !controller.horizontally;
                        SpiderHorizontally.transform.Rotate(0, -180, 0);
                        HadChangedDirection = false;
                    }
                }
            }

        }


        if (other.CompareTag("Spawn"))
        {
            Spawns--;
            if (controller.Moving == true && GoAwayFromSpawn == true)
            {
                Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");


                if (Spawns == 0)
                {
                    controller.MoveAwayFromLadder = false;
                    controller.Moving = false;

                    GoAwayFromSpawn = false;




                    if (HadChangedDirection)
                    {
                        controller.horizontally = !controller.horizontally;
                        SpiderHorizontally.transform.Rotate(0, -180, 0);
                        HadChangedDirection = false;
                    }
                }
            }

        }

    }

}