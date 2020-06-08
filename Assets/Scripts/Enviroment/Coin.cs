using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //adjust this to change speed
    float speed = 1.8f;
    //adjust this to change how high it goes
    float height = 0.0007f;
    public GameObject RotateObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotateObject.transform.Rotate(0, 4.5f, 0, Space.World);
        Vector3 pos = transform.position;
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(pos.x, newY, pos.z);



    }
}
