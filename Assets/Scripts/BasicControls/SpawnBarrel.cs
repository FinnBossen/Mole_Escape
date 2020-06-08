using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Valve.VR;

public class SpawnBarrel : MonoBehaviour {

    public GameObject prefab;
    public float SpawnTime = 2f;
    private float delay = 4f;
    private int delayInt;
    public int ThrowableCount = 0;
    private bool SpawnNow = false;
    public int RespawnCost = 1;
    public GameObject Timer;
    private TextMeshPro timeText;
    public GameObject Cost;
    TextMeshPro CostText;
    public Collider otherObject;
    public bool Colliderdestroyed = false;
    public bool HandInside = false;
    public SteamVR_Action_Boolean TriggerClick;
    private SteamVR_Input_Sources inputSource;
    bool isDynamite;
    private void OnEnable()
    {
        TriggerClick.AddOnStateDownListener(Press, inputSource);
    }

    private void OnDisable()
    {
        TriggerClick.RemoveOnStateDownListener(Press, inputSource);
    }

    void Start()
    {
        timeText = Timer.GetComponent<TextMeshPro>();
        delay = SpawnTime;
        CostText = Cost.GetComponent<TextMeshPro>();

        CostText.text = RespawnCost.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(!otherObject || otherObject == null) {
   
            if(!otherObject && !Colliderdestroyed)
            {
                Timer.SetActive(true);
                delay = SpawnTime;
                Colliderdestroyed = true;
            }

        if (delay > 0f || SpawnNow)
        {
             
            delay -= Time.deltaTime;
            delayInt = (int)delay;
            timeText.text = delayInt.ToString();
         

                if (delay <= 0f || SpawnNow)
            {

                    Timer.SetActive(false);
                    Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation);
                    Colliderdestroyed = false;
                    if (SpawnNow)
                    {
                        SpawnNow = false;
                    }
            }
        }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Throwable" || other.gameObject.tag == "Banana" || other.gameObject.tag == "Dynamite")
        {
       

          if(other == otherObject)
            {
                otherObject = null;
                delay = SpawnTime;
                Timer.SetActive(true);
                delayInt = (int)delay;
                timeText.text = delayInt.ToString();
            }
            
        }

        if (other.CompareTag("Hand"))
        {
            HandInside = false;

        }
    }
    private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (HandInside)
        {
            if ( !otherObject) { 
                if(GameManager.CoinCount > RespawnCost) {
            GameManager.CoinCount = GameManager.CoinCount - RespawnCost;
            SpawnNow = true;
                }
                else
                {
                    timeText.color = new Color32(255, 0, 0, 255);
                    CostText.color = new Color32(255, 0, 0, 255);
                    StartCoroutine(ResetToWhite());
                }
            }
        }
       
    }

    IEnumerator ResetToWhite()
    {
      
        yield return new WaitForSeconds(1.5f);
        timeText.color = new Color32(255, 255, 255, 255);
        CostText.color = new Color32(255, 255, 255, 255);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Throwable" || other.gameObject.tag == "Banana" ||other.gameObject.tag == "Dynamite" )
        {
            
            
            if (!otherObject) {
            this.otherObject = other;
            }


            if (otherObject)
            {
                delay = -SpawnTime;
                Timer.SetActive(false);
            }
        

          
        }

        if (other.CompareTag("Hand"))
        {
            if (!other && GameManager.CoinCount >= RespawnCost)
            {
                HandInside = true;
            }
         

        }


    }

}
