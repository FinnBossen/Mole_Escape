using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
   public GameObject DoorAnimObject;
    voxelloop DoorAnim;
    // Start is called before the first frame update
    void Start()
    {
        DoorAnim = DoorAnimObject.GetComponent<voxelloop>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DoorAnim.animActivated = true;
        }

    }
}
