using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightSpawnable : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject WhiteWalkingHorizontal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand")){
          
                WhiteWalkingHorizontal.layer = 12;
              

                for (int i = 0; i < WhiteWalkingHorizontal.transform.childCount; i++)
                {
                    WhiteWalkingHorizontal.transform.GetChild(i).gameObject.layer = 12;
                    for (int a = 0; a < WhiteWalkingHorizontal.transform.GetChild(i).gameObject.transform.childCount; a++)
                    {
                        WhiteWalkingHorizontal.transform.GetChild(i).gameObject.transform.GetChild(a).gameObject.layer = 12;
                    }


                }

        
           

                
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {

            WhiteWalkingHorizontal.layer = 13;


            for (int i = 0; i < WhiteWalkingHorizontal.transform.childCount; i++)
            {
                WhiteWalkingHorizontal.transform.GetChild(i).gameObject.layer = 13;
                for (int a = 0; a < WhiteWalkingHorizontal.transform.GetChild(i).gameObject.transform.childCount; a++)
                {
                    WhiteWalkingHorizontal.transform.GetChild(i).gameObject.transform.GetChild(a).gameObject.layer = 13;
                }


            }





        }
    }

}
