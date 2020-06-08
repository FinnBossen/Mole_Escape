using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getLookingRotation : MonoBehaviour
{
    public List<Vector3> LookPoints = new List<Vector3>();


    private void OnTriggerEnter(Collider other)
    {

   
        if (other.CompareTag("KartMovingPoint"))
        {
            Debug.Log("Got RotationPoint");

            if(LookPoints.Count == 0)
            {
                LookPoints.Add(other.transform.position);
            }
            else if(other.transform.position != LookPoints[0] && !LookPoints.Contains(other.transform.position)) {
                LookPoints.Add(other.transform.position);
            }
        }

    }

}
