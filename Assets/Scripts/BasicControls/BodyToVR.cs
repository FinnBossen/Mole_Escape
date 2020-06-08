using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyToVR : MonoBehaviour
{

    public GameObject cam;
    public GameObject model;

    void Start()
    {

    }

    void Update()
    {
        model.transform.position = new Vector3(cam.transform.position.x, +4.7f, cam.transform.position.z + 0.5f);
        model.transform.eulerAngles = new Vector3(model.transform.eulerAngles.x, cam.transform.eulerAngles.y, model.transform.eulerAngles.z);
    }

}