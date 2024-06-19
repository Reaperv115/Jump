using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    public float pregamecountDown;
    [HideInInspector]
    public bool gamehasStarted;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            print("Trying to create multiple instances of GameManager");

        gamehasStarted = false;
        pregamecountDown = 0f;
    }

    private void Update()
    {
        // if player gets caught by rope, stop the game
        if (PlayerManager.Instance.GetPlayerRef().GetGotCaught())
            gamehasStarted = false;

            

        if (pregamecountDown > 0f && gamehasStarted)
            pregamecountDown -= Time.deltaTime;
    }

    public void EndRound()
    {
        RopeManager.instance.SetMode("Defeat");
        pregamecountDown = 3f;
    }
}
