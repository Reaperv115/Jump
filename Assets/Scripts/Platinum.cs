using TMPro;
using UnityEngine;

public class Platinum : MonoBehaviour
{
    GameObject displayAccolades;
    TextMeshProUGUI platCount;

    // Start is called before the first frame update
    void Start()
    {
        displayAccolades = GameObject.Find("Accolades");
        platCount = displayAccolades.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        platCount.text = "Count: " + SaveData.current.profile.numBronze.ToString();
    }
}