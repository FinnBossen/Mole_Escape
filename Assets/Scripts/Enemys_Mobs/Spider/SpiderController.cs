using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    public GameObject SpiderMeshVertically;
    public GameObject SpiderMeshHorizontally;
    public GameObject Spider;
    public List<GameObject> Players;
    public List<Transform> PlayersTargeted;
    public  int PlayersInsideTrigger = 0;
    public List<Transform> LadderDownInsight;
    public List<Transform> LadderUpInsight;
    public bool vertically= false;
    public bool horizontally = false;
    public bool UseLadder;
    public bool Onladder = false;
    public bool Moving = true;
    public float speed = 6f;
    public bool PlayerInside = false;
    public bool UseUpLadder = false;
    public bool UseDownLadder = false;
    public bool MoveAwayFromLadder = false;
    public GameObject WhiteWalkingHorizontal;
    public GameObject WhiteWalkingVertical;
    public int SpiderLives = 3;
    public bool isGrounded = false;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GameObject.Find("Players").transform.childCount; i++)
        {
            Players[i] = GameObject.Find("Players").transform.GetChild(i).gameObject;
        }

            for (int i = 0; i< Players.Count; i++)
        {

            if (Players[i].activeInHierarchy) { 
            PlayersTargeted.Add(Players[i].transform);
            }
        }
        
    }

    void Awake()
    {
        for (int i = 0; i < GameObject.Find("Players").transform.childCount; i++)
        {
            Players[i] = GameObject.Find("Players").transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < Players.Count; i++)
        {

            if (Players[i].activeInHierarchy)
            {
                PlayersTargeted.Add(Players[i].transform);
            }
        }

    }

    private void FixedUpdate()
    {
        if (isGrounded) {
        if (Moving)
        {

            if (horizontally)
            {
                Spider.transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else
            {
                Spider.transform.Translate(-Vector3.right * speed * Time.deltaTime);
            }
     
        }
        }

    }

    void CheckPlayer()
    {
        for (int i = 0; i < PlayersTargeted.Count; i++)
        {
         
            if (PlayersTargeted[i].GetComponent<NonVRPlayerController>().Dying)
            {
             
                Moving = false;
            }
            else
            {
                Moving = true;
            }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!MoveAwayFromLadder) { 
        if (!Onladder) {
            CheckPlayer();
        if (!PlayerInside)
        {
            UseLadder = true;
            GetClosestEnemyandDirectionHorzizontal(PlayersTargeted, gameObject.transform);

            if (vertically)
                {
                    UseDownLadder =false;
                    UseUpLadder = true;
                GetClosestLadderUp(LadderUpInsight, gameObject.transform);
             
            }
            else
            {
                    UseUpLadder = false;
                    UseDownLadder = true;
                GetClosestLadderDown(LadderDownInsight, gameObject.transform);
            }
        }
        else
        {
            UseLadder = false;
            GetClosestEnemyandDirectionVertically(PlayersTargeted, gameObject.transform);
        }
        }
        }
    }


    void GetClosestLadderUp(List<Transform> Ladders, Transform fromThis)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = fromThis.position;
        foreach (Transform potentialTarget in Ladders)
        {
          
                Vector3 directionToTarget = potentialTarget.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget;
                }
            
        }

        if (bestTarget == null)
        {
            Moving = false;
        }
        else
        {
            if (bestTarget.position.x < fromThis.position.x)
            {
                if (horizontally)
                {
                    SpiderMeshHorizontally.transform.Rotate(0, -180, 0);
                }



                horizontally = false;



            }
            else
            {

                if (!horizontally)
                {
                    SpiderMeshHorizontally.transform.Rotate(0, -180, 0);
                }
                horizontally = true;



            };
        }
    

        
    }

    void GetClosestLadderDown(List<Transform> Ladders, Transform fromThis)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = fromThis.position;
        foreach (Transform potentialTarget in Ladders)
        {

            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }

        }

        if (bestTarget == null)
        {
            Moving = false;
        }
        else
        {
            if (bestTarget.position.x < fromThis.position.x)
            {

                if (horizontally)
                {
                    SpiderMeshHorizontally.transform.Rotate(0, -180, 0);
                }

                horizontally = false;



            }
            else
            {
                if (!horizontally)
                {
                    SpiderMeshHorizontally.transform.Rotate(0, -180, 0);
                }

                horizontally = true;



            };
        }
    

       
    }



    void GetClosestEnemyandDirectionHorzizontal(List<Transform> enemies, Transform fromThis)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = fromThis.position;
        foreach (Transform potentialTarget in enemies)
        {
            if (!potentialTarget.GetComponent<NonVRPlayerController>().Dying)
            {
                Vector3 directionToTarget = potentialTarget.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget;
                }
            }
        }

        if(bestTarget == null)
        {
            Moving = false;
        }
        else
        {
            Moving = true;

            if (bestTarget.position.y < fromThis.position.y)
            {
                if (!bestTarget.GetComponent<NonVRPlayerController>().Dying)
                {
                    if (vertically) {
                    SpiderMeshVertically.transform.Rotate(-180,0, 0);
                    }
                    vertically = false;

                }

            }
            else
            {
                if (!bestTarget.GetComponent<NonVRPlayerController>().Dying)
                {
                    if (!vertically)
                    {
                        SpiderMeshVertically.transform.Rotate(-180, 0, 0);
                    }
                    vertically = true;

                }

            };
        }


        }

    void GetClosestEnemyandDirectionVertically(List<Transform> enemies, Transform fromThis)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = fromThis.position;
        foreach (Transform potentialTarget in enemies)
        {
            if (!potentialTarget.GetComponent<NonVRPlayerController>().Dying)
            {
                Vector3 directionToTarget = potentialTarget.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget;
                }
            }
        }

        if (bestTarget == null)
        {
            Moving = false;
        }
        else
        {
            Moving = true;
            if (bestTarget.position.x < fromThis.position.x)
            {
                if (!bestTarget.GetComponent<NonVRPlayerController>().Dying)
                {

                    if (horizontally)
                    {
                        SpiderMeshHorizontally.transform.Rotate(0, -180, 0);
                    }

                    horizontally = false;

                }

            }
            else
            {
                if (!bestTarget.GetComponent<NonVRPlayerController>().Dying)
                {
                    if (!horizontally)
                    {
                        SpiderMeshHorizontally.transform.Rotate(0, -180, 0);
                    }
                    horizontally = true;

                }

            };
        }

      

    }
    private void OnTriggerEnter(Collider other)
    {
    

        if (other.CompareTag("LadderUp"))
        {
            LadderUpInsight.Add(other.transform);
        }

        if (other.CompareTag("LadderDown"))
        {
            LadderDownInsight.Add(other.transform);
        }

    
    }

    public void HitEffect()
    {
        WhiteWalkingHorizontal.layer = 12;
        WhiteWalkingVertical.layer = 12;

        for (int i = 0; i < WhiteWalkingHorizontal.transform.childCount; i++)
        {
            WhiteWalkingHorizontal.transform.GetChild(i).gameObject.layer = 12;
            for (int a = 0; a < WhiteWalkingHorizontal.transform.GetChild(i).gameObject.transform.childCount; a++)
            {
                WhiteWalkingHorizontal.transform.GetChild(i).gameObject.transform.GetChild(a).gameObject.layer = 12;
            }


        }

        for (int i = 0; i < WhiteWalkingVertical.transform.childCount; i++)
        {
            WhiteWalkingVertical.transform.GetChild(i).gameObject.layer = 12;
            for (int a = 0; a < WhiteWalkingVertical.transform.GetChild(i).gameObject.transform.childCount; a++)
            {
                WhiteWalkingVertical.transform.GetChild(i).gameObject.transform.GetChild(a).gameObject.layer = 12;
            }


        }

        StartCoroutine(StopHitEffectafterSeconds(0.3f));
    }

    IEnumerator StopHitEffectafterSeconds(float Seconds)
    {

        yield return new WaitForSeconds(Seconds);
        ReverseHitEffect();
    }

    void ReverseHitEffect()
    {
        WhiteWalkingHorizontal.layer = 13;
        WhiteWalkingVertical.layer = 13;

        for (int i = 0; i < WhiteWalkingHorizontal.transform.childCount; i++)
        {
            WhiteWalkingHorizontal.transform.GetChild(i).gameObject.layer = 13;
            for (int a = 0; a < WhiteWalkingHorizontal.transform.GetChild(i).gameObject.transform.childCount; a++)
            {
                WhiteWalkingHorizontal.transform.GetChild(i).gameObject.transform.GetChild(a).gameObject.layer = 13;
            }


        }

        for (int i = 0; i < WhiteWalkingVertical.transform.childCount; i++)
        {
            WhiteWalkingVertical.transform.GetChild(i).gameObject.layer = 13;
            for (int a = 0; a < WhiteWalkingVertical.transform.GetChild(i).gameObject.transform.childCount; a++)
            {
                WhiteWalkingVertical.transform.GetChild(i).gameObject.transform.GetChild(a).gameObject.layer = 13;
            }


        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")){
            PlayerInside = true;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInside = false;
        }

        if (other.CompareTag("LadderUp"))
        {
         
                for (var i = 0; i < LadderUpInsight.Count; i++)
                {
                    if (LadderUpInsight[i] == other.gameObject.transform)
                    {
                    LadderUpInsight.RemoveAt(i);
                    }

                }
            }

        if (other.CompareTag("LadderDown"))
        {
            for (var i = 0; i < LadderDownInsight.Count; i++)
            {
                if (LadderDownInsight[i] == other.gameObject.transform)
                {
                    LadderDownInsight.RemoveAt(i);
                }

            }
        }
    }
}
