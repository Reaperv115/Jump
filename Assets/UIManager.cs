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
    GameObject basicmodeBtn, basicmodeBtnInst, basicmodeOptions, basicmodeOptionsInst;
    GameObject yourchoicemodeBtn, yourchoicemodeBtnInst;
    GameObject replayGameBtn, replaygameBtnInst;
    GameObject ropespeedSlider, ropespeedSliderInst;
    GameObject toggleAccoladesBtn, toggleAccoladesBtnInst;
    GameObject characterselectionDrpDwn, characterselectionDrpDwnInst;

    [SerializeField]
    GameObject basicmodeBtnPosition, basicmodeoptionsBtnPosition, youchoicemodeBtnPosition, ropespeedSliderPosition;
    [SerializeField]
    GameObject backtomainmenuBtnPosition, replayBtnPosition, toggleaccoladesBtnPosition;


    GameObject canvas;



    int playercharacterChoice;


    private void Awake()
    {
        backtomainmenuBtn = Resources.Load<GameObject>("UI/Game UI/BackToMainMenuBtn");
        replayGameBtn = Resources.Load<GameObject>("UI/Game UI/ReplayGameBtn");
        ropespeedSlider = Resources.Load<GameObject>("UI/Game UI/RopeSpeedSlider");
        toggleAccoladesBtn = Resources.Load<GameObject>("UI/Game UI/ToggleAccoladesBtn");
        basicmodeBtn = Resources.Load<GameObject>("UI/Game UI/Basic ModeBtn");
        yourchoicemodeBtn = Resources.Load<GameObject>("UI/Game UI/Your Choice ModeBtn");
        basicmodeOptions = Resources.Load<GameObject>("UI/Game UI/Basic Mode Options");


        canvas = GameObject.Find("Canvas");
    }
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("trying to create multiple instances of Ui Manager");

        InstantiateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void InstantiateUI()
    {
        backtomainmenuBtnInst = Instantiate(backtomainmenuBtn, backtomainmenuBtnPosition.transform.position, backtomainmenuBtn.transform.rotation, canvas.transform);
        basicmodeOptionsInst = Instantiate(basicmodeOptions, basicmodeoptionsBtnPosition.transform.position, basicmodeOptions.transform.rotation, canvas.transform);
        basicmodeOptionsInst.SetActive(false);
        basicmodeBtnInst = Instantiate(basicmodeBtn, basicmodeBtnPosition.transform.position, basicmodeBtn.transform.rotation, canvas.transform);
        yourchoicemodeBtnInst = Instantiate(yourchoicemodeBtn, youchoicemodeBtnPosition.transform.position, yourchoicemodeBtn.transform.rotation, canvas.transform);
        replaygameBtnInst = Instantiate(replayGameBtn, replayBtnPosition.transform.position, replayGameBtn.transform.rotation, canvas.transform);
        replaygameBtnInst.SetActive(false);
        ropespeedSliderInst = Instantiate(ropespeedSlider, ropespeedSliderPosition.transform.position, ropespeedSlider.transform.rotation, canvas.transform);
        ropespeedSliderInst.SetActive(false);
        toggleAccoladesBtnInst = Instantiate(toggleAccoladesBtn, toggleaccoladesBtnPosition.transform.position, toggleAccoladesBtn.transform.rotation, canvas.transform);
    }


    public GameObject GetRopeSpeedSlider() { return ropespeedSliderInst; }
    public int GetPlayerCharacterChoice() { return playercharacterChoice; }
    public TMP_Dropdown GetCharacterSelectionDrpDwn() { return characterselectionDrpDwn.GetComponent<TMP_Dropdown>(); }
    public void SetPlayerCharacterChoice(int choice) { playercharacterChoice = choice;}

    public GameObject GetBackToMainMenuBtn() { return backtomainmenuBtn; }
    public GameObject GetBasicModeBtn() { return basicmodeBtn; }
    public GameObject GetBasicModeOptions() { return basicmodeOptionsInst; }
    public GameObject GetYourChoiceBtn() { return yourchoicemodeBtnInst; }
}
