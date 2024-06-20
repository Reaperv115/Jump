using TMPro;
using UnityEngine;

public class PregameCountdown : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
       
        if (GameManager.instance.pregamecountDown > 0f)
        {
            GetComponent<TextMeshProUGUI>().text = "Game Will Begin In: " + (int)GameManager.instance.pregamecountDown;
            GameManager.instance.pregamecountDown -= Time.deltaTime;
        }
        else
            GetComponent<TextMeshProUGUI>().text = "";
    }
}
