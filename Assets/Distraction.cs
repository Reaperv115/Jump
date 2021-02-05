using TMPro;
using UnityEngine;

public class Distraction : MonoBehaviour
{
    TextMeshProUGUI distractingText;

    // Start is called before the first frame update
    void Start()
    {
        distractingText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        distractingText.text = "distraction!";
    }
}
