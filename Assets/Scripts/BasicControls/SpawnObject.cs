using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    public Transform spawnpoint;
    public GameObject prefab;
    private bool barrel = false;

	void Start ()
    {
        		
	}
	
	void Update ()
    {
		
	}    

    public void Spawn()
    {
        if(!barrel)
        {
            Instantiate(prefab, spawnpoint.position, spawnpoint.rotation);
            barrel = true;
            Debug.Log("BARREL");  
        }        
        else if (barrel)
        {
            barrel = false;
        }
               
    }
}
