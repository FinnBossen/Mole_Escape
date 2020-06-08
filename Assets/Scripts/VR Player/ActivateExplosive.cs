using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateExplosive : MonoBehaviour
{

    public GameObject ExplosiveBarrel;
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ExplosiveBarrel") && gameObject.transform.childCount < 1)
        {
            GameObject explosive = (GameObject)Instantiate(ExplosiveBarrel, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            explosive.transform.GetChild(2).GetComponent<MovingFire>().StartOnCart = true;

            explosive.transform.Rotate(0, 90, 0);
            explosive.transform.parent = gameObject.transform;
          
            switch (other.gameObject.name)
            {
                case "0":
                    explosive.transform.GetChild(2).GetComponent<MovingFire>().speed = 0.40f;
                    break;
                case "1":
                    explosive.transform.GetChild(2).GetComponent<MovingFire>().speed = 0.13f;
                    break;
                case "2":
                    explosive.transform.GetChild(2).GetComponent<MovingFire>().speed = 0.075f; 
                    break;
                case "3":
                    explosive.transform.GetChild(2).GetComponent<MovingFire>().speed = 0.053f;
                    break;
                case "4":
                    explosive.transform.GetChild(2).GetComponent<MovingFire>().speed = 0.042f;
                    break;
                case "5":
                    explosive.transform.GetChild(2).GetComponent<MovingFire>().speed = 0.034f;
                    break;
            }
         

        }
    }
}
