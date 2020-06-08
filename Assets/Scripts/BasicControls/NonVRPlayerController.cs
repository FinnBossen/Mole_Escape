using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(PlayerInput))]

public class NonVRPlayerController : MonoBehaviour {

    //Rotation of for non VR Player on Curve
    private int collisionCount = 0;
    bool insideRailCurve = false;
    public GameObject LookForRotation;
    private getLookingRotation GetLookingRotation;
    public bool InsideCartSeat;
    public GameObject Torch;
    public GameObject WaterBucket;
    public GameObject PickAxe;
    public GameObject Mario;
    public GameObject MarioJump;
    public GameObject MarioClimb;
    private voxelloop WaterBucketAnim;
    private voxelloop PickAxeAnim;
    private voxelloop TorchAnim;
    private float littleActionJump = 0.5f;
    bool littleJump;
    public float speed;
    public float jump;
    public bool isGrounded;
    private Rigidbody rb;
    public bool Onladder = false;
    bool movesLeft = false;
    bool Jump = false;
    private VoxelAnimation voxelAnimation;
    private VoxelAnimation ladderAnimation;
    private bool notUsing = false;
    public AudioClip audioJump;
    public AudioClip audioWalk;
    AudioSource audioSource;
    AudioSource walkSource;
    private bool ExitCart = false;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpkey;
    public KeyCode pickAxeKey;
    public KeyCode WaterKey;
    public KeyCode goUpKey;
    public KeyCode goDownKey;
    public KeyCode reviveKey;
    public KeyCode ActionKey;
    public KeyCode TorchKey;
    public GameObject Directions;
    public string AxisName;
    public bool Dying = false;
    private bool CanExitCart = true;
    public bool UseController = false;
    public bool goUpKeyPressed = false;
    public bool goDownKeyPressed = false;

    public string HorizontalAxisName;
    public string VertcialAxisName;
    public AudioClip Water;
    public AudioClip Nugget;
    PlayerInput input;
    private bool moving = false;
    void Start ()
    {
        input = gameObject.GetComponent<PlayerInput>();
        WaterBucketAnim = WaterBucket.GetComponent<voxelloop>();
        PickAxeAnim = PickAxe.GetComponent<voxelloop>();
        Physics.IgnoreLayerCollision(14, 14);
        GetLookingRotation = LookForRotation.GetComponent<getLookingRotation>();
        rb = GetComponent<Rigidbody>();
        voxelAnimation = gameObject.GetComponent<VoxelAnimation>();
        speed = 3.0f;
        jump = 2.0f;
        isGrounded = true;
        Application.targetFrameRate = 90;
        QualitySettings.vSyncCount = 0;
        ladderAnimation = MarioClimb.GetComponent<VoxelAnimation>();
        TorchAnim = Torch.GetComponent<voxelloop>();
        audioSource = GetComponent<AudioSource>();
        walkSource = GetComponent<AudioSource>();

      
    }

    private void FixedUpdate()
    {
        if (Jump)
        {
            audioSource.PlayOneShot(audioJump, 0.7F);
            audioSource.volume = 0.8f;
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
           
            Jump = false;
        }else if (littleJump)
        {
            rb.AddForce(Vector3.up * littleActionJump, ForceMode.Impulse);
            littleJump = false;
          
        }

        
    }

