using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class PlayerContolerHandler : MonoBehaviour
{

    [SerializeField] GameObject PlayerSlots;
    [SerializeField] int playerCount = 4;
    InputRecognizer inputRecognizer;
    public GameObject PlayerSpawnHandlerObject;
    private PlayerSpawnHandler playerSpawnHandler;

    public GameObject Player1KeyboardActivate;
    public GameObject Player2KeyboardActivate;
    public GameObject Player3KeyboardActivate;
    public GameObject Player4KeyboardActivate;
    public GameObject Player1ControllerActivate;
    public GameObject Player2ControllerActivate;
    public GameObject Player3ControllerActivate;
    public GameObject Player4ControllerActivate;
    public GameObject Player1ControllerActivated;
    public GameObject Player2ControllerActivated;
    public GameObject Player3ControllerActivated;
    public GameObject Player4ControllerActivated;

  GameObject[] JoystickNumberandSLot = new GameObject[20];
    int[] PlayerNumberAssignedToController= new int[20];
    private bool deactivated = false;
    bool CanPressAgain = true;
    bool CanPressAgain2 = true;
    [Inject]
    public void Construct(InputRecognizer inputRecognizer)
    {
        this.inputRecognizer = inputRecognizer;
    }

    private void Start()
    {
        playerSpawnHandler = PlayerSpawnHandlerObject.GetComponent<PlayerSpawnHandler>();
    }
    public List<Joystick> CurrentPlayers { get; private set; } = new List<Joystick>();

    private void Awake()
    {
        
    }
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        if(scene.name == "Level")
        {
            deactivated = true;
        }
        else
        {
            deactivated = false;
        }
        Debug.Log(mode);
    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    IEnumerator Wait()
    {
       
        yield return new WaitForSeconds(4);
        CanPressAgain = true;
    }

    IEnumerator Wait2()
    {

        yield return new WaitForSeconds(4);
        CanPressAgain2 = true;
    }
    void FixedUpdate()
    {
        if (!deactivated) {

            if (CanPressAgain) { 
        var PressedStart = inputRecognizer
                 .GetJoystickWichPress(JoystickButton.Start);

        foreach (Joystick joystick in CurrentPlayers)
        {
            Debug.Log("StartPressed");
            foreach (var player in PressedStart)
            {
                if (player == joystick) {


                    CurrentPlayers.Remove(joystick);
                    player.ToNumber();
                    Debug.Log(player.ToNumber());
                    Debug.Log(Int32.Parse(player.ToNumber()));
                    for (int a = 0; a < JoystickNumberandSLot[Int32.Parse(player.ToNumber())].transform.childCount; ++a)
                    {
                        JoystickNumberandSLot[Int32.Parse(player.ToNumber())].transform.GetChild(a).gameObject.SetActive(true);
                    }
                    JoystickNumberandSLot[Int32.Parse(player.ToNumber())].SetActive(false);


                    int PlayerToDeactivate = PlayerNumberAssignedToController[Int32.Parse(player.ToNumber())];

                    if (PlayerToDeactivate == 0)
                    {
                        Player1ControllerActivate.SetActive(true);
                                Player1KeyboardActivate.SetActive(true);
                        Player1ControllerActivated.SetActive(false);
                        playerSpawnHandler.Player1ControllerActivated = false;
                                playerSpawnHandler.Player1Activated = false;

                            }

                    if (PlayerToDeactivate == 1)
                    {
                                Player2KeyboardActivate.SetActive(true);
                                Player2ControllerActivate.SetActive(true);
                        Player2ControllerActivated.SetActive(false);
                        playerSpawnHandler.Player2ControllerActivated = false;
                        playerSpawnHandler.Player2Activated = false;
                    }

                    if (PlayerToDeactivate == 2)
                    {
                                Player3KeyboardActivate.SetActive(true);
                                Player3ControllerActivate.SetActive(true);
                        Player3ControllerActivated.SetActive(false);
                        playerSpawnHandler.Player3ControllerActivated = false;
                        playerSpawnHandler.Player3Activated = false;
                    }

                    if (PlayerToDeactivate == 3)
                    {
                                Player4KeyboardActivate.SetActive(true);
                                Player4ControllerActivate.SetActive(true);
                        Player4ControllerActivated.SetActive(false);
                        playerSpawnHandler.Player4ControllerActivated = false;
                        playerSpawnHandler.Player4Activated = false;
                    }

                        
                            CanPressAgain2 = false;
                            StartCoroutine(Wait2());
                        }
            }

            PressedStart = Enumerable.Empty<Joystick>();

        }
            }


            if (CanPressAgain2) { 
            var newPlayers = inputRecognizer
                .GetJoystickWichPress(JoystickButton.Start)
                .Except(CurrentPlayers)
                .ToArray();
       

        if (!newPlayers.Any())
            return;

        var playersToBeAdded = newPlayers.Take(playerCount - CurrentPlayers.Count);

        foreach (var playerJoystick in playersToBeAdded)
        {
            Debug.Log(playerJoystick.ToNumber());
           
          CurrentPlayers.Add(playerJoystick);
            for (int i = 0; i < PlayerSlots.transform.childCount; ++i)
            {
                if (!PlayerSlots.transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    PlayerSlots.transform.GetChild(i).gameObject.SetActive(true);

                    for (int a = 0; a < PlayerSlots.transform.GetChild(i).gameObject.transform.childCount; ++a)
                    {
                        PlayerSlots.transform.GetChild(i).gameObject.transform.GetChild(a).gameObject.SetActive(false);
                    }

                    JoystickNumberandSLot[Int32.Parse(playerJoystick.ToNumber())] = PlayerSlots.transform.GetChild(i).gameObject;
                    if (i == 0)
                    {
                                Player1KeyboardActivate.SetActive(false);
                                Player1ControllerActivate.SetActive(false);
                        Player1ControllerActivated.SetActive(true);
                                playerSpawnHandler.Player1Activated = true;
                                playerSpawnHandler.Player1ControllerActivated = true;
                        PlayerNumberAssignedToController[Int32.Parse(playerJoystick.ToNumber())] = 0;
                        }

                    if (i == 1)
                    {
                                Player2KeyboardActivate.SetActive(false);
                                Player2ControllerActivate.SetActive(false);
                        Player2ControllerActivated.SetActive(true);
                        playerSpawnHandler.Player2ControllerActivated = true;
                            playerSpawnHandler.Player2Activated = true;
                        PlayerNumberAssignedToController[Int32.Parse(playerJoystick.ToNumber())] = 1;
                    }

                    if (i == 2)
                    {
                                Player3KeyboardActivate.SetActive(false);
                                Player3ControllerActivate.SetActive(false);
                        Player3ControllerActivated.SetActive(true);
                        playerSpawnHandler.Player3ControllerActivated = true;
                            playerSpawnHandler.Player3Activated = true;
                        PlayerNumberAssignedToController[Int32.Parse(playerJoystick.ToNumber())] = 2;
                    }

                    if (i == 3)
                    {
                                Player4KeyboardActivate.SetActive(false);
                                Player4ControllerActivate.SetActive(false);
                        Player4ControllerActivated.SetActive(true);
                        playerSpawnHandler.Player4ControllerActivated = true;
                            playerSpawnHandler.Player4Activated = true;
                        PlayerNumberAssignedToController[Int32.Parse(playerJoystick.ToNumber())] = 3;
                    }

                            CanPressAgain = false;
                            StartCoroutine(Wait());
                            break; //   get out of the loop
                }

                Debug.Log("Hallo");
            }

          
        }
            }
        }

    }

}


