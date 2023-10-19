using UnityEngine;
using UnityEngine.UI;

public class FastRope : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(BeginFastRope);
    }

    void BeginFastRope()
    {
        // begin the game with a fast rope
        GameManager.instance.pregamecountDown = 3f;
        var canv = GameObject.Find("Canvas");
        for (int i = 0; i < canv.transform.GetChild(1).childCount; i++)
            canv.transform.GetChild(1).GetChild(i).gameObject.SetActive(false);
        RopeManager.instance.SetRopeSpeed(15f);
        GameManager.instance.gamehasStarted = true;
    }
}
