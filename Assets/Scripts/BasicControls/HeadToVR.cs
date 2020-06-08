using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadToVR : MonoBehaviour {

    public GameObject cam;
    public GameObject model;

    void Start()
    {

    }

    void Update()
    {
        model.transform.position = new Vector3(cam.transform.position.x, 7f, cam.transform.position.z + 0.65f);
        model.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x, cam.transform.eulerAngles.y, cam.transform.eulerAngles.z);
    }


}
