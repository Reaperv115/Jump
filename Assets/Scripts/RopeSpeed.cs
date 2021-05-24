using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RopeSpeed : MonoBehaviour
{
    Slider ropeSpeed;
    TextMeshProUGUI ropespeedDisplay;

    // Start is called before the first frame update

    void Start()
    {
        ropeSpeed = GetComponent<Slider>();
        ropespeedDisplay = GameObject.Find("Rope Speed Display").GetComponent<TextMeshProUGUI>();
        Debug.Log(ropespeedDisplay);
    }

    // Update is called once per frame
    void Update()
    {
        ropespeedDisplay.text = "Speed of Rope: " + ropeSpeed.value.ToString();
    }
}
