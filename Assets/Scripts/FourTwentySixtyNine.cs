using TMPro;
using UnityEngine;

public class FourTwentySixtyNine : MonoBehaviour
{
    GameObject displayAccolades;
    TextMeshProUGUI FTSNCount;

    // Start is called before the first frame update
    void Start()
    {
        displayAccolades = GameObject.Find("Accolade Displays");
        FTSNCount = displayAccolades.transform.GetChild(5).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        FTSNCount.text = "Count: " + SaveData.current.profile.numGetLit.ToString();
    }
}