using TMPro;
using UnityEngine;

public class Bronze : MonoBehaviour
{
    GameObject displayAccolades;
    TextMeshProUGUI bronzeCount;

    // Start is called before the first frame update
    void Start()
    {
        displayAccolades = GameObject.Find("Accolade Displays");
        bronzeCount = displayAccolades.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        bronzeCount.text = "Count: " + SaveData.current.profile.numBronze.ToString();
    }
}
