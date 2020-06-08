using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obscureObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        // get all renderers in this object and its children:

        gameObject.GetComponent<Renderer>().material.renderQueue = 4000;
   
    }

 
}
