using TMPro;
using UnityEngine;

public class Silver : MonoBehaviour
{
    GameObject displayAccolades;
    TextMeshProUGUI silverCount;

    // Start is called before the first frame update
    void Start()
    {
        displayAccolades = GameObject.Find("Accolades");
        silverCount = displayAccolades.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        silverCount.text = "Count: " + SaveData.current.profile.numBronze.ToString();
    }
}