using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldNuggetSpawner : MonoBehaviour
{

    public GameObject GoldNugget;
    private Transform CheckChild;
    private float RespawnTime = 13;
    private float CoinPercentage = 0.7f;
    private float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.value < CoinPercentage)
        {
            Destroy(this.gameObject);

        }
        timeLeft = RespawnTime;
        CheckChild = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {

       
     
        if (CheckChild.childCount == 0)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Instantiate(GoldNugget, gameObject.transform.position, Quaternion.identity).transform.parent = gameObject.transform;
                timeLeft = RespawnTime;
            }
       
        }
    }
    IEnumerator RespawnAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
    
        yield return null;
        
    }

}
