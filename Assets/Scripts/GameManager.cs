using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    

    bool gamehasStarted = false;
    private bool switchedScenes;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            print("Trying to create multiple instances of GameManager");
    }

    public bool HasSwitchedScenes() { return switchedScenes; }
    public void SwitchScenes(bool switchedscenes) { switchedScenes = switchedscenes; }
}
