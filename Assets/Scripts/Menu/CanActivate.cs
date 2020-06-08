using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanActivate : MonoBehaviour
{

    public GameObject PlayerBefore;
    public GameObject PlayerToActivate;
    public GameObject PlayerAfter;
    public GameObject StartingInfo;
    public GameObject DeactivateInfo;
    public GameObject ControllerInfo;
    public GameObject SpawnHandler;
    private PlayerSpawnHandler playerSpawnHandler;

  
    // Start is called before the first frame update
    void Start()
    {
        playerSpawnHandler = SpawnHandler.GetComponent<PlayerSpawnHandler>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ActivateDeactivateIfCan()
    {
         if (!PlayerToActivate.active) {
                PlayerToActivate.SetActive(true);
                DeactivateInfo.SetActive(true);
                ControllerInfo.SetActive(false);
            if (PlayerToActivate.name == "Player1")
            {
                playerSpawnHandler.TogglePlayer1active();
            }
                if (PlayerToActivate.name == "Player2")
                {
                    playerSpawnHandler.TogglePlayer2active();
                }

                if (PlayerToActivate.name == "Player3")
                {
                    playerSpawnHandler.TogglePlayer3active();
                }

                if (PlayerToActivate.name == "Player4")
                {
                    playerSpawnHandler.TogglePlayer4active();
                }
                StartingInfo.SetActive(false);
            }
            else if (PlayerToActivate.active ) {
                PlayerToActivate.SetActive(false);
                StartingInfo.SetActive(true);
                ControllerInfo.SetActive(true);

            if (PlayerToActivate.name == "Player1")
            {
                playerSpawnHandler.TogglePlayer1deactivate();
            }
                if (PlayerToActivate.name == "Player2")
                {
                    playerSpawnHandler.TogglePlayer2deactivate();
                }

                if (PlayerToActivate.name == "Player3")
                {
                    playerSpawnHandler.TogglePlayer3deactivate();
                }

                if (PlayerToActivate.name == "Player4")
                {
                    playerSpawnHandler.TogglePlayer4deactivate();
                }
                DeactivateInfo.SetActive(false);
            }
        
    }

    

 
}
