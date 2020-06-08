using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThrowable : MonoBehaviour {

    bool IgnoreYourOwn = false;
    int HandCount;
    void Start()
    {
        Physics.IgnoreLayerCollision(12, 15);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GameOver"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("PickAxe"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("DestroyThrowable"))
        {
            StartCoroutine(WaitTillDestroy());

        }

        if (other.gameObject.CompareTag("Hand"))
        {
            
            IgnoreYourOwn = true;
            HandCount++;

            if (HandCount == 1)
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
            }

        }


    }
    IEnumerator WaitTillDestroy()
    {
   
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            HandCount--;
         
            if (HandCount == 0) {
                IgnoreYourOwn = false;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
        }

    
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Throwable") && IgnoreYourOwn)
        {
            Physics.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider>());


        }

        if (collision.gameObject.CompareTag("Banana") && IgnoreYourOwn)
        {
            Physics.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider>());


        }
        if (collision.gameObject.CompareTag("Dynamite") && IgnoreYourOwn)
        {
            Physics.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider>());


        }
        if (collision.gameObject.CompareTag("DestroyThrowable"))
        {
            StartCoroutine(WaitTillDestroy());

        }


    }
}
