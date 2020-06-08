using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItweenCart : MonoBehaviour
{
    public Transform[] path;
    public float speed = 50;
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
    public Transform explosives;
    public Transform PlayerSeat;
    public GameObject ExplosiveBarrel;
    public GameObject resetPoint;

    void Start()
    {
        explosives = this.gameObject.transform.GetChild(5);
        PlayerSeat = this.gameObject.transform.GetChild(6);
        driveAnimation = gameObject.GetComponent<voxelloop>();
        openAnimation = openAnimationObject.GetComponent<voxelloop>();
        closingAnimation = closingAnimationObject.GetComponent<voxelloop>();
        driveAnimation.animActivated = true;
        tween();
    }


    private void Update()
    {
        float step = 1f * Time.deltaTime;
        Vector3 targetDir = goToPosition[0] - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);



        if (Vector3.Distance(transform.position, goToPosition[0]) < 0.1f)
        {
            // Swap the position of the cylinder.
            goToPosition.RemoveAt(0);
        }


    
    }
    void OnDrawGizmos()
    {
        iTween.DrawPath(path);
    }

    void tween()
    {

     
        iTween.MoveTo(gameObject, iTween.Hash("name", "CartAnim", "path", path, "time", speed, "easetype", "linear", "oncomplete", "complete"));
       
    }

    void reset()
    {

        gameObject.transform.position = resetPoint.transform.position;
        transform.eulerAngles = new Vector3(0, 90, 0);
    }

    void complete()
    {
       
        reset();
        tween();
        
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KartMovingPoint"))
        {

            firstTarget = true;
          
            goToPosition.Clear();
            goToPosition.Add(other.transform.position);

        }

        if (other.CompareTag("ExplosiveBarrel"))
        {
            GameObject explosive = Instantiate(ExplosiveBarrel);
            explosive.transform.parent = explosives.transform;


            switch (other.gameObject.name)
            {
                case "Floor1":
                    explosive.transform.GetChild(2).GetComponent<MovingFire>().speed = 0.04f;
                    break;
                case "Floor2":
                    explosive.transform.GetChild(2).GetComponent<MovingFire>().speed = 0.08f;
                    break;
                case "Floor3":
                    explosive.transform.GetChild(2).GetComponent<MovingFire>().speed = 0.012f;
                    break;
                case "Floor4":
                    explosive.transform.GetChild(2).GetComponent<MovingFire>().speed = 0.016f;
                    break;
                case "Floor5":
                    explosive.transform.GetChild(2).GetComponent<MovingFire>().speed = 0.020f;
                    break;
            }


        }

        if (other.CompareTag("CartStop"))
        {
            // teleport.markerActive = true;
            driveAnimation.animActivated = false;
            Debug.Log("cartStop");
          

            openAnimation.animActivated = true;
            StartCoroutine(StopForSeconds(10f));

        }
      
    }

    IEnumerator StopForSeconds(float time)
    {
        iTween.Pause(gameObject);


  
        yield return new WaitForSeconds(time);
        closingAnimation.animActivated = true;
     
        while (closingAnimation.animActivated == true)
        {
            yield return null;
        }
        driveAnimation.animActivated = true;
        iTween.Resume();


    }
}

