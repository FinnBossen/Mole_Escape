using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThrowableHit : MonoBehaviour {

    public int life = 3;
    public Text lifeText;
    public Text gameOverText;
    private Animation marioFalls;
    private PutOnPathExample putOnPath;
    public GameObject[] SpawnPoints = new GameObject[4];
    public int SpawnPointNumber;
    private Transform SpawnPoint;
    public GameObject blackplane;
    public GameObject points;
    private GameObject animationFallback;
    private NonVRPlayerController MarioControl;
    private bool isCoroutineExecuting = false;
    private bool isRespawnExecuting = false;
    private IEnumerator couroutine;
    public GameObject Players;
    public AudioClip audioDeath;
    public AudioClip audioBanana;
    AudioSource audioSource;
    public float timeTillRespawn = 10f;
    public GameObject vrMenu;
    public bool Dying = false;
    public GameObject VRWin;
    public GameObject Help;
    private bool helpOn = false;
    private bool animOn = false;
    public GameObject backgroundMusic;
    public GameObject backgroundLose;
    public GameObject backgroundWin;
    private bool IsideCarSeat = false;
    public AudioClip ThankYou;
    public AudioClip HelpScream;
    int activePlayers = 0;

    void Start ()
    {
        Players = GameObject.Find("Players");

        for (int i = 0; i< Players.transform.childCount; i++)
        {
           
            if (Players.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                activePlayers++;
            }
        }
        SpawnPoint = SpawnPoints[SpawnPointNumber - 1].transform;
        putOnPath = gameObject.GetComponent<PutOnPathExample>();
        gameObject.transform.position = SpawnPoint.position;
    
        marioFalls = gameObject.GetComponent<Animation>();
          
        MarioControl = gameObject.GetComponent<NonVRPlayerController>();

        audioSource = GetComponent<AudioSource>();
    }

    void Respawn()
    {
       
        Help.SetActive(false);
        MarioControl.Onladder = false;
        putOnPath.Onladder = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<NonVRPlayerController>().Dying = false;
        gameObject.GetComponent<PutOnPathExample>().Dying = false;
        audioSource.PlayOneShot(audioDeath, 3.0F);
        gameObject.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        gameObject.transform.position = SpawnPoint.position;
        gameObject.transform.parent = Players.transform.transform;
        GameManager.Lives--;
        marioFalls.enabled = false;
        isRespawnExecuting = false;
        Dying = false;

     




    }

    private void LateUpdate()
    {
        if (!marioFalls.isPlaying && animOn == true )
        {
            if (helpOn)
            {
                Help.SetActive(true);
                helpOn = false;
            }
               

                    gameObject.transform.parent = null;
            Destroy(animationFallback);
            animOn = false;

        }

    }

   public void revivePlayer()
    {
       if (gameObject.GetComponent<NonVRPlayerController>().Dying) { 
        Help.SetActive(false);
        marioFalls.enabled = false;
        Vector3 CurrentPosition = gameObject.GetComponent<Transform>().position;
        animationFallback = new GameObject();
        animationFallback.transform.position = CurrentPosition;
        animationFallback.AddComponent<Rigidbody>();
        isRespawnExecuting = false;
        gameObject.transform.SetParent(animationFallback.transform);
        marioFalls.enabled = true;
        animationFallback.GetComponent<Rigidbody>().AddForce(Vector3.up * 200f, ForceMode.Acceleration);
        marioFalls["Dies"].time = marioFalls["Dies"].length;
        marioFalls["Dies"].speed = -1.0f;
        marioFalls.Play("Dies");
        animOn = true;
        gameObject.GetComponent<NonVRPlayerController>().Dying = false;
        gameObject.GetComponent<PutOnPathExample>().Dying = false;
        isRespawnExecuting = false;
        Dying = false;
            audioSource.PlayOneShot(ThankYou, 2.0F);
        }
    }

    void dyingPlayer()
    {
      
        marioFalls.enabled = false;
        Vector3 CurrentPosition = gameObject.GetComponent<Transform>().position;
        animationFallback = new GameObject();
        animationFallback.transform.position = CurrentPosition;
        animationFallback.AddComponent<Rigidbody>();
  
        gameObject.transform.SetParent(animationFallback.transform);
        marioFalls.enabled = true;
        animationFallback.GetComponent<Rigidbody>().AddForce(Vector3.up * 200f, ForceMode.Acceleration);

        marioFalls["Dies"].speed = 1.0f;
        marioFalls.Play("Dies");
        helpOn = true;
        animOn = true;
        isRespawnExecuting = false;
        gameObject.GetComponent<NonVRPlayerController>().Dying = true;
        gameObject.GetComponent<PutOnPathExample>().Dying = true;
        gameObject.GetComponent<NonVRPlayerController>().deactivateAnimations();
        audioSource.PlayOneShot(HelpScream, 2.0F);
        StartCoroutine(RespawnAfterTime(timeTillRespawn));
        if (activePlayers == 1)
        {
           
           
            StartCoroutine(RespawnShortly());
        }
    }
    IEnumerator RespawnShortly()
    {
        
        yield return new WaitForSeconds(3);
        Respawn();
    }
    void Update ()
    {

   
    }

    IEnumerator Lose(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(vrMenu);
        SceneManager.LoadScene("Menu");
    }

    void OnCollisionEnter(Collision other)
    {
     
        if (other.gameObject.tag == "Banana")
        {
            marioFalls.enabled = false;
            Vector3 CurrentPosition = gameObject.GetComponent<Transform>().position;
            animationFallback = new GameObject();
            animationFallback.transform.position = CurrentPosition;
            gameObject.transform.SetParent(animationFallback.transform);
            marioFalls.enabled = true;
              audioSource.PlayOneShot(audioBanana, 2.0F);
            animOn = true;
            marioFalls.Play();
          //  StartCoroutine(ExecuteAfterTime(marioFalls.clip.length+0.2f));

            // Destroy(other.gameObject);

        }

      

        if (other.gameObject.tag == "Throwable" ||  other.gameObject.tag == "StoneSpikeFalling" || other.gameObject.tag == "TheKartRolling"|| other.gameObject.tag == "rat" )
        {
            if (!Dying) { 
            Dying = true;
            dyingPlayer();
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameOver")
        {
            Respawn();
        }
        if (other.gameObject.tag == "Banana")
        {
            audioSource.PlayOneShot(audioBanana, 2.0F);
            marioFalls.Rewind();
           
            Vector3 CurrentPosition = gameObject.GetComponent<Transform>().position;
            animationFallback = new GameObject();
            animationFallback.transform.position = CurrentPosition;
            gameObject.transform.SetParent(animationFallback.transform);
            animOn = true;
            marioFalls.Play();
          //  StartCoroutine(ExecuteAfterTime(marioFalls.clip.length));

            Destroy(other.gameObject);


        }

        if (other.CompareTag("NonVRTakeASeat") && !Dying )
        {
            if (!gameObject.GetComponent<NonVRPlayerController>().Onladder) { 
            if (other.gameObject.transform.parent.GetComponent<ItweenCart>().explosives.childCount == 0 && other.gameObject.transform.parent.GetComponent<ItweenCart>().PlayerSeat.childCount == 0) { 
            MarioControl.InsideCartSeat = true;
            IsideCarSeat = true;
            var emptyObject = new GameObject();
            emptyObject.transform.parent = other.gameObject.transform;
            emptyObject.transform.localPosition = Vector3.zero;
            emptyObject.transform.localRotation = Quaternion.identity;
            gameObject.transform.parent = emptyObject.transform;
            gameObject.transform.localPosition = Vector3.zero;
          
            gameObject.transform.localRotation = Quaternion.identity;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.GetComponent<NonVRPlayerController>().deactivateAnimations();
            }
            }
        }

        if (other.gameObject.tag == "Throwable" ||  other.gameObject.tag == "StoneSpikeFalling" || other.gameObject.tag == "TheKartRolling" || other.gameObject.tag == "rat" )
        {
            if (!Dying && !IsideCarSeat)
            {
                Dying = true;
                dyingPlayer();
            }
        }



    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NonVRTakeASeat") && !Dying)
        {
            gameObject.transform.localRotation = Quaternion.identity;
            IsideCarSeat = false;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Throwable" || other.gameObject.tag == "StoneSpikeFalling" || other.gameObject.tag == "TheKartRolling" && !Dying)
        {
            if (!Dying)
            {
                Dying = true;
                dyingPlayer();
            }


        }
    }
  
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Throwable" || other.gameObject.tag == "StoneSpikeFalling" || other.gameObject.tag == "TheKartRolling" && !Dying)
        {
            if (!Dying && !IsideCarSeat)
            {
                Dying = true;
                dyingPlayer();
            }


        }

    }

    IEnumerator RespawnAfterTime(float time)
    {
        if (isRespawnExecuting)
            yield break;

        isRespawnExecuting = true;
        yield return new WaitForSeconds(time);
        if (isRespawnExecuting) { Respawn(); }
       
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);
        
        gameObject.transform.parent = null;
        Destroy(animationFallback);
        

        isCoroutineExecuting = false;
    }
}
