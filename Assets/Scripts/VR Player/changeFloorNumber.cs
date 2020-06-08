using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class changeFloorNumber : MonoBehaviour
{
    private TextMeshPro FloorNumber;
    private int CurrentFloor = 1;
    // Start is called before the first frame update
    void Start()
    {
        FloorNumber = gameObject.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    public void ChangeNumberUp()
    {
        if (CurrentFloor < 6) {
            CurrentFloor++;
            FloorNumber.text = CurrentFloor.ToString();
        }
    }
    public void ChangeNumberDown()
    {
        if (CurrentFloor > 0)
        {
            CurrentFloor--;
            FloorNumber.text = CurrentFloor.ToString();
        }

    }

}
