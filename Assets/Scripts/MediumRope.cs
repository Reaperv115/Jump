using UnityEngine;
using UnityEngine.UI;

public class MediumRope : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(BeginMediumRope);
    }

    public void BeginMediumRope()
    {
        // begin the game with a medium speed rope
        GameManager.instance.pregamecountDown = 3f;
        var canv = GameObject.Find("Canvas");
        for (int i = 0; i < canv.transform.GetChild(1).childCount; i++) 
            canv.transform.GetChild(1).GetChild(i).gameObject.SetActive(false);
        RopeManager.instance.SetRopeSpeed(10f);
        GameManager.instance.gamehasStarted = true;
    }
}
