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
    }

    // Update is called once per frame
    void Update()
    {
        whyCount.text = "Count: " + SaveData.current.profile.numWhy.ToString();
    }
}
