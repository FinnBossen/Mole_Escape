using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatEnemyHit : MonoBehaviour
{
    public GameObject Rat;
    public GameObject MovingTrigger;
    private ratController RatController;

    // Start is called before the first frame update
    void Start()
    {
        RatController = MovingTrigger.GetComponent<ratController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickAxe")|| other.CompareTag("Torch"))
        {


            RatController.Ratlives--;
            RatController.HitEffect();


            if (RatController.Ratlives == 0)
            {
                Destroy(Rat);
            }

        }
    }
}
