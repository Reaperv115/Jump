using TMPro;
using UnityEngine;

public class Gold : MonoBehaviour
{
    GameObject displayAccolades;
    TextMeshProUGUI goldCount;

    // Start is called before the first frame update
    void Start()
    {
        displayAccolades = GameObject.Find("Accolade Displays");
        goldCount = displayAccolades.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        goldCount.text = "Count: " + SaveData.current.profile.numBronze.ToString();
    }
}