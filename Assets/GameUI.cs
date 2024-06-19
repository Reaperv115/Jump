using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    // text objects
    GameObject countdownTimer;
    GameObject personalBest;
    GameObject numjumpscurrTurn;

    // player object
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // searching the Text gameobject of the canvas to find relevant text objects
        personalBest = GameObject.Find("Text").transform.GetChild(1).gameObject;
        numjumpscurrTurn = GameObject.Find("Text").transform.GetChild(2).gameObject;
        countdownTimer = GameObject.Find("Text").transform.GetChild(3).gameObject;

        // getting a reference to the player gameobject
        player = PlayerManager.Instance.GetPlayerGO();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (GameManager.instance.pregamecountDown > 0f)
        {
            countdownTimer.GetComponent<TextMeshProUGUI>().text = "Game Will Begin In: " + (int)GameManager.instance.pregamecountDown;
            GameManager.instance.pregamecountDown -= Time.deltaTime;
        }
        else
            countdownTimer.GetComponent<TextMeshProUGUI>().text = "";
    }
}
