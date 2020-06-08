using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnExplosiveBarrel : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Barrel;
    public GameObject numberScreen;
    private TextMeshPro BarrelFloor;
    public Transform[] path;
    bool OnRail = false;
    int currentBarrel = 0;
    string name;
    public bool newBarrel = false;
    bool cartIsPlaced = false;
    public int SpawnCost = 4;
    private GameObject newObject;
    public GameObject Cost;
    TextMeshPro CostText;

    void Start()
    {
        SpawnCost = GameManager.MineCartExplosionCost;

        CostText = Cost.GetComponent<TextMeshPro>();
        BarrelFloor = numberScreen.GetComponent<TextMeshPro>();

        CostText.text = SpawnCost.ToString();
        
    }

 
    // Update is called once per frame
    void Update()
    {
        if (newBarrel)
        {
            SpawneBarrel();
            newBarrel = false;
        }

        if (OnRail)
        {
            if (newObject !=null) { 
            newObject.transform.Rotate(-5, 0, 0, Space.World);
            }
        }
    }

    void OnDrawGizmos()
    {
        iTween.DrawPath(path);
    }

    void tween(GameObject Barrel)
    {
        name = Barrel.name + currentBarrel;
        iTween.MoveTo(Barrel, iTween.Hash("name",name,"path", path, "time", 2.5f, "orienttopath", false, "easetype", "linear", "oncomplete", "complete"  ,"oncompletetarget", gameObject));
    }
   public void SpawneBarrel()
    {
        if(gameObject.transform.childCount < 1 && !OnRail && cartIsPlaced && GameManager.CoinCount >= SpawnCost) {

            GameManager.CoinCount = GameManager.CoinCount - SpawnCost;

             newObject = (GameObject)Instantiate(Barrel, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);


            newObject.name = BarrelFloor.text;
            OnRail = true;
            tween(newObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NonVRTakeASeat"))
        {
            if (OnRail)
            {
                OnRail = false;
            }
            cartIsPlaced = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NonVRTakeASeat"))
        {
           if (OnRail)
            {
                OnRail = false;
            }
            cartIsPlaced = false;
        }
    }

    void complete()
    {
        Debug.Log("adareaddd Complte");
    
        iTween.StopByName(name);
        Destroy(newObject);
     
    }
}
