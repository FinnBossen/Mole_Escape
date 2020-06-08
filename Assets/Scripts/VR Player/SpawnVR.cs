using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVR : MonoBehaviour
{
    public GameObject mcpPrefab;
    public GameObject Gespawned;
 
void Awake()
    {

   
        
            DontDestroyOnLoad(this);

            if (FindObjectsOfType(GetType()).Length > 1)
            {
                Destroy(gameObject);
            }
        
        if (!GameObject.Find("MCP"))
        {
            GameObject mcpTmp = Instantiate(mcpPrefab, gameObject.transform.position, Quaternion.identity);
            mcpTmp.name = "VR";
            Gespawned = mcpTmp;
            Destroy(gameObject);
        }

  
    
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
