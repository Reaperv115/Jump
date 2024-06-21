using UnityEngine;
using UnityEngine.UI;

public class ImpossibleMode : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(BeginImpossibleMode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BeginImpossibleMode()
    {
        // begin the game with a slow rope
        GameManager.instance.pregamecountDown = 3f;
        var canv = GameObject.Find("Canvas");
        for (int i = 0; i < canv.transform.GetChild(1).childCount; i++)
            canv.transform.GetChild(1).GetChild(i).gameObject.SetActive(false);
        RopeManager.instance.SetMode("Impossible");
        GameManager.instance.gamehasStarted = true;
    }
}
