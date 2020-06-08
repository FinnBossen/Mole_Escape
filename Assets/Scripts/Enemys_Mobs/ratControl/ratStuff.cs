using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratStuff : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rat;
    private ratController RatController;
    public int GroundNumber = 0;

    void Start()
    {
        RatController = rat.GetComponent<ratController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, collision.gameObject.transform.position.z);
           
            GroundNumber++;

            if(GroundNumber > 0)
            {
                RatController.isGrounded = true;
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
                RatController.isGrounded = true;
            }
            else
            {
                RatController.isGrounded = false;
            }
        }
    }
}
