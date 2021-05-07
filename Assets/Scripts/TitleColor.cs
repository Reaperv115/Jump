using TMPro;
using UnityEngine;

public class TitleColor : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI[] title;

    Color[] colors = { Color.red, Color.blue, Color.black, Color.cyan, Color.green, Color.magenta, Color.yellow };

    float colorTimer = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (colorTimer <= 0.0f)
        {
            int titleIndex = Random.Range(0, title.Length);
            int colorIndex = Random.Range(0, colors.Length);
            title[titleIndex].color = colors[colorIndex];
            colorTimer = 0.5f;
        }
        else
        {
            colorTimer -= Time.deltaTime;
        }
    }
}
