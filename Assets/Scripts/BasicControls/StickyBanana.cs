using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBanana : MonoBehaviour {

    private Rigidbody m_Rigidbody;
    private CapsuleCollider capsuleCollider;
    private BoxCollider boxCollider;

    void Start ()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        boxCollider = GetComponent<BoxCollider>();
    }
	
	void Update ()
    {
		if(Application.loadedLevelName == "Menu")
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.tag == "Ground")
        {
            capsuleCollider.enabled = false;
            boxCollider.enabled = true;
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            pos.z = collision.gameObject.transform.position.z;
            m_Rigidbody.isKinematic = true;
            gameObject.transform.rotation = rot;
            gameObject.transform.position = pos;
            Destroy(gameObject);

        }        
    }    
}
