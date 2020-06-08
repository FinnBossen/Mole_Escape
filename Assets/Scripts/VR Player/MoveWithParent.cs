using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithParent : MonoBehaviour
{
    GameObject ParentTransform;
    // Start is called before the first frame update
    void Start()
    {
        ParentTransform = gameObject.transform.parent.gameObject;
        gameObject.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = ParentTransform.transform.position;
        gameObject.transform.rotation = ParentTransform.transform.rotation;

    }
}
