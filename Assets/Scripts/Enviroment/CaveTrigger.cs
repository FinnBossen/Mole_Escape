using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveTrigger : MonoBehaviour
{
    voxelloop TriggerActivated;
    voxelloop TriggerReset;
    public float TimeTillReset = 5f;
    public GameObject reset;
    public GameObject Cave;
    private CaveMove CaveController;
    private AudioSource audio;
    public AudioClip SchalterOn;

    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
      CaveController = Cave.GetComponent<CaveMove>();
      TriggerActivated = gameObject.GetComponent<voxelloop>();
      TriggerReset =  reset.GetComponent<voxelloop>();
    }



    public void ActivateCave()
    {
        if (!CaveController.isActivated && !CaveController.Moving) { 
        TriggerActivated.animActivated = true;
        TriggerReset.animActivated = false;
        StartCoroutine(WaitTillReset(TimeTillReset));
            CaveController.CaveActivated();
            audio.PlayOneShot(SchalterOn, 1F);
        }
        else
        {
            Debug.Log("Cave is Activated");
        }
    }


    IEnumerator WaitTillReset(float Zeit)
    {
     
        yield return new WaitForSeconds(Zeit);
        TriggerActivated.animActivated = false;
        TriggerReset.animActivated = true;
    }
}
