using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveWhen : MonoBehaviour
{

    public GameObject Activated2;
    public GameObject Activated;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Activated.activeInHierarchy && Activated2.activeInHierarchy)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
