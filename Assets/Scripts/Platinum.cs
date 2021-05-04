using TMPro;
using UnityEngine;

public class Platinum : MonoBehaviour
{
    TextMeshProUGUI platCount;

    // Start is called before the first frame update
    void Start()
    {
        platCount = GameObject.Find("platinum count").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        platCount.text = "Count: " + SaveData.current.profile.numPlat.ToString();
    }
}
