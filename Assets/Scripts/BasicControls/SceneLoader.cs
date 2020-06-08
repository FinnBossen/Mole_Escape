using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject start;
    public GameObject quit;
    public GameObject info;
    public GameObject controls;
    public GameObject seconds;

    public GameObject vrIntro;
    public GameObject vrCountdown;

    public GameObject vrMenu;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
            Application.Quit();
        
    }

    IEnumerator Countdown(int seconds)
    {        
        yield return new WaitForSeconds(seconds);
        Destroy(vrMenu);
        SceneManager.LoadScene("Level");
    }

    public void StartLevel()
    {        
        start.SetActive(false);
        quit.SetActive(false);
        info.SetActive(false);
        controls.SetActive(false);
        seconds.SetActive(true);

        vrIntro.SetActive(false);
        vrCountdown.SetActive(true);

        StartCoroutine(Countdown(3));
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Info()
    {
        SceneManager.LoadScene("Info");

    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }  

}

