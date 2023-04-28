using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private bool switchedScenes;

    bool gamehasStarted = false;

    float countDown;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            print("Trying to create multiple instances of GameManager");
        countDown = 3f;
    }

    public bool HasSwitchedScenes() { return switchedScenes; }
    public void SwitchScenes(bool switchedscenes) { switchedScenes = switchedscenes; }
    public bool GetGameHasStarted() { return gamehasStarted; }
    public void SetGameHasStarted(bool gamestarted) { gamehasStarted = gamestarted; }
    public float GetGameCountDown() { return countDown;}
    public void SetGameCountDown(float countdown) { countDown = countdown; }
}
