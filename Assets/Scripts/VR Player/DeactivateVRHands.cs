using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateVRHands : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Example());
    }



    // Update is called once per frame


    IEnumerator Example()
    {
       
        yield return new WaitForSeconds(5);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
        gameObject.transform.GetChild(6).gameObject.SetActive(false);
        gameObject.transform.GetChild(7).gameObject.SetActive(false);
    }
}
