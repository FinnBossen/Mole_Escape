using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisableKey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        gameObject.transform.GetChild(0).GetComponent<ChangeKey>().ChoosenKey = KeyCode.None;
        gameObject.transform.GetChild(0).GetComponent<ChangeKey>().KeyCode.text = "";
    }
}
