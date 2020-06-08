using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class VoxelAnimation : MonoBehaviour
{
    public GameObject otherStuff;
    public bool animActivated;
    public GameObject[] frames = new GameObject[2];
    private float animationSpeed;
    bool firsttime = true;

    public float Speed = 0.1f;


    private int arrayPos = 0;

    void Start()
    {

        animationSpeed = Speed;

    }


    void Update()
    {
        if (animActivated)
        {
            if (firsttime)
            {
                frames[0].SetActive(true);
                firsttime = false;
            }
            animationSpeed -= Time.deltaTime;
            if (otherStuff != null)
            {
                otherStuff.SetActive(false);
            }
            if (animationSpeed < 0)
            {

                UpdateMesh();

                animationSpeed = Speed;
            }
        }
        else
        {
            firsttime = true;

            if (otherStuff != null)
            {
                otherStuff.SetActive(true);
            }
           
            for (int i = 0; i < frames.Length; i++)
            {
                
                frames[i].SetActive(false);
            }

        }



    }

    void UpdateMesh()
    {



        if (arrayPos >= frames.Length - 1)
        {
            frames[arrayPos].SetActive(false);
            arrayPos = 0;
        }
        else
        {
            frames[arrayPos].SetActive(false);
            arrayPos += 1;
        }
        frames[arrayPos].SetActive(true);

    }
}