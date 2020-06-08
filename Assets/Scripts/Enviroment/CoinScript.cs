using UnityEngine;
using TMPro;

public class CoinScript : MonoBehaviour
{
    private TextMeshPro CoinCount;
    // Start is called before the first frame update
    void Start()
    {
        CoinCount = gameObject.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CoinCount.text = GameManager.CoinCount.ToString();
    }
}
