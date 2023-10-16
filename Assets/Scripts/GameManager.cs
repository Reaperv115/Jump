using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private bool switchedScenes;

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
    }



    public bool HasSwitchedScenes() { return switchedScenes; }
    public void SwitchScenes(bool switchedscenes) { switchedScenes = switchedscenes; }
}
