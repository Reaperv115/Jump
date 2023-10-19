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
    }

    // Update is called once per frame
    void Update()
    {
        // displaying what speed the rope would be moving at if player began the game
        ropespeedDisplay.text = "Speed of Rope: " + (int)ropeSpeed.value;
    }
}
