using TMPro;
using UnityEngine;

public class NumberofJumps : MonoBehaviour
{
    GameObject numberofJumps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numberofJumps = GameObject.Find("Text").transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        numberofJumps.GetComponent<TextMeshProUGUI>().text = "Jumps: " + PlayerManager.Instance.GetNumofJumps();
    }
}
