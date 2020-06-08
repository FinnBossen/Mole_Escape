using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFire : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.0f;
    public float rotateSpeed = 1.0f;
    public List<GameObject> goPosition = new List<GameObject>();
    private List<Vector3> goToPosition = new List<Vector3>();
    private voxelloop theFire;
    public bool startPath = true;
    private voxelloop Explosion;
    private bool Explode = false;
    public bool StartOnCart = false;
    public GameObject Collider;

    // Start is called before the first frame update
    void Start()
    {
        theFire = gameObject.GetComponent<voxelloop>();
        Explosion = gameObject.transform.parent.gameObject.transform.GetChild(6).gameObject.GetComponent<voxelloop>();
     

        /* Erstmal weg calculiert jetzt jeden frame vllt besser wenn vorgespeichert. Ging aber dann nichtmehr lokal innerhalt des Dynamit Objects.
        for (int i = 0; i <= goPosition.Count; i++)
        {
            goToPosition.Add(goPosition[i].gameObject.transform.localPosition);
        }
        */
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
        if (startPath && !StartOnCart) {
        
            if (goPosition.Count != 0) {

        float step = speed * Time.deltaTime;
        float stepRotate = rotateSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, goPosition[0].gameObject.transform.position, step);
        Vector3 targetDir = goPosition[0].gameObject.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, stepRotate, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);



        if (Vector3.Distance(transform.position, goPosition[0].gameObject.transform.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            goPosition.RemoveAt(0);
        }
        }
        else
        {
                if (!Explode) {
                    gameObject.transform.parent.gameObject.transform.rotation = Quaternion.identity;
                    gameObject.transform.parent.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    gameObject.transform.parent.gameObject.transform.GetChild(7).gameObject.SetActive(true);
                    Explosion.animActivated = true;
                    Explode = true;
                }
                else if (Explode && Explosion.animActivated == false )
                {
                   
                    Destroy(gameObject.transform.parent.gameObject);
                    Destroy(Collider);
                    Destroy(gameObject);
                }

            }
        }

       
    }





    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LuntFire" || other.tag == "StartLunt")
        {
            
            StartCoroutine(ActivateAfterTime(1.2f));
        }

        if (other.tag == "invisible" && (gameObject.tag == "LuntFire" || gameObject.tag == "LuntFire"))
        {

            StartCoroutine(InvisibleAfterTime(0.5f, other));
        }
    }

    IEnumerator ActivateAfterTime(float time)
    {
      
        yield return new WaitForSeconds(time);
        startPath = true;
  
        gameObject.tag = "LuntFire";
      
        theFire.animActivated = true;
       
       

    }


    IEnumerator InvisibleAfterTime(float time, Collider other)
    {

        yield return new WaitForSeconds(time);
        other.gameObject.GetComponent<Renderer>().enabled = true;

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CartStop") && StartOnCart)
        {
            StartOnCart = false;
        }
    }


}
