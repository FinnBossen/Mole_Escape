using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;



public class ChangeKey : MonoBehaviour
{
    // Start is called before the first frame update
    public bool CanChange = false;
    public TextMeshProUGUI KeyCode;
    public KeyCode ChoosenKey;
    private ChooseKeyClicked chooseKeyClicked;
    public List<GameObject> PlayerKeys;
    public List<ChangeKey> Keys;


 
    void Start()
    {

        chooseKeyClicked = gameObject.transform.parent.GetComponent<ChooseKeyClicked>();
        PlayerKeys = chooseKeyClicked.PlayerKeys;

        for (var i = 0; i < PlayerKeys.Count; i++)
        {
            Keys.Add(PlayerKeys[i].transform.GetChild(0).transform.gameObject.GetComponent<ChangeKey>());
        }

            KeyCode = gameObject.GetComponent<TextMeshProUGUI>();
    
        KeyCode.text = ChoosenKey.ToString();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (CanChange) { 
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey) && vKey.ToString() != "Mouse0")
            {
                    bool isAvaliable = true;

                    for (var i = 0; i < Keys.Count; i++)
                    {
                     if (Keys[i].ChoosenKey == vKey) {
                            isAvaliable = false;
                        }
                    }
                 

                    if (isAvaliable)
                    {
                        ChoosenKey = vKey;
                        KeyCode.text = vKey.ToString();

                    }
                      
            }
        }
        }

       
    }

    
}
