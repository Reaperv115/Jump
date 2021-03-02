using TMPro;
using UnityEngine;

public class Bronze : MonoBehaviour
{
    TextMeshProUGUI bronzeCount;

    // Start is called before the first frame update
    void Start()
    {
        bronzeCount = GameObject.Find("bronze count").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        bronzeCount.text = "Count: " + SaveData.current.profile.numBronze.ToString();
    }
}
