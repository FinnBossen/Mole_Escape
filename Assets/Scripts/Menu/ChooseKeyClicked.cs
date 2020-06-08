using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseKeyClicked : MonoBehaviour
{
    public List<GameObject> PlayerKeys;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseKeyCklicked()
    {
        for (var i = 0; i <PlayerKeys.Count; i++)
        {
            PlayerKeys[i].transform.GetChild(0).gameObject.GetComponent<ChangeKey>().CanChange = false;
        
        }
        gameObject.transform.GetChild(0).gameObject.GetComponent<ChangeKey>().CanChange = true;
    }
}
