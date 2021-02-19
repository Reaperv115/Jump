using TMPro;
using UnityEngine;

public class Why : MonoBehaviour
{
    TextMeshProUGUI whyCount;
    int numWhy;

    // Start is called before the first frame update
    void Start()
    {
        whyCount = GameObject.Find("why count").GetComponent<TextMeshProUGUI>();
        numWhy = 0;
    }

    // Update is called once per frame
    void Update()
    {
        whyCount.text = "Count: " + numWhy;
    }
}
