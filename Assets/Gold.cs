using TMPro;
using UnityEngine;

public class Gold : MonoBehaviour
{
    TextMeshProUGUI goldCount;
    int numGold;

    // Start is called before the first frame update
    void Start()
    {
        goldCount = GameObject.Find("gold count").GetComponent<TextMeshProUGUI>();
        numGold = 0;
    }

    // Update is called once per frame
    void Update()
    {
        goldCount.text = "Count: " + numGold;
    }
}
