using TMPro;
using UnityEngine;

public class Why : MonoBehaviour
{
    GameObject accoladesDisplay;
    TextMeshProUGUI whyCount;

    SpriteRenderer spriteRenderer;
    float colorTimer = 3.0f;

    Color[] colors = { Color.green, Color.red, Color.blue, Color.black, Color.cyan };

    // Start is called before the first frame update
    void Start()
    {
        accoladesDisplay = GameObject.Find("Accolades");
        whyCount = accoladesDisplay.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (colorTimer <= 0.0f)
        {
            int col = Random.Range(0, colors.Length);
            spriteRenderer.color = colors[col];
            colorTimer = 3.0f;
        }
        else
            colorTimer -= Time.deltaTime;
        
        
        whyCount.text = "Count: " + SaveData.current.profile.numWhy.ToString();
    }
}
