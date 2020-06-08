using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratController : MonoBehaviour
{
    public GameObject Rat;

    public GameObject Walking;
    public GameObject Idle;
    public GameObject LadderTrigger;
    private DontStandOnLadders dontStandOnLadders;

    private voxelloop IdleAnimation;
    private voxelloop WalkingAnimation;
    public bool SomethingTargeted = false; 
    public List<Transform> PlayersTargeted;
   public bool Direction = false;
    public float speed = 0.5f;
    public bool Moving;
    public GameObject RatBody;
    public int Ratlives = 3;

    public GameObject WhiteIdle;
    public GameObject WhiteWalking;

    private voxelloop WhiteAnimIdle;
    private voxelloop WhiteAnimWalking;
    public bool TryHitEffect = false;

    public bool JustGoesAway = false;
    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        dontStandOnLadders = LadderTrigger.GetComponent<DontStandOnLadders>();
        WhiteAnimIdle = WhiteIdle.GetComponent<voxelloop>();
        WhiteAnimWalking = WhiteWalking.GetComponent<voxelloop>();
        PlayersTargeted = new List<Transform>();
        IdleAnimation = Idle.GetComponent<voxelloop>();
        WalkingAnimation = Walking.GetComponent<voxelloop>();

        IdleAnimation.animActivated = true;
        WhiteAnimIdle.animActivated = true;

    }

    private void FixedUpdate()
    {

        if (isGrounded) { 
        if (Moving)
        {
            if (Direction) { 
            Rat.transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else
            {

                Rat.transform.Translate(-Vector3.right * speed * Time.deltaTime);
            }
          
        }
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {

        if (SomethingTargeted) {

            
                GetClosestEnemyandDirection(PlayersTargeted, gameObject.transform);

              
          
         
            if (!Moving)
            {
                IdleAnimation.animActivated = true;
                WhiteAnimIdle.animActivated = true;
                WalkingAnimation.animActivated = false;
                WhiteAnimWalking.animActivated = false;
            }
            else
            {
                IdleAnimation.animActivated = false;
                WhiteAnimIdle.animActivated = false;
                WalkingAnimation.animActivated = true;
                WhiteAnimWalking.animActivated = true;
                
  

            }
        

        }

        if (TryHitEffect)
        {
            HitEffect();
            TryHitEffect = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
         

            if(other.gameObject.GetComponent<NonVRPlayerController>() != null)
            {
                if (other.gameObject.GetComponent<NonVRPlayerController>().Dying == false)
                {

                    PlayersTargeted.Add(other.gameObject.transform);
                    GetClosestEnemyandDirection(PlayersTargeted, gameObject.transform);
                    SomethingTargeted = true;
                    WalkingAnimation.animActivated = true;
                    WhiteAnimWalking.animActivated = true;
                    WhiteAnimIdle.animActivated = false;
                    IdleAnimation.animActivated = false;
                }
            }
         
        }

       
    }

    public void HitEffect()
    {
        WhiteWalking.layer = 12;
        WhiteIdle.layer = 12;

        for (int i = 0; i < WhiteIdle.transform.childCount; i++)
        {
            WhiteIdle.transform.GetChild(i).gameObject.layer = 12;
            for (int a = 0; a < WhiteIdle.transform.GetChild(i).gameObject.transform.childCount; a++)
            {
                WhiteIdle.transform.GetChild(i).gameObject.transform.GetChild(a).gameObject.layer = 12;
            }


            }

        for (int i = 0; i < WhiteWalking.transform.childCount; i++)
        {
            WhiteWalking.transform.GetChild(i).gameObject.layer = 12;
            for (int a = 0; a < WhiteWalking.transform.GetChild(i).gameObject.transform.childCount; a++)
            {
                WhiteWalking.transform.GetChild(i).gameObject.transform.GetChild(a).gameObject.layer = 12;
            }


        }

        StartCoroutine(StopHitEffectafterSeconds(0.3f));
    }

    void ReverseHitEffect()
    {
        WhiteWalking.layer = 13;
        WhiteIdle.layer = 13;

        for (int i = 0; i < WhiteIdle.transform.childCount; i++)
        {
            WhiteIdle.transform.GetChild(i).gameObject.layer = 13;
            for (int a = 0; a < WhiteIdle.transform.GetChild(i).gameObject.transform.childCount; a++)
            {
                WhiteIdle.transform.GetChild(i).gameObject.transform.GetChild(a).gameObject.layer = 13;
            }


        }

        for (int i = 0; i < WhiteWalking.transform.childCount; i++)
        {
            WhiteWalking.transform.GetChild(i).gameObject.layer = 13;
            for (int a = 0; a < WhiteWalking.transform.GetChild(i).gameObject.transform.childCount; a++)
            {
                WhiteWalking.transform.GetChild(i).gameObject.transform.GetChild(a).gameObject.layer = 13;
            }


        }
    }

    IEnumerator StopHitEffectafterSeconds(float Seconds)
    {
       
        yield return new WaitForSeconds(Seconds);
        ReverseHitEffect();
    }

        private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (var i = 0; i < PlayersTargeted.Count; i++)
            {
               if (PlayersTargeted[i] == other.gameObject.transform)
                {
                    PlayersTargeted.RemoveAt(i);
                }
                
            }

            if(PlayersTargeted.Count == 0)
            {
                WhiteAnimWalking.animActivated = false;
                WalkingAnimation.animActivated = false;
                IdleAnimation.animActivated = true;
                WhiteAnimIdle.animActivated = true;
                SomethingTargeted = false;
                Moving = false;
            }
        }
    }





    void GetClosestEnemyandDirection(List<Transform> enemies, Transform fromThis)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = fromThis.position;
        foreach (Transform potentialTarget in enemies)
        {
            if (!potentialTarget.GetComponent<NonVRPlayerController>().Dying) { 
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
            }
        }

     if(bestTarget!= null) {
    
        if (bestTarget.position.x < fromThis.position.x)
        {
            if (!bestTarget.GetComponent<NonVRPlayerController>().Dying) { 

            if (Direction)
            {
                RatBody.transform.Rotate(0, -180, 0);
            }
            
            Direction = false;
                Moving = true;
            }
            else
            {
                Moving = false;
            }
        }
        else {
            if (!bestTarget.GetComponent<NonVRPlayerController>().Dying)
            {
                if (!Direction)
                {
                    RatBody.transform.Rotate(0, -180, 0);
                }
                Direction = true;
                Moving = true;
            }
            else
            {
              
                Moving = false;
            }
        };

        }
        else
        {
            Moving = false;
        }


    }
}
