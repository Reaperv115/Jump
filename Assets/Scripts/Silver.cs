using TMPro;
using UnityEngine;

public class Silver : MonoBehaviour
{
    TextMeshProUGUI silverCount;
    int numSilver;

    // Start is called before the first frame update
    void Start()
    {
        silverCount = GameObject.Find("silver count").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        silverCount.text = "Count: " + SaveData.current.profile.numSilver.ToString();
    }
}
