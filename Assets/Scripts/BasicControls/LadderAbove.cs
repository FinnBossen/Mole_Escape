using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderAbove : MonoBehaviour {


    Ladder ladder;
    // Use this for initialization
    void Start()
    {
        ladder = gameObject.GetComponentInParent(typeof(Ladder)) as Ladder;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ladder.pathNodeIndex = 3;
        }

}
}
