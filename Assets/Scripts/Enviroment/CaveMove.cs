using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform StartPosition;
    public Transform EndPosition;
    public bool isActivated = false;
    public bool Moving;
    private bool Direction = true;
    public float speed = 2f;
    public float CaveDuration = 10f;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Moving)
        {
            if (Direction)
            {
                float step = speed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, EndPosition.position, step);

                // Check if the position of the cube and sphere are approximately equal.
                if (Vector3.Distance(transform.position, EndPosition.position) < 0.001f)
                {
                    // Swap the position of the cylinder.
                    Moving = false;
                    Direction = !Direction;
                }
            }
            else
            {
                float step = speed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, StartPosition.position, step);

                // Check if the position of the cube and sphere are approximately equal.
                if (Vector3.Distance(transform.position, StartPosition.position) < 0.001f)
                {
                    // Swap the position of the cylinder.
                    Moving = false;
                    Direction = !Direction;
                }
            }
     
        }

    
    }

    public void CaveActivated()
    {
        Moving = true;
        isActivated = true;
        StartCoroutine(WaitTillReset(CaveDuration));
    }

    IEnumerator WaitTillReset(float Zeit)
    {
       
        yield return new WaitForSeconds(Zeit);
        Moving = true;
        isActivated = false; 

    }
}
