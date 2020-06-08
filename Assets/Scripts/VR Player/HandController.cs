using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using TMPro;
using Valve.VR.InteractionSystem;

public class HandController : MonoBehaviour
{
    // Start is called before the first frame update



    public GameObject SpiderCost;
    public GameObject RatCost;
    private TextMeshPro SpiderCostText;
    private TextMeshPro RatCostText;
    public SteamVR_Action_Vector2 touchPad;
    public SteamVR_Input_Sources Hand;//Set Hand To Get Input From
    public SteamVR_Action_Boolean TriggerClick;
    public GameObject NormalHand;
    public GameObject BookHand;
    public GameObject GrabHand;
    public GameObject CoinHand;
    public GameObject SpellHand;
    private int rat = 0;
    private int spider = 0;
    public GameObject GreyOptions;
    public GameObject BookhandHighlight;
    public GameObject NormalHighlight;
    public GameObject CoinHandHighlight;
    public Vector2 m;
    public GameObject Lunt = null;
    private AudioSource audio;
    public AudioClip LuntOn;
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        updateInput();
    }


    private void OnEnable()
    {
        TriggerClick.AddOnStateDownListener(Press, Hand);
    }

    private void OnDisable()
    {
        TriggerClick.RemoveOnStateDownListener(Press, Hand);
    }


    void updateInput()
    {
        m = touchPad.GetAxis(Hand);

        Debug.Log(m);

        if ((m.x > 0.3 || m.x < -0.3 || m.y > 0.3 || m.y < -0.3 )&& !SpellHand.activeInHierarchy)
        {
            GreyOptions.SetActive(true);
        }
        else
        {
            if (BookhandHighlight.activeInHierarchy)
            {
                if (!SpellHand.activeInHierarchy)
                {
                    Debug.Log("Trigger Pressed HandControl Bookhand");
                    NormalHand.SetActive(false);
                    GrabHand.SetActive(false);
                    BookHand.SetActive(true);
                    CoinHand.SetActive(false);
                }
            }
            else if (NormalHighlight.activeInHierarchy)
            {
                if (!SpellHand.activeInHierarchy)
                {
                    Debug.Log("Trigger Pressed HandControl NormalHand");
                    NormalHand.SetActive(true);
                    GrabHand.SetActive(false);
                    BookHand.SetActive(false);
                    CoinHand.SetActive(false);
                }
            }
            GreyOptions.SetActive(false);
            NormalHighlight.SetActive(false);
            BookhandHighlight.SetActive(false);
            CoinHandHighlight.SetActive(false);
        }

        if ((m.x < -0.8 && m.y < 0.3 && m.y > -0.3) && !SpellHand.activeInHierarchy)
        {
            NormalHighlight.SetActive(false);
            BookhandHighlight.SetActive(true);
            CoinHandHighlight.SetActive(false);
        }
        else if ((m.x > 0.8 && m.y < 0.3 && m.y > -0.3) && !SpellHand.activeInHierarchy)
        {
            NormalHighlight.SetActive(true);
            BookhandHighlight.SetActive(false);
            CoinHandHighlight.SetActive(false);
        }
 
 

    }


    private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

        if (!BookHand.activeInHierarchy && !SpellHand.activeInHierarchy)
        {
          

            if (GrabHand.activeInHierarchy)
            {
                GrabHand.SetActive(false);
                NormalHand.SetActive(true);
                CoinHand.SetActive(false);
            }
            else
            {
                Debug.Log("Trigger Pressed HandControl GrabHand");
                GrabHand.SetActive(true);
                NormalHand.SetActive(false);
                CoinHand.SetActive(false);
            }
        }

        if (Lunt!=null)
        {
            Lunt.GetComponent<MovingFire>().startPath = true;
            Lunt.GetComponent<voxelloop>().animActivated = true;
            Lunt.tag = "LuntFire";
            audio.PlayOneShot(LuntOn, 1F);
        }


        if (rat > 0)
        {
            if (GameManager.CoinCount > 3 && !SpellHand.activeInHierarchy)
            {
                GameManager.CoinCount = GameManager.CoinCount -4;
                CoinHand.SetActive(false);
                BookHand.SetActive(false);
                NormalHand.SetActive(false);
                GrabHand.SetActive(false);
                SpellHand.SetActive(true);
                SpellHand.transform.GetChild(0).GetChild(2).GetComponent<WandScript>().ChoosenEnemy = 0;
            }
            else
            {
                RatCostText.color = new Color32(255, 0, 0, 255);
                StartCoroutine(ResetToWhite());
            }
        }
        if(spider > 0) { 
        if (GameManager.CoinCount > 5 && !SpellHand.activeInHierarchy)
        {
            GameManager.CoinCount = GameManager.CoinCount - 6; ;
                CoinHand.SetActive(false);
                BookHand.SetActive(false);
                NormalHand.SetActive(false);
                GrabHand.SetActive(false);
                SpellHand.SetActive(true);

            SpellHand.transform.GetChild(0).GetChild(2).GetComponent<WandScript>().ChoosenEnemy = 1;
            }
            else
            {
               
                SpiderCostText.color = new Color32(255, 0, 0, 255);
                StartCoroutine(ResetToWhite());
            }
        }
    }

    IEnumerator ResetToWhite()
    {

        yield return new WaitForSeconds(1.5f);
        RatCostText.color = new Color32(255, 255, 255, 255);
        SpiderCostText.color = new Color32(255, 255, 255, 255);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("rat"))
        {
            rat++;
        }

        if (other.CompareTag("Spider"))
        {
            spider++;
         
        }

        if (other.CompareTag("StartLunt"))
        {
            Lunt = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("rat"))
        {
            rat--;
        }

        if (other.CompareTag("Spider"))
        {
            spider++;
        }


        if (other.CompareTag("StartLunt"))
        {
            Lunt = null;
        }
    }
}