    private void LateUpdate()
    {
    
      
    }
    IEnumerator WaitTillNextAction(float Seconds)
    {
        yield return new WaitForSeconds(Seconds);
        notUsing = false;
    }
    void Update ()
    {
        
            if (!Dying && !InsideCartSeat)
            {
                if (!Onladder)
                {

                if (!UseController) {
                    if (!Input.GetKey(rightKey) && Input.GetKey(leftKey))
                    {




                        transform.Translate(-Vector3.right * speed * Time.deltaTime);

                        if (!movesLeft && isGrounded)
                        {
                            MarioJump.SetActive(false);
                            Mario.SetActive(true);
                            Directions.transform.Rotate(0, -180, 0);

                            voxelAnimation.animActivated = true;
                            movesLeft = true;
                        }
                        else if (!movesLeft)
                        {
                            movesLeft = true;
                            Directions.transform.Rotate(0, -180, 0);

                        }

                    }

                    if (!Input.GetKey(leftKey) && Input.GetKey(rightKey))
                    {

                        transform.Translate(Vector3.right * speed * Time.deltaTime);

                        if (isGrounded && movesLeft)
                        {
                            MarioJump.SetActive(false);
                            Mario.SetActive(true);
                            Directions.transform.Rotate(0, -180, 0);
                            voxelAnimation.animActivated = true;
                            movesLeft = false;
                        }
                        else if (movesLeft)
                        {
                            movesLeft = false;
                            Directions.transform.Rotate(0, -180, 0);

                        }

                    }

                    if ((Input.GetKey(leftKey) || Input.GetKey(rightKey)) && isGrounded)
                    {
                        if (!walkSource.isPlaying)
                        {
                            walkSource.clip = audioWalk;
                            walkSource.volume = 0.4F;
                            walkSource.Play();
                            voxelAnimation.animActivated = true;
                        }
                    }

                    if (Input.GetKeyUp(leftKey) || Input.GetKeyUp(rightKey))
                    {
                        walkSource.Stop();
                    }

                    if (!Input.GetKey(leftKey) && !Input.GetKey(rightKey))
                    {
                        voxelAnimation.animActivated = false;
                    }

                }
                else
                {




                    if (Input.GetAxis(HorizontalAxisName) < -0.3)
                    {

                        moving = true;


                        transform.Translate(-Vector3.right * speed * Time.deltaTime);

                        if (!movesLeft && isGrounded)
                        {
                            MarioJump.SetActive(false);
                            Mario.SetActive(true);
                            Directions.transform.Rotate(0, -180, 0);

                            voxelAnimation.animActivated = true;
                            movesLeft = true;
                        }
                        else if (!movesLeft)
                        {
                            movesLeft = true;
                            Directions.transform.Rotate(0, -180, 0);

                        }

                    }
                    else
                    {
                        moving = false;
                    }

                    if (Input.GetAxis(HorizontalAxisName) > 0.3)
                    {
                        moving = true;
                        transform.Translate(Vector3.right * speed * Time.deltaTime);

                        if (isGrounded && movesLeft)
                        {
                            MarioJump.SetActive(false);
                            Mario.SetActive(true);
                            Directions.transform.Rotate(0, -180, 0);
                            voxelAnimation.animActivated = true;
                            movesLeft = false;
                        }
                        else if (movesLeft)
                        {
                            movesLeft = false;
                            Directions.transform.Rotate(0, -180, 0);

                        }

                    }
                    else
                    {
                        moving = false;
                    }

                    if ((Input.GetAxis(HorizontalAxisName) < -0.3 || Input.GetAxis(HorizontalAxisName) > 0.3) && isGrounded)
                    {
                        moving = true;
                        if (!walkSource.isPlaying)
                        {
                            walkSource.clip = audioWalk;
                            walkSource.volume = 0.4F;
                            walkSource.Play();
                            voxelAnimation.animActivated = true;
                        }
                    }
                    else
                    {
                        moving = false;
                    }


                    if (!moving)
                    {
                        voxelAnimation.animActivated = false;
                        walkSource.Stop();
                    }
                }

                if (Input.GetKey(pickAxeKey) && GameManager.goldNuggets >= GameManager.PickaxeCost)
                    {
                        if (!notUsing)
                        {
                            notUsing = true;
                            GameManager.goldNuggets = GameManager.goldNuggets - GameManager.PickaxeCost;
                            StartCoroutine(WaitTillNextAction(0.4f));
                            PickAxeAnim.animActivated = true;
                            if (isGrounded)
                            {

                                littleJump = true;
                            }
                        }

                    }

                    if (Input.GetKey(WaterKey) && GameManager.goldNuggets >= GameManager.WaterBarrelCost)
                    {
                        if (!notUsing)
                        {
                        audioSource.PlayOneShot(Water, 0.7F);
                        notUsing = true;
                            GameManager.goldNuggets = GameManager.goldNuggets - GameManager.WaterBarrelCost;
                            StartCoroutine(WaitTillNextAction(0.4f));
                            WaterBucketAnim.animActivated = true;
                            if (isGrounded)
                            {
                                littleJump = true;
                            }
                        }


                    }

                    if (Input.GetKey(TorchKey) && GameManager.goldNuggets >= GameManager.TorchCost)
                    {
                        if (!notUsing)
                        {
                            notUsing = true;
                            GameManager.goldNuggets = GameManager.goldNuggets - GameManager.TorchCost;
                            StartCoroutine(WaitTillNextAction(0.4f));
                            TorchAnim.animActivated = true;
                            if (isGrounded)
                            {
                                littleJump = true;
                            }
                        }


                    }


                    if (Input.GetKeyDown(jumpkey) && isGrounded)
                    {
                        walkSource.Stop();
                        Jump = true;
                    }



                    if (Jump)
                    {
                        MarioJump.SetActive(true);
                        Mario.SetActive(false);
                    }



                }


            }
            else if (InsideCartSeat && CanExitCart)
            {


                if (Input.GetKeyDown(jumpkey) || ExitCart)
                {
                    ExitCart = false;
                    GameObject ParentObject = transform.parent.gameObject;
                    transform.parent = null;
                    Destroy(ParentObject);
                    rb.isKinematic = false;
                    rb.useGravity = true;
                    InsideCartSeat = false;
                    Jump = true;
                }


                if (Jump)
                {
                    MarioJump.SetActive(true);
                    Mario.SetActive(false);
                }
            }
        
       
    }




