using UnityEngine;
using UnityEngine.UI;

public class MediumMode : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(BeginMediumMode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BeginMediumMode()
    {
        // begin the game with a slow rope
        GameManager.instance.pregamecountDown = 3f;
        var canv = GameObject.Find("Canvas");
        for (int i = 0; i < canv.transform.GetChild(1).childCount; i++)
            canv.transform.GetChild(1).GetChild(i).gameObject.SetActive(false);
        RopeManager.instance.SetMode("Medium");
        GameManager.instance.gamehasStarted = true;
    }
}
