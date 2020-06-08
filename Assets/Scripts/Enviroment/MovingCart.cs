using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;


public class MovingCart : MonoBehaviour
{

    public float speed = 1.0f;
    public List<Vector3> goToPosition = new List<Vector3>();
    private bool firstTarget = false;
    private bool cartStop = false;
    public float stopTime = 10;
    private float countdown;
    private voxelloop driveAnimation;
    public GameObject openAnimationObject;
    public GameObject closingAnimationObject;
    private voxelloop openAnimation;
    private voxelloop closingAnimation;
    private bool once = true;
    public GameObject vrTeleport;
    private TeleportPoint teleport;

    // Start is called before the first frame update
    void Start()
    {
        TeleportPoint teleport = vrTeleport.GetComponent<TeleportPoint>();
        driveAnimation = gameObject.GetComponent<voxelloop>();
        openAnimation = openAnimationObject.GetComponent<voxelloop>();
        closingAnimation = closingAnimationObject.GetComponent<voxelloop>();
        countdown = stopTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!cartStop) { 
        if(firstTarget) {
            
        
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,goToPosition[0], step);
            Vector3 targetDir = goToPosition[0] - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);



            if (Vector3.Distance(transform.position, goToPosition[0]) < 0.001f)
            {
                // Swap the position of the cylinder.
                goToPosition.RemoveAt(0);
            }
        }
        }

        if (cartStop)
        {
          
         countdown -= Time.deltaTime;

            if (countdown < 0)
            {
             
                if(once)
                {
                    closingAnimation.animActivated = true;
                    once = false;
                };
              

                if (closingAnimation.animActivated == false) {
                driveAnimation.animActivated = true;
                Debug.Log("cartGoes");
                cartStop = false;
                countdown = stopTime;
                    once = true;
                  //  teleport.markerActive = false;
                }

            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KartMovingPoint"))
        {
           
            firstTarget = true;
          
            goToPosition.Add(other.transform.position);
        }

        if (other.CompareTag("CartStop"))
        {
           // teleport.markerActive = true;
            driveAnimation.animActivated = false;
           
            cartStop = true;

            openAnimation.animActivated = true;
        }
    }




}
