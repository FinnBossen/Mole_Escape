using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class WandScript : MonoBehaviour
{
    private LineRenderer laserLineRenderer;
    private float laserWidth = 0.01f;
    private float laserMaxLength = 20f;
    public int ChoosenEnemy = 0;
    public List<GameObject> EnemySpawn;
    private Vector3 SpawnPosition;
    bool Canspawn = false;
    public SteamVR_Action_Boolean TriggerClick;
    private SteamVR_Input_Sources inputSource;
    public bool Shoot = false;
    public GameObject NormalHand;
    

    private void OnEnable()
    {
        TriggerClick.AddOnStateDownListener(Press, inputSource);
    }

    private void OnDisable()
    {
        TriggerClick.RemoveOnStateDownListener(Press, inputSource);
    }

    void Start()
    {
        laserLineRenderer = gameObject.GetComponent<LineRenderer>();
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);
        laserLineRenderer.SetWidth(laserWidth, laserWidth);
    }



    void Update()
    {
        
            ShootLaserFromTargetPosition(transform.position, Vector3.forward, laserMaxLength);
            laserLineRenderer.enabled = true;

        if (Shoot)
        {
            if (Canspawn) {
            Instantiate(EnemySpawn[ChoosenEnemy], SpawnPosition + new Vector3(0, 3f, 0), Quaternion.identity);
            Shoot = false;
            }
        }
  
    }

    void ShootLaserFromTargetPosition(Vector3 targetPosition, Vector3 direction, float length)
    {


       

        Vector3 fwd = gameObject.transform.TransformDirection(Vector3.up);
        RaycastHit hit;
        int layer_mask = LayerMask.GetMask("Ground");
        Debug.DrawRay(gameObject.transform.position, fwd * 50, Color.red);
        if (Physics.Raycast(gameObject.transform.position, fwd, out hit,100f ,layer_mask))
        {

                Canspawn = true;
                SpawnPosition = hit.point;

        }
        else
        {
            Canspawn = false;
        }
        RaycastHit hit2;
        if (Physics.Raycast(gameObject.transform.position, fwd, out hit2))
        {



        }
        laserLineRenderer.SetPosition(0, targetPosition);
        laserLineRenderer.SetPosition(1, hit2.point);

    }
    private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("trigger wand clicked");
        if (Canspawn)
        {
            NormalHand.SetActive(true);
            gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
            Debug.Log("trigger wand spawned");
            Instantiate(EnemySpawn[ChoosenEnemy], SpawnPosition + new Vector3(0, 3f, 0), Quaternion.identity);
        }
    }

  
       

}
