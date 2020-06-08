using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchrankenController : MonoBehaviour
{

    public GameObject SchrankeFrames;
    private voxelloop SchrankenAnimarion;
    private AudioSource audio;
    public AudioClip OpenSound;
    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        SchrankenAnimarion = SchrankeFrames.GetComponent<voxelloop>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TheKart"))
        {
            audio.PlayOneShot(OpenSound, 1F);
            SchrankenAnimarion.animActivated = true;
        } 
    }
}
