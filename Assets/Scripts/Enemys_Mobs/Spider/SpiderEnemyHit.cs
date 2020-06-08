using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemyHit : MonoBehaviour
{
    public GameObject Spider;
    public GameObject LookingTrigger;
    private SpiderController spiderController;

    // Start is called before the first frame update
    void Start()
    {
        spiderController = LookingTrigger.GetComponent<SpiderController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickAxe")|| other.CompareTag("Torch"))
        {


            spiderController.SpiderLives--;
            spiderController.HitEffect();


            if (spiderController.SpiderLives == 0)
            {
                Destroy(Spider);
            }

        }
    }
}


