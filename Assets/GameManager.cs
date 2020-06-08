using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{

    public GameObject GameOver;
    public GameObject Menu;
    public GameObject Win;
    public static int goldNuggets;
    public static int CoinCount;
    public static int Lives;
    public static float CoinPercentage;
    public static float Spikes_ZielscheibeRatio;
    public static int PickaxeCost;
    public static int WaterBarrelCost;
    public static int TorchCost;
    public static int SchalterCost;
    public static int ReviveCost;

    public static int SpawnRatCost;
    public static int SpawnSpiderCost;
    public static int RespawnBarrelCost;
    public static int RespawnFireLampCost;
    public static int RespawnDynamiteCost;
    public static int RespawnIceCost;
    public static int MineCartExplosionCost;

    public int LivesSet;
    public float CoinPercentageSet;
    public float Spikes_ZielscheibeRatioSet;
    public int PickaxeCostSet;
    public int WaterBarrelCostSet;
    public int TorchCostSet;
    public int SchalterCostSet;
    public int ReviveCostSet;

    public int SpawnRatCostSet;
    public int SpawnSpiderCostSet;
    public int RespawnBarrelCostSet;
    public int RespawnFireLampCostSet;
    public int RespawnDynamiteCostSet;
    public int RespawnIceCostSet;
    public int MineCartExplosionCostSet;

    public TextMeshPro Nuggets;
    public TextMeshPro LivesText;

    public TextMeshPro PickaxeCostText;
    public TextMeshPro WaterBarrelCostText;
    public TextMeshPro TorchCostText;
    public TextMeshPro SchalterCostText;
    public TextMeshPro ReviveCostText;

    // Start is called before the first frame update
    void Start()
    {
        Lives = LivesSet;
        CoinPercentage = CoinPercentageSet;
        Spikes_ZielscheibeRatio = Spikes_ZielscheibeRatioSet;
        PickaxeCost = PickaxeCostSet; ;
        WaterBarrelCost = WaterBarrelCostSet; ;
        TorchCost = TorchCostSet; ;
        SchalterCost = SchalterCostSet;
        ReviveCost = ReviveCostSet;

        SpawnRatCost = SpawnRatCostSet;
        SpawnSpiderCost = SpawnSpiderCostSet;
        RespawnBarrelCost = RespawnBarrelCostSet;
        RespawnFireLampCost = RespawnFireLampCostSet;
        RespawnDynamiteCost = RespawnDynamiteCostSet;
        RespawnIceCost = RespawnIceCostSet;
        MineCartExplosionCost = MineCartExplosionCostSet;



        CoinCount = 0;
        goldNuggets = 0;

        LivesText.text = Lives.ToString();
        PickaxeCostText.text = PickaxeCost.ToString();
        WaterBarrelCostText.text = WaterBarrelCost.ToString();
        TorchCostText.text = TorchCost.ToString();
        SchalterCostText.text = SchalterCost.ToString();
        ReviveCostText.text = ReviveCost.ToString();
    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += ResetStuff;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= ResetStuff;
    }

    void ResetStuff(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = 1;
        Debug.Log("Level Loaded");
        Debug.Log(scene.name);
        Debug.Log(mode);
        CoinCount = 0;
        Lives = LivesSet;
        goldNuggets = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
      Nuggets.text = goldNuggets.ToString();
      LivesText.text = Lives.ToString();

        if(Lives <= 0)
        {
            GameOver.SetActive(true);

            GameObject.Find("VRWin");
      
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1) {
                Time.timeScale = 0;
                Menu.SetActive(true);
            
                GameObject.Find("VRPaused").SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                Menu.SetActive(false);
             
                GameObject.Find("VRPaused").SetActive(false);
            }
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        System.Diagnostics.Process.Start(Application.dataPath.Replace("_Data", ".exe")); //new program
        Application.Quit(); //kill current process

    }
    public void NonVRWins()
    {
        Time.timeScale = 0;
        Win.SetActive(true);

        
        GameObject.Find("VRLose").SetActive(true);

    }





}
