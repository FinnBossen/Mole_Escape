using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject teleportTo;

    private Vector3 teleportPosition;

    // Start is called before the first frame update
    void Start()
    {
        teleportPosition = teleportTo.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TheKart"))
        {
        
           
            other.transform.position = teleportPosition;
        }
    }
}
