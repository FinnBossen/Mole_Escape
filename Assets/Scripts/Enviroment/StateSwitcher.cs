using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSwitcher : MonoBehaviour
{
    private AudioSource Audio;
    public AudioClip Spike;
    public AudioClip FireLamp;
    public AudioClip BarrelHit;
    public AudioClip Ice;
    public AudioClip Explosion;
    public GameObject Coin;
    public GameObject iceState;
    public GameObject regularState;
    public GameObject fireState;
    public GameObject explosionState;
    public GameObject stoneSpikeState;
    public bool stateActive = false;
    public float timeLeft = 10;
    private bool Explode;
    private voxelloop ExplodeAnim;

    // Start is called before the first frame update
    void Start()
    {
        Audio = gameObject.transform.GetChild(10).gameObject.GetComponent<AudioSource>();
        Explode = false;
        ExplodeAnim = explosionState.GetComponent<voxelloop>();
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Explode)
        {
            if(ExplodeAnim.animActivated == false)
            {
                stateActive = true;
                regularState.SetActive(false);
                fireState.SetActive(true);
                Explode = false;
            }
        }

        if (stateActive) {
            
            timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
                stateActive = false;
                timeLeft = 10;
                regularState.SetActive(true);
                iceState.SetActive(false);
                fireState.SetActive(false);
                stoneSpikeState.SetActive(false);
                if (Coin != null)
                {
                    Coin.SetActive(true);
                }
            }
        }

       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Banana"))
        {
           
                Destroy(other.gameObject);
            Audio.PlayOneShot(Ice, 0.8F);
            if (Coin != null)
            {
                Coin.SetActive(false);
            }
            stateActive = true;
            regularState.SetActive(false);
            iceState.SetActive(true);
        }

        if (other.CompareTag("FireLamp"))
        {
            Audio.PlayOneShot(FireLamp, 1F);
            if (Coin != null)
            {
                Coin.SetActive(false);
            }
            stateActive = true;
            regularState.SetActive(false);
            fireState.SetActive(true);
            Destroy(other.transform.parent.gameObject);
        }
        if (other.CompareTag("StoneSpikeFalling"))
        {
            Audio.PlayOneShot(Spike, 1F);
            if (Coin != null)
            {
                Coin.SetActive(false);
            }
            stateActive = true;
            regularState.SetActive(false);
            stoneSpikeState.SetActive(true);
            Destroy(other.transform.parent.gameObject);
        }

        if (other.CompareTag("ExplosiveDynamite"))
        {
            Audio.PlayOneShot(Explosion, 1F);
            if (Coin !=null) { 
            Coin.SetActive(false);
            }
            ExplodeAnim.animActivated = true;
            Explode = true;



        }

        if (other.CompareTag("Throwable"))
        {
            Audio.PlayOneShot(BarrelHit, 1F);

            StartCoroutine(DestroyAfterSeconds(other.gameObject));
        }

    }


    IEnumerator DestroyAfterSeconds(GameObject Object)
    {
        yield return new WaitForSeconds(10);
        Destroy(Object);
    }
}
