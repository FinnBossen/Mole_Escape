using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutonPathSpider : MonoBehaviour
{
    public Transform[] path;
    public Transform[] fallback;
    public float percentage;
    public bool Onladder = false;
    public GameObject LadderSpiderVisible;
    public GameObject WalkingSpiderVisible;
    public int SpiderLives = 1;
    public int GroundNumber = 0;


    public GameObject SpiderTrigger;
    public SpiderController spiderController;

    private void Start()
    {
        Onladder = false;
        spiderController = SpiderTrigger.GetComponent<SpiderController>();

        fallback = new Transform[1];


    }




    private void FixedUpdate()
    {

        if (Onladder)
        {
            iTween.PutOnPath(gameObject, path, percentage);

            percentage = percentage + 0.0065f;

            if (percentage <= 0f || percentage >= 1f)
            {

                spiderController.Moving = true;
                Onladder = false;

                spiderController.UseLadder = false;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                spiderController.Onladder = false;
                percentage = 0;
            }



        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LadderUp"))
        {
            if (spiderController.UseUpLadder)
            {
                if (spiderController.UseLadder)
                {
                   
                    if (!Onladder)
                    {
                        path = new Transform[other.gameObject.transform.childCount];
                        int i = 0;
                        foreach (Transform child in other.gameObject.transform)
                        {
                            path[i] = child;
                            i++;
                        };
                       
                        percentage = 0;
                        Onladder = true;
                        spiderController.Moving = false;
                        spiderController.Onladder = true;
                        gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        LadderSpiderVisible.SetActive(true);
                        WalkingSpiderVisible.SetActive(false);
                    }

                }
            }else if (spiderController.UseDownLadder)
            {
                StartCoroutine(WaitALittle());
            }

        }

        if (other.CompareTag("LadderDown"))
        {
            if (spiderController.UseDownLadder)
            {
                if (spiderController.UseLadder)
                {
                    
                    if (!Onladder)
                    {
                        
                       
                        path = new Transform[other.gameObject.transform.childCount];
                        int i = 0;
                        foreach (Transform child in other.gameObject.transform)
                        {
                            path[i] = child;
                            i++;
                        };
                        percentage = 0;
                        Onladder = true;
                        spiderController.Moving = false;
                        spiderController.Onladder = true;
                        gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        LadderSpiderVisible.SetActive(true);
                        WalkingSpiderVisible.SetActive(false);

                    }

                }
            }else if (spiderController.UseUpLadder)
            {
                StartCoroutine(WaitALittle());
            }
        }




    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, collision.gameObject.transform.position.z);
            GroundNumber++;
                if(GroundNumber> 0) { 
            spiderController.isGrounded = true;
            }

        }

        if (collision.gameObject.layer == 0)
        {
            Physics.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider>());
        }

        if (collision.gameObject.layer == 12)
        {
            Physics.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider>());
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

            GroundNumber--;
            if (GroundNumber > 0)
            {
                spiderController.isGrounded = true;
            }
            else
            {
                spiderController.isGrounded = false;
            }

        }
    }

    IEnumerator WaitALittle()
    {
        yield return new WaitForSeconds(0.5f);
        LadderSpiderVisible.SetActive(false);
        WalkingSpiderVisible.SetActive(true);
    }

  
}