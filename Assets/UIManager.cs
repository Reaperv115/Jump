using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    // Game scene UI
    GameObject backtomainmenuBtn, backtomainmenuBtnInst;
    GameObject regularmodeBtn, regularmodeBtnInst;
    GameObject replayGameBtn, replaygameBtnInst;
    GameObject ropespeedSlider, ropespeedSliderInst;
    GameObject toggleAccoladesBtn, toggleAccoladesBtnInst;

    // MainMenu UI
    GameObject exitBtn, exitbtnInst;
    GameObject startBtn, startbtnInst;
    GameObject characterselectionDrpDwn, characterselectionDrpDwnInst;
    GameObject aboutgameBtn, aboutgameBtnInst;

    // Main Menu Button Positions
    [SerializeField]
    GameObject exitBtnPosition;
    [SerializeField]
    GameObject startBtnPosition;
    [SerializeField]
    GameObject characterselectionBtnPosition;
    [SerializeField]
    GameObject aboutgameBtnPosition;

    GameObject canvas;

    Scene currScene, prevScene;


    int playercharacterChoice;


    private void Awake()
    {
        //Game UI
        backtomainmenuBtn = Resources.Load<GameObject>("UI/Game UI/BAckToMainMenuBtn");
        regularmodeBtn = Resources.Load<GameObject>("UI/Game UI/RegularModeBtn");
        replayGameBtn = Resources.Load<GameObject>("UI/Game UI/ReplayGameBtn");
        ropespeedSlider = Resources.Load<GameObject>("UI/Game UI/RopeSpeedSlider");
        toggleAccoladesBtn = Resources.Load<GameObject>("UI/Game UI/ToggleAccoladesBtn");
        


        // Main Menu UI
        exitBtn = Resources.Load<GameObject>("UI/Main Menu UI/ExitBtn");
        startBtn = Resources.Load<GameObject>("UI/Main Menu UI/StartBtn");
        characterselectionDrpDwn = Resources.Load<GameObject>("UI/Main Menu UI/character selection");
        playercharacterChoice = characterselectionDrpDwn.GetComponent<TMP_Dropdown>().value;
        aboutgameBtn = Resources.Load<GameObject>("UI/Main Menu UI/AboutGameBtn");

        
        canvas = GameObject.Find("Canvas");
    }
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("trying to create multiple instances of Ui Manager");
        InstantiateMainMenuUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.HasSwitchedScenes())
        {
            currScene = SceneManager.GetActiveScene();
            switch (currScene.name)
            {
                case "MainMenu":
                   InstantiateMainMenuUI();
                   DisableGameUI();
                   GameManager.instance.SwitchScenes(false);
                   break;
                case "Game":
                    InstantiateGameUI();
                    DisableMainMenuUI();
                    GameManager.instance.SwitchScenes(false);
                    break;
            }
        }
    }

    void InstantiateGameUI()
    {
        backtomainmenuBtnInst = Instantiate(backtomainmenuBtn, backtomainmenuBtn.transform.position, backtomainmenuBtn.transform.rotation, canvas.transform);
        regularmodeBtnInst = Instantiate(regularmodeBtn, regularmodeBtn.transform.position, regularmodeBtn.transform.rotation, canvas.transform);
        replaygameBtnInst = Instantiate(replayGameBtn, replayGameBtn.transform.position, replayGameBtn.transform.rotation, canvas.transform);
        ropespeedSliderInst = Instantiate(ropespeedSlider, ropespeedSlider.transform.position, ropespeedSlider.transform.rotation, canvas.transform);
        toggleAccoladesBtnInst = Instantiate(toggleAccoladesBtn, toggleAccoladesBtn.transform.position, toggleAccoladesBtn.transform.rotation, canvas.transform);
    }
    void DisableGameUI()
    {
        Destroy(backtomainmenuBtnInst);
        Destroy(regularmodeBtnInst);
        Destroy(replaygameBtnInst);
        Destroy(ropespeedSliderInst);
        Destroy(toggleAccoladesBtnInst);
    }

    void InstantiateMainMenuUI()
    {
        exitbtnInst = Instantiate(exitBtn, exitBtnPosition.transform.position, exitBtn.transform.rotation, canvas.transform);
        startbtnInst = Instantiate(startBtn, startBtnPosition.transform.position, startBtn.transform.rotation, canvas.transform);
        characterselectionDrpDwnInst = Instantiate(characterselectionDrpDwn, characterselectionBtnPosition.transform.position, characterselectionDrpDwn.transform.rotation, canvas.transform);
        aboutgameBtnInst = Instantiate(aboutgameBtn, aboutgameBtnPosition.transform.position, aboutgameBtn.transform.rotation, canvas.transform);
    }
    void DisableMainMenuUI()
    {
        Destroy(exitbtnInst);
        Destroy(startbtnInst);
        Destroy(characterselectionDrpDwnInst);
        Destroy(aboutgameBtnInst);
    }

    public GameObject GetRopeSpeedSlider() { return ropespeedSliderInst; }
    public int GetPlayerCharacterChoice() { return playercharacterChoice; }
    public TMP_Dropdown GetCharacterSelectionDrpDwn() { return characterselectionDrpDwn.GetComponent<TMP_Dropdown>(); }
    public void SetPlayerCharacterChoice(int choice) { playercharacterChoice = choice;}
}
