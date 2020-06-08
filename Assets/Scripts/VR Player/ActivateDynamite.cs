using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ActivateDynamite : MonoBehaviour
{

    private MovingFire fire;
    private bool HandInsideTrigger;
    private voxelloop FireAnim;
    public SteamVR_Action_Boolean TriggerClick;
    private SteamVR_Input_Sources inputSource;

    void Start()
    {
        FireAnim = gameObject.GetComponent<voxelloop>();
        fire = gameObject.GetComponent<MovingFire>();
    }

    private void OnEnable()
    {
        TriggerClick.AddOnStateDownListener(Press, inputSource);
    }

    private void OnDisable()
    {
        TriggerClick.RemoveOnStateDownListener(Press, inputSource);
    }

    private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (HandInsideTrigger)
        {
            FireAnim.animActivated = true;
            fire.startPath = true;
        }
        else
        {
            Debug.Log("No Hand Near Dynamite");
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            HandInsideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            HandInsideTrigger = false;
        }
    }
}
