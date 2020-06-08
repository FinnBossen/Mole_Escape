using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LeftHit : MonoBehaviour
{
    public bool direction = false;
    public GameObject EnemyObject;
    private Rigidbody EnemyRigid;
    // Start is called before the first frame update
    void Start()
    {
      EnemyRigid = EnemyObject.GetComponent<Rigidbody>();
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PickAxe"))
        {
            if (direction)
            {
               EnemyRigid.AddForce((Quaternion.AngleAxis(45, transform.right) * transform.forward) * 20000);
            }
            else
            {
                EnemyRigid.AddForce((Quaternion.AngleAxis(-45, transform.right) * transform.forward) * 20000);
            }
        }
     
    }
}
