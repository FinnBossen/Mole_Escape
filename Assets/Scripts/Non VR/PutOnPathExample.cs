using UnityEngine;
using System.Collections;

public class PutOnPathExample : MonoBehaviour{

    private AudioSource audio;
    public AudioClip LadderWalking;
	public Transform[] path;
    public Transform[] fallback;
    public float percentage;
    public bool Onladder;
    private KeyCode ItweenPercentageUp;
    private KeyCode ItweenPercentageDown;
    private NonVRPlayerController PlayerController;
    public GameObject MarioClimb;
    public GameObject Mario;
    private VoxelAnimation ladderAnimation;
    public bool Dying;
    public bool usesController = false;
    private string VerticalAxisName;
    private bool AxisUpPercentageUp = false;

    private bool PercentageUpController = false;
    private bool PercentageDownController = false;

    private bool ControllerMoving;
    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        ladderAnimation = MarioClimb.GetComponent<VoxelAnimation>();
        PlayerController = gameObject.GetComponent<NonVRPlayerController>();
        fallback = new Transform[1];

        if (PlayerController.UseController)
        {
            VerticalAxisName = PlayerController.VertcialAxisName;
            usesController = true;
        }
        else
        {
            usesController = false;
        }
    }




    private void FixedUpdate()
    {
        if (!usesController)
        {
            if (Onladder && !Dying)
            {
               
                iTween.PutOnPath(gameObject, path, percentage);
                if (Input.GetKey(ItweenPercentageUp))
                {
                    if (!audio.isPlaying)
                    {
                        audio.clip = LadderWalking;
                        audio.volume = 0.4F;
                        audio.Play();
                    }
                    percentage = percentage + 0.01f;
                        ladderAnimation.animActivated = true;
                  
                    if (percentage <= 0f || percentage >= 1f)
                    {
                        Mario.SetActive(true);
                        PlayerController.Onladder = false;
                        Onladder = false;
                        MarioClimb.SetActive(false);

                        gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    }
                }
                else if (Input.GetKey(ItweenPercentageDown))
                {
                    if (!audio.isPlaying)
                    {
                        audio.clip = LadderWalking;
                        audio.volume = 0.4F;
                        audio.Play();
                    }
                    percentage = percentage - 0.01f;
                    ladderAnimation.animActivated = true;
                    if (percentage <= 0.00000000f || percentage >= 1.0000000f)
                    {
                        Mario.SetActive(true);
                        PlayerController.Onladder = false;
                        Onladder = false;
                        MarioClimb.SetActive(false);
                        gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    }
                }
                else
                {
                    audio.Stop();
                }






                if (!Input.GetKey(ItweenPercentageUp) && !Input.GetKey(ItweenPercentageDown))
                {
                    ladderAnimation.animActivated = false;
                }


            }
        }
        else if (usesController)
            {
                if (Onladder && !Dying)
                {
                    ControllerHandler();
                    iTween.PutOnPath(gameObject, path, percentage);
                    if (PercentageUpController)
                    {
                        percentage = percentage + 0.01f;
                        ladderAnimation.animActivated = true;
                        if (percentage <= 0f || percentage >= 1f)
                        {
                            Mario.SetActive(true);
                            PlayerController.Onladder = false;
                            Onladder = false;
                            MarioClimb.SetActive(false);

                            gameObject.GetComponent<Rigidbody>().isKinematic = false;
                        }
                    }


                    if (PercentageDownController)
                    {
                        percentage = percentage - 0.01f;
                        ladderAnimation.animActivated = true;
                        if (percentage <= 0.00000000f || percentage >= 1.0000000f)
                        {
                            Mario.SetActive(true);
                            PlayerController.Onladder = false;
                            Onladder = false;
                            MarioClimb.SetActive(false);
                            gameObject.GetComponent<Rigidbody>().isKinematic = false;
                        }
                    }

                    if (!PercentageDownController && !PercentageUpController)
                    {
                        ladderAnimation.animActivated = false;
                    }


                }
            }
        

    }

    private void OnTriggerStay(Collider other)
    {
        if (!Onladder && !Dying) {
        if (other.CompareTag("LadderDown"))
        {
                if (!usesController)
                {
                    ItweenPercentageUp = PlayerController.goDownKey;
                    ItweenPercentageDown = PlayerController.goUpKey;

                    if (Input.GetKey(ItweenPercentageUp) && !PlayerController.InsideCartSeat)
                    {


                        path = new Transform[other.gameObject.transform.childCount];
                        int i = 0;
                        foreach (Transform child in other.gameObject.transform)
                        {
                            path[i] = child;
                            i++;
                        };

                        if (!Onladder)
                        {
                        
                         
                            PlayerController.deactivateAllAnimations();
                            MarioClimb.SetActive(true);
                            gameObject.GetComponent<Rigidbody>().isKinematic = true;
                            percentage = 0;
                            PlayerController.Onladder = true;
                            Onladder = true;
                        }
                    }
                }
                else
                {
                    AxisUpPercentageUp = false;
                    ControllerHandler();
                    if (PercentageUpController && !PlayerController.InsideCartSeat)
                    {
                        path = new Transform[other.gameObject.transform.childCount];
                        int i = 0;
                        foreach (Transform child in other.gameObject.transform)
                        {
                            path[i] = child;
                            i++;
                        };

                        if (!Onladder)
                        {
                            PlayerController.deactivateAllAnimations();
                            MarioClimb.SetActive(true);
                            gameObject.GetComponent<Rigidbody>().isKinematic = true;
                            percentage = 0;
                            PlayerController.Onladder = true;
                            Onladder = true;
                        }
                    }
                }
           
        }

        if (other.CompareTag("LadderUp"))
        {
                if (!usesController)
                {
                    ItweenPercentageUp = PlayerController.goUpKey;
                    ItweenPercentageDown = PlayerController.goDownKey;
                    if (Input.GetKey(ItweenPercentageUp) && !PlayerController.InsideCartSeat)
                    {




                        path = new Transform[other.gameObject.transform.childCount];
                        int i = 0;
                        foreach (Transform child in other.gameObject.transform)
                        {
                            path[i] = child;
                            i++;
                        };

                        if (!Onladder)
                        {
                            PlayerController.deactivateAllAnimations();
                            MarioClimb.SetActive(true);
                            gameObject.GetComponent<Rigidbody>().isKinematic = true;
                            percentage = 0;
                            PlayerController.Onladder = true;
                            Onladder = true;
                        }

                    }
                }
                else
                {
                    AxisUpPercentageUp = true;
                    ControllerHandler();
                    if (PercentageUpController && !PlayerController.InsideCartSeat)
                    {

                        path = new Transform[other.gameObject.transform.childCount];
                        int i = 0;
                        foreach (Transform child in other.gameObject.transform)
                        {
                            path[i] = child;
                            i++;
                        };

                        if (!Onladder)
                        {
                            PlayerController.deactivateAllAnimations();
                            MarioClimb.SetActive(true);
                            gameObject.GetComponent<Rigidbody>().isKinematic = true;
                            percentage = 0;
                            PlayerController.Onladder = true;
                            Onladder = true;
                        }

                    }
                }
      

        }
        }

    }

    private void ControllerHandler()
    {
    
        if (AxisUpPercentageUp)
        {
            if (Input.GetAxis(VerticalAxisName) > 0.5)
            {
                PercentageUpController = true;
            }
            else
            {
                PercentageUpController = false;
            }

            if (Input.GetAxis(VerticalAxisName) < -0.5)
            {
                PercentageDownController = true;
            }
            else
            {
                PercentageDownController = false;
            }
        }
        else if(!AxisUpPercentageUp)
        {
            if (Input.GetAxis(VerticalAxisName) > 0.5)
            {
                PercentageDownController = true;
            }
            else 
            {
                PercentageDownController = false;
            }

            if (Input.GetAxis(VerticalAxisName) < -0.5)
            {
                PercentageUpController = true;
            }
            else
            {
                PercentageUpController = false;
            }
        }
        
    }

    
}

