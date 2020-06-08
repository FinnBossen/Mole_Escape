using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZielScheibe : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GoUp;
    private voxelloop GoUpAnimation;
    private voxelloop OwnAnimation;
    void Start()
    {
        GoUpAnimation = GoUp.GetComponent<voxelloop>();
        OwnAnimation = gameObject.GetComponent<voxelloop>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Throwable")|| other.CompareTag("Banana"))
        {
            
            GameManager.CoinCount++;
            OwnAnimation.animActivated = false;
            OwnAnimation.DeactivateAll();
            GoUpAnimation.animActivated = true;
           
            StartCoroutine(WaitSeconds(25));

        }
    }

    IEnumerator WaitSeconds(int WaitTime)
    {
        print(Time.time);
        yield return new WaitForSeconds(WaitTime);
        OwnAnimation.animActivated = true;
        print(Time.time);
     
    }
}
