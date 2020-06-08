using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PeachWin : MonoBehaviour {

    public GameObject blackplane;
    public GameObject points;
    public Text gameOverText;
    public GameObject VRLose;
    


    public GameObject vrMenu;
    AudioSource audioSource;

    public GameObject backgroundMusic;
    public GameObject backgroundWin;

    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
    }
	
	
	void Update ()
    {
		
	}

    IEnumerator Win(int seconds)
    {
        
        yield return new WaitForSeconds(seconds);
        Destroy(vrMenu);
        SceneManager.LoadScene("Menu");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            backgroundWin.SetActive(true);
            backgroundMusic.SetActive(false);

            gameOverText.text = "YOU WIN";
            VRLose.SetActive(true);
            blackplane.SetActive(true);
            points.SetActive(false);
            

            StartCoroutine(Win(3));
        }        
    }
}
