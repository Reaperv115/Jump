using TMPro;
using UnityEngine;

public class DisplayAccolades : MonoBehaviour
{
    [SerializeField]
    GameObject[] accolades;
    // Update is called once per frame
    void Update()
    {
        accolades[0].GetComponent<TextMeshProUGUI>().text = "Count: " + SaveData.current.profile.numBronze;
        accolades[1].GetComponent<TextMeshProUGUI>().text = "Count: " + SaveData.current.profile.numSilver;
        accolades[2].GetComponent<TextMeshProUGUI>().text = "Count: " + SaveData.current.profile.numGold;
        accolades[3].GetComponent<TextMeshProUGUI>().text = "Count: " + SaveData.current.profile.numPlat;
        accolades[4].GetComponent<TextMeshProUGUI>().text = "Count: " + SaveData.current.profile.numWhy;
        accolades[5].GetComponent<TextMeshProUGUI>().text = "Count: " + SaveData.current.profile.numGetLit;
    }
}
