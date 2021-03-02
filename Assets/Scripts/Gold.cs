using TMPro;
using UnityEngine;

public class Gold : MonoBehaviour
{
    TextMeshProUGUI goldCount;

    // Start is called before the first frame update
    void Start()
    {
        goldCount = GameObject.Find("gold count").GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        goldCount.text = "Count: " + SaveData.current.profile.numGold.ToString();
    }
}
