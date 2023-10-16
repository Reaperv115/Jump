using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;


    GameObject personalBest;
    GameObject numjumpsthisTurnTxt;

    GameObject gameCanvas, gamecanvasInst;
    GameObject mainmenuCanvas;

    GameObject countdownTimer;

    bool instantiated = false;

    Scene scene;

    int playercharacterChoice;
    GameObject[] gamecanvasBtns;


    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("trying to create multiple instances of UI Manager");
        SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/Data.saves");

        scene = SceneManager.GetActiveScene();
        if (scene.name.Equals("Game"))
            gameCanvas = GameObject.Find("Canvas");
        else
            mainmenuCanvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        //scene = SceneManager.GetActiveScene();
        //switch (scene.name)
        //{
        //    case "MainMenu":
        //        if (instantiated.Equals(false))
        //        {
        //            InstantiateMainMenuUI();
        //            instantiated = true;
        //        }
        //        break;
        //    case "Game":
        //        if (instantiated.Equals(false))
        //        {
        //            InstantiateGameUI();
        //            instantiated = true;
        //        }
        //        if (GameManager.instance.gamehasStarted)
        //        {
        //            countdownTimer = FindCanvasObject(0, gameCanvas, "Countdown");
                    
        //            countdownTimer.GetComponent<TextMeshProUGUI>().text = "Game Will Start In: " + GameManager.instance.pregamecountDown.ToString();
        //            GameManager.instance.pregamecountDown -= Time.deltaTime;

        //        }
        //        break;
        //    default:
        //        break;
        //}
        

    }


    public GameObject GetBasicModeOptions() 
    {
        GameObject basicmodeOptions = FindCanvasObject(gamecanvasInst, "Options");
        return basicmodeOptions;
    }
    public GameObject GetYourChoiceButton()
    {
        GameObject yourchoiceButton = FindCanvasObject(gamecanvasInst, "Choice");
        return yourchoiceButton;
    }
    public GameObject GetRopeSpeedSlider()
    {
        return FindCanvasObject(gamecanvasInst, "Slider");
    }

    public GameObject GetBasicModeBtn()
    {
        return FindCanvasObject(gamecanvasInst, "Basic");
    }
    public GameObject GetPersonalBestDisplay()
    {
        return FindCanvasObject(gameCanvas, "Best");
    }
    public GameObject GetJumpsDisplay()
    {
        return FindCanvasObject(gameCanvas, "Jumps");
    }

    public GameObject GetBackToMenuButton()
    {
        return FindCanvasObject(gameCanvas, "Back");
    }

    public GameObject GetToggleAccoladesButton()
    {
        return FindCanvasObject(gameCanvas, "Accolades");
    }

    public GameObject GetCountDownTimer()
    {
        return FindCanvasObject(1, gameCanvas, "Countdown");
    }

    private GameObject FindCanvasObject(GameObject canv, string obj)
    {
        int i, val = 0;
        for (i = 0; i < canv.transform.GetChild(1).transform.childCount; ++i)
            if (canv.transform.GetChild(1).transform.GetChild(i).name.Contains(obj))
            {
                val = i;
                i = canv.transform.GetChild(1).transform.childCount;
            }
        return canv.transform.GetChild(1).transform.GetChild(val).gameObject;
    }
    private GameObject FindCanvasObject(int childIndex, GameObject canv, string obj)
    {
        int i, val = 0;
        for (i = 0; i < canv.transform.GetChild(childIndex).transform.childCount; ++i)
            if (canv.transform.GetChild(childIndex).transform.GetChild(i).name.Contains(obj))
            {
                val = i;
                i = canv.transform.GetChild(childIndex).transform.childCount;
            }
        return canv.transform.GetChild(childIndex).transform.GetChild(val).gameObject;
    }

    public void GameHasStarted()
    {
        for (int i = 0; i < gamecanvasInst.transform.GetChild(1).transform.childCount; ++i)
        {
            if (gamecanvasInst.transform.GetChild(1).transform.GetChild(i).gameObject.activeSelf)
                gamecanvasInst.transform.GetChild(1).transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public GameObject GetCountdownTimer() { return countdownTimer; }

    public void SetPlayerCharacterChoice(int choice) { playercharacterChoice = choice; }
    public int GetPlayerCharacterChoice() { return playercharacterChoice; }
    public void SetIsInstantiated(bool isinstantiated) { instantiated = isinstantiated; }
}
