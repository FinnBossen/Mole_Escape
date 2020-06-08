using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpikeState : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isStateDestroyer = false;
        public string reactTag;
    public GameObject[] States;
    public AudioClip SpikeDestroyed;
    public GameObject StateSwitcherObject;
    private StateSwitcher stateSwitcher;
    private int currentState = 0;
    public GameObject ZielScheibe;
    public float PercentageOfSpikes;
    public AudioSource audio;
    private void Start()
    {
        audio = gameObject.transform.parent.GetChild(10).gameObject.GetComponent<AudioSource>();

        if (isStateDestroyer)
        {
            stateSwitcher = StateSwitcherObject.GetComponent<StateSwitcher>();
        }
        if (gameObject.name == "Stone Spike") { 
        if (Random.value > PercentageOfSpikes)
        {
                ZielScheibe.SetActive(true);
                gameObject.SetActive(false);
          
        }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == reactTag && other.isTrigger)
        {

            currentState++;
            for (int i = 0; i < States.Length; i++)
            {
                States[i].SetActive(false);

                if (i == currentState)
                {
                    States[currentState].SetActive(true);
                }
                if(currentState == States.Length - 1)
                {
                  
                    if (!isStateDestroyer) { 
                    GetComponent<Collider>().enabled = false;
                    }
                    else
                    {
                        audio.PlayOneShot(SpikeDestroyed, 1F);
                        stateSwitcher.timeLeft = -1;
                    }
                }
            }

            Debug.Log("Aua my damage State is" + currentState);

            if (!isStateDestroyer)
            {
                Destroy(other.gameObject);
            }
          
         
        }
    }

  
}
