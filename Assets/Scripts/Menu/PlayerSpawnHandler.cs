using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class PlayerSpawnHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Info;
    public GameObject PlayerCanvas;
    public GameObject MockPlayer1;
    public GameObject MockPlayer2;
    public GameObject MockPlayer3;
    public GameObject MockPlayer4;


    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    public bool Player1Activated = false;
    public bool Player2Activated = false;
    public bool Player3Activated = false;
    public bool Player4Activated = false;
    public bool Player1ControllerActivated = false;
    public bool Player2ControllerActivated = false;
    public bool Player3ControllerActivated = false;
    public bool Player4ControllerActivated = false;
    public KeyCode[,] PlayersKeys = new KeyCode[4, 9];
    public GameObject PlayerControlHandler;
    private PlayerContolerHandler playerContolerHandler;

    public GameObject[] Spawns = new GameObject[4];

    private int PlayerControllerCount = 0;
    bool AtleastOneActive;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (GameObject.Find(gameObject.name)
                  && GameObject.Find(gameObject.name) != this.gameObject)
        {
            Destroy(GameObject.Find(gameObject.name));
        }
    }

    void Start()
    {
        playerContolerHandler = PlayerControlHandler.GetComponent<PlayerContolerHandler>();
    }

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        Debug.Log(PlayersKeys);
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);

        if (scene.name == "Menu")
        {
            Player1Activated = false;

                Player2Activated = false;
    Player3Activated = false;
    Player4Activated = false;
    Player1ControllerActivated = false;
    Player2ControllerActivated = false;
    Player3ControllerActivated = false;
    Player4ControllerActivated = false;
    }

            if (scene.name == "Level")
        {

            GameObject Players = GameObject.Find("Players");

            if (Player1Activated)
            {

                Players.transform.GetChild(0).gameObject.SetActive(true);
                if (Player1ControllerActivated)
            {
             
                Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().UseController = true;
                 string Number = playerContolerHandler.CurrentPlayers[PlayerControllerCount].ToNumber();
                Debug.Log(Number);
                switch (Number)
                {
                    case "1":
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().HorizontalAxisName = "J1.Horizontal";
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().VertcialAxisName = "J1.Vertical";
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().pickAxeKey = KeyCode.Joystick1Button2;
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().WaterKey = KeyCode.Joystick1Button4;
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().jumpkey = KeyCode.Joystick1Button0;
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().ActionKey = KeyCode.Joystick1Button3;
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().TorchKey = KeyCode.Joystick1Button5;
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().reviveKey = KeyCode.Joystick1Button1;
                        break;
                    case "2":
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().HorizontalAxisName = "J2.Horizontal";
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().VertcialAxisName = "J2.Vertical";
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().pickAxeKey = KeyCode.Joystick2Button2;
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().WaterKey = KeyCode.Joystick2Button4;
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().jumpkey = KeyCode.Joystick2Button0;
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().ActionKey = KeyCode.Joystick2Button3;
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().TorchKey = KeyCode.Joystick2Button5;
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().reviveKey = KeyCode.Joystick2Button1;
                        break;
                    case "3":
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().HorizontalAxisName = "J3.Horizontal";
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().VertcialAxisName = "J3.Vertical";
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().pickAxeKey = KeyCode.Joystick3Button2;
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().WaterKey = KeyCode.Joystick3Button4;
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().jumpkey = KeyCode.Joystick3Button0;
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().ActionKey = KeyCode.Joystick3Button3;
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().TorchKey = KeyCode.Joystick3Button5;
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().reviveKey = KeyCode.Joystick3Button1;
                        break;
                    case "4":
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().HorizontalAxisName = "J4.Horizontal";
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().VertcialAxisName = "J4.Vertical";
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().pickAxeKey = KeyCode.Joystick4Button2;
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().WaterKey = KeyCode.Joystick4Button4;
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().jumpkey = KeyCode.Joystick4Button0;
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().ActionKey = KeyCode.Joystick4Button3;
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().TorchKey = KeyCode.Joystick4Button5;
                        Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().reviveKey = KeyCode.Joystick4Button1;
                        break;
                }

                PlayerControllerCount++;
            }
            else
            {
       
                Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().leftKey = PlayersKeys[0, 0];
                Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().rightKey = PlayersKeys[0, 1];
                Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().goUpKey = PlayersKeys[0, 2];
                Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().goDownKey = PlayersKeys[0, 3];
                Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().pickAxeKey = PlayersKeys[0, 4];
                Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().WaterKey = PlayersKeys[0, 5];
                Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().jumpkey = PlayersKeys[0, 6];
                Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().ActionKey = PlayersKeys[0, 7];
                Players.transform.GetChild(0).gameObject.GetComponent<NonVRPlayerController>().TorchKey = PlayersKeys[0, 8];
            }
            }

            if (Player2Activated)
            {
                Players.transform.GetChild(1).gameObject.SetActive(true);
                if (Player2ControllerActivated)
                {
                    Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().UseController = true;
                    string Number = playerContolerHandler.CurrentPlayers[PlayerControllerCount].ToNumber();
                    Debug.Log(Number);
                    switch (Number)
                    {
                        case "1":
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().HorizontalAxisName = "J1.Horizontal";
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().VertcialAxisName = "J1.Vertical";
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().pickAxeKey = KeyCode.Joystick1Button2;
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().WaterKey = KeyCode.Joystick1Button4;
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().jumpkey = KeyCode.Joystick1Button0;
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().ActionKey = KeyCode.Joystick1Button3;
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().TorchKey = KeyCode.Joystick1Button5;
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().reviveKey = KeyCode.Joystick1Button1;
                            break;
                        case "2":
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().HorizontalAxisName = "J2.Horizontal";
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().VertcialAxisName = "J2.Vertical";
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().pickAxeKey = KeyCode.Joystick2Button2;
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().WaterKey = KeyCode.Joystick2Button4;
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().jumpkey = KeyCode.Joystick2Button0;
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().ActionKey = KeyCode.Joystick2Button3;
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().TorchKey = KeyCode.Joystick2Button5;
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().reviveKey = KeyCode.Joystick2Button1;
                            break;
                        case "3":
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().HorizontalAxisName = "J3.Horizontal";
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().VertcialAxisName = "J3.Vertical";
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().pickAxeKey = KeyCode.Joystick3Button2;
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().WaterKey = KeyCode.Joystick3Button4;
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().jumpkey = KeyCode.Joystick3Button0;
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().ActionKey = KeyCode.Joystick3Button3;
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().TorchKey = KeyCode.Joystick3Button5;
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().reviveKey = KeyCode.Joystick3Button1;
                            break;
                        case "4":
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().HorizontalAxisName = "J4.Horizontal";
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().VertcialAxisName = "J4.Vertical";
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().pickAxeKey = KeyCode.Joystick4Button2;
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().WaterKey = KeyCode.Joystick4Button4;
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().jumpkey = KeyCode.Joystick4Button0;
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().ActionKey = KeyCode.Joystick4Button3;
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().TorchKey = KeyCode.Joystick4Button5;
                            Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().reviveKey = KeyCode.Joystick4Button1;
                            break;
                    }
                    PlayerControllerCount++;
                }
                else
                {
                    
                    Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().leftKey = PlayersKeys[1, 0];
                    Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().rightKey = PlayersKeys[1, 1];
                    Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().goUpKey = PlayersKeys[1, 2];
                    Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().goDownKey = PlayersKeys[1, 3];
                    Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().pickAxeKey = PlayersKeys[1, 4];
                    Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().WaterKey = PlayersKeys[1, 5];
                    Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().jumpkey = PlayersKeys[1, 6];
                    Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().ActionKey = PlayersKeys[1, 7];
                    Players.transform.GetChild(1).gameObject.GetComponent<NonVRPlayerController>().TorchKey = PlayersKeys[1, 8];
                }
            }
          


            if (Player3Activated)
            {
          
                Players.transform.GetChild(2).gameObject.SetActive(true);
                if (Player3ControllerActivated)
                {
                    Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().UseController = true;
                    Players.transform.GetChild(2).gameObject.GetComponent<PlayerInput>().AssignJoystick(playerContolerHandler.CurrentPlayers[PlayerControllerCount]);
                    string Number = playerContolerHandler.CurrentPlayers[PlayerControllerCount].ToNumber();
                    Debug.Log(Number);
                    switch (Number)
                    {
                        case "1":
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().HorizontalAxisName = "J1.Horizontal";
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().VertcialAxisName = "J1.Vertical";
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().pickAxeKey = KeyCode.Joystick1Button2;
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().WaterKey = KeyCode.Joystick1Button4;
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().jumpkey = KeyCode.Joystick1Button0;
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().ActionKey = KeyCode.Joystick1Button3;
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().TorchKey = KeyCode.Joystick1Button5;
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().reviveKey = KeyCode.Joystick1Button1;
                            break;
                        case "2":
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().HorizontalAxisName = "J2.Horizontal";
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().VertcialAxisName = "J2.Vertical";
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().pickAxeKey = KeyCode.Joystick2Button2;
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().WaterKey = KeyCode.Joystick2Button4;
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().jumpkey = KeyCode.Joystick2Button0;
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().ActionKey = KeyCode.Joystick2Button3;
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().TorchKey = KeyCode.Joystick2Button5;
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().reviveKey = KeyCode.Joystick2Button1;
                            break;
                        case "3":
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().HorizontalAxisName = "J3.Horizontal";
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().VertcialAxisName = "J3.Vertical";
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().pickAxeKey = KeyCode.Joystick3Button2;
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().WaterKey = KeyCode.Joystick3Button4;
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().jumpkey = KeyCode.Joystick3Button0;
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().ActionKey = KeyCode.Joystick3Button3;
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().TorchKey = KeyCode.Joystick3Button5;
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().reviveKey = KeyCode.Joystick3Button1;
                            break;
                        case "4":
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().HorizontalAxisName = "J4.Horizontal";
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().VertcialAxisName = "J4.Vertical";
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().pickAxeKey = KeyCode.Joystick4Button2;
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().WaterKey = KeyCode.Joystick4Button4;
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().jumpkey = KeyCode.Joystick4Button0;
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().ActionKey = KeyCode.Joystick4Button3;
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().TorchKey = KeyCode.Joystick4Button5;
                            Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().reviveKey = KeyCode.Joystick4Button1;
                            break;
                    }
                    PlayerControllerCount++;
                }
                else
                {

                    Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().leftKey = PlayersKeys[2, 0];
                    Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().rightKey = PlayersKeys[2, 1];
                    Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().goUpKey = PlayersKeys[2, 2];
                    Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().goDownKey = PlayersKeys[2, 3];
                    Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().pickAxeKey = PlayersKeys[2, 4];
                    Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().WaterKey = PlayersKeys[2, 5];
                    Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().jumpkey = PlayersKeys[2, 6];
                    Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().ActionKey = PlayersKeys[2, 7];
                    Players.transform.GetChild(2).gameObject.GetComponent<NonVRPlayerController>().TorchKey = PlayersKeys[2, 8];
                }
            }
           

            if (Player4Activated)
            {
          
                Players.transform.GetChild(3).gameObject.SetActive(true);
                if (Player4ControllerActivated)
                {
                    Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().UseController = true;
                    Players.transform.GetChild(3).gameObject.GetComponent<PlayerInput>().AssignJoystick(playerContolerHandler.CurrentPlayers[PlayerControllerCount]);
                    string Number = playerContolerHandler.CurrentPlayers[PlayerControllerCount].ToNumber();
                    Debug.Log(Number);
                    switch (Number)
                    {
                        case "1":
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().HorizontalAxisName = "J1.Horizontal";
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().VertcialAxisName = "J1.Vertical";
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().pickAxeKey = KeyCode.Joystick1Button2;
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().WaterKey = KeyCode.Joystick1Button4;
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().jumpkey = KeyCode.Joystick1Button0;
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().ActionKey = KeyCode.Joystick1Button3;
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().TorchKey = KeyCode.Joystick1Button5;
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().reviveKey = KeyCode.Joystick1Button1;
                            break;
                        case "2":
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().HorizontalAxisName = "J2.Horizontal";
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().VertcialAxisName = "J2.Vertical";
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().pickAxeKey = KeyCode.Joystick2Button2;
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().WaterKey = KeyCode.Joystick2Button4;
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().jumpkey = KeyCode.Joystick2Button0;
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().ActionKey = KeyCode.Joystick2Button3;
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().TorchKey = KeyCode.Joystick2Button5;
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().reviveKey = KeyCode.Joystick2Button1;
                            break;
                        case "3":
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().HorizontalAxisName = "J3.Horizontal";
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().VertcialAxisName = "J3.Vertical";
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().pickAxeKey = KeyCode.Joystick3Button2;
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().WaterKey = KeyCode.Joystick3Button4;
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().jumpkey = KeyCode.Joystick3Button0;
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().ActionKey = KeyCode.Joystick3Button3;
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().TorchKey = KeyCode.Joystick3Button5;
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().reviveKey = KeyCode.Joystick3Button1;
                            break;
                        case "4":
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().HorizontalAxisName = "J4.Horizontal";
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().VertcialAxisName = "J4.Vertical";
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().pickAxeKey = KeyCode.Joystick4Button2;
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().WaterKey = KeyCode.Joystick4Button4;
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().jumpkey = KeyCode.Joystick4Button0;
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().ActionKey = KeyCode.Joystick4Button3;
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().TorchKey = KeyCode.Joystick4Button5;
                            Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().reviveKey = KeyCode.Joystick4Button1;
                            break;
                    }
                    PlayerControllerCount++;
                }
                else
                {
                   
                    Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().leftKey = PlayersKeys[3, 0];
                    Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().rightKey = PlayersKeys[3, 1];
                    Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().goUpKey = PlayersKeys[3, 2];
                    Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().goDownKey = PlayersKeys[3, 3];
                    Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().pickAxeKey = PlayersKeys[3, 4];
                    Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().WaterKey = PlayersKeys[3, 5];
                    Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().jumpkey = PlayersKeys[3, 6];
                    Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().ActionKey = PlayersKeys[3, 7];
                    Players.transform.GetChild(3).gameObject.GetComponent<NonVRPlayerController>().TorchKey = PlayersKeys[3, 8];
                }
            }
           
            PlayerControllerCount = 0;
        }

    }
    // Update is called once per frame
    public void StartGame()
    {
        GameObject Players = GameObject.Find("Players");

        for (int i = 0; i < Players.transform.childCount; i++)
        {

            for (int a = 0; a < Players.transform.GetChild(i).gameObject.transform.childCount; a++)
            {

                PlayersKeys[i, a] = Players.transform.GetChild(i).gameObject.transform.GetChild(a).gameObject.transform.GetChild(0).GetComponent<ChangeKey>().ChoosenKey;



            }

        }


        if (Player2Activated || Player1Activated || Player4Activated || Player3Activated) {


            GameObject[] dynamites;

            dynamites = GameObject.FindGameObjectsWithTag("Dynamite");

            foreach (GameObject dynamite in dynamites)
            {
                Destroy(dynamite);
            }
            SceneManager.LoadScene("Level");
        }

    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void Information()
    {
        if (Info.activeInHierarchy)
        {
            Info.SetActive(false);
            PlayerCanvas.SetActive(true);
            MockPlayer1.SetActive(true);
            MockPlayer2.SetActive(true);
            MockPlayer3.SetActive(true);
            MockPlayer4.SetActive(true);
        }
        else
        {
            Info.SetActive(true);
            PlayerCanvas.SetActive(false);
            MockPlayer1.SetActive(false);
            MockPlayer2.SetActive(false);
            MockPlayer3.SetActive(false);
            MockPlayer4.SetActive(false);
        }

    }


    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    public void TogglePlayer1active()
    {
        Player1Activated = true;
    }
    public void TogglePlayer2active()
    {
        Player2Activated = true;
    }

    public void TogglePlayer3active()
    {
        Player3Activated = true;
    }

    public void TogglePlayer4active()
    {
        Player4Activated = true;
    }
    public void TogglePlayer1deactivate()
    {
        Player1Activated = false;
    }


    public void TogglePlayer2deactivate()
    {
        Player2Activated = false;
    }

    public void TogglePlayer3deactivate()
    {
        Player3Activated = false;
    }

    public void TogglePlayer4deactivate()
    {
        Player4Activated = false;
    }

}





