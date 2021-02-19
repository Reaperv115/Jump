using TMPro;
using UnityEngine;

public class Bronze : MonoBehaviour
{
    TextMeshProUGUI bronzeCount;
    int numBronze;

    // Start is called before the first frame update
    void Start()
    {
        bronzeCount = GameObject.Find("bronze count").GetComponent<TextMeshProUGUI>();
        numBronze = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bronzeCount.text = "Count: " + numBronze;
    }
}
