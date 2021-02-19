using TMPro;
using UnityEngine;

public class Platinum : MonoBehaviour
{
    TextMeshProUGUI platCount;
    int numPlat;

    // Start is called before the first frame update
    void Start()
    {
        platCount = GameObject.Find("platinum count").GetComponent<TextMeshProUGUI>();
        numPlat = 0;
    }

    // Update is called once per frame
    void Update()
    {
        platCount.text = "Count: " + numPlat;
    }
}
