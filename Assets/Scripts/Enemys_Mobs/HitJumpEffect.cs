using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitJumpEffect : MonoBehaviour
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
                EnemyRigid.AddForce((Vector3.up + Vector3.right) * 150);
            }
            else
            {
                EnemyRigid.AddForce((Vector3.up - Vector3.right) * 150);
            }
        }

    }
}