    void OnCollisionStay(Collision other)
    {

        if (other.gameObject.tag == "Ground" && !notUsing)
        {
            isGrounded = true;
            Jump = false;
         
           
        }


   



    }
    IEnumerator Deactivate()
    {
        while(WaterBucketAnim.animActivated || PickAxeAnim.animActivated)
        {


           
            deactivateAllAnimations();
            yield return null;
       
        }
 
        yield return null;
    }

    void OnCollisionEnter(Collision other)
    {
        collisionCount++;
        if (other.gameObject.tag == "Ground" )
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, other.gameObject.transform.position.z);
            MarioJump.SetActive(false);
            Mario.SetActive(true);

        }

     

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("CaveTrigger"))
        {
            if (Input.GetKey(ActionKey))
            {
                if (GameManager.goldNuggets >= GameManager.SchalterCost)
                {
                    GameManager.goldNuggets = GameManager.goldNuggets - GameManager.SchalterCost;
                    other.gameObject.GetComponent<CaveTrigger>().ActivateCave();

                }
                }
            }

        if (other.gameObject.tag == "Ladder")
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
       
        }
        if (other.gameObject.tag == "Ladder" && Onladder)
        {
           
            MarioClimb.SetActive(true);
            MarioJump.SetActive(false);
            Mario.SetActive(false);
            ladderAnimation.animActivated = true;
         

        }
        if (other.gameObject.tag == "Ladder" && !Onladder)
        {

            MarioClimb.SetActive(false);
            MarioJump.SetActive(false);
            Mario.SetActive(true);
            ladderAnimation.animActivated = false;

        }
     

        if (other.gameObject.tag == "PlayerRevive" && Input.GetKeyDown(reviveKey))
        {
            if (!other.gameObject.transform.IsChildOf(gameObject.transform)) {
            Debug.Log("revivimg");
                if (GameManager.goldNuggets >= GameManager.ReviveCost)
                {
                    GameManager.goldNuggets = GameManager.goldNuggets - GameManager.ReviveCost;
                    other.gameObject.transform.parent.GetComponent<ThrowableHit>().revivePlayer();
                }
            }
        }
    }


 public void deactivateAnimations()
    {
        
        voxelAnimation.animActivated = false;
        MarioClimb.SetActive(false);
  
        MarioJump.SetActive(false);
        Mario.SetActive(true);
    }

    public void deactivateAllAnimations()
    {

        voxelAnimation.animActivated = false;
        MarioClimb.SetActive(false);

        MarioJump.SetActive(false);
        Mario.SetActive(false);
    }

    void OnCollisionExit(Collision other)
    {
        collisionCount--;
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "GroundCurve")
             {
                 isGrounded = false;
                Debug.Log("draussen");
            
             }

      

        //if (other.gameObject.tag == "GroundCurve")
        //{
        //    insideRailCurve = false;
        //    LookForRotation.SetActive(false);
        //}

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Curve"))
        {
            if (InsideCartSeat) { 
            CanExitCart = !CanExitCart;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "GoldNugget" && !Dying)
        {
            if (!InsideCartSeat) {
                audioSource.PlayOneShot(Nugget, 0.7F);
            GameManager.goldNuggets++;
            Destroy(other.gameObject);
            }
        }
        if (other.CompareTag("ExitCart"))
        {
            if (InsideCartSeat) { 
            ExitCart = true;
            }
        }

     

        /*
        if (other.CompareTag("KartMovingPoint") && insideRailCurve )
        {
            Debug.Log("Deleted RotationPoint");

            Vector3 first = GetLookingRotation.LookPoints[1];
            GetLookingRotation.LookPoints.Clear();

            GetLookingRotation.LookPoints.Add(first);


        }

    */


    }
}
