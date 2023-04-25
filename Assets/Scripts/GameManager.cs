using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    TextMeshProUGUI successfulJumps, personalBest, gameOver;
    [SerializeField]
    Button playAgain, mainMenu, toggleAccolades;
    GameObject playerGO, playerGoInst;
    [SerializeField]
    Transform maxHeight, minHeight, playerPosition;


    // rope gameobject holder
    // and instantiated object holders
    GameObject ropeInst;
    GameObject rope;

    GameObject gbackGround;
    GameObject ropeSpeed;

    Rope ropeCS;

    bool checkforRope;

    bool switchedScenes;

    
    float countdownTimer = 3f;
    [SerializeField]
    GameObject countdowntimerDisplay;

    bool gamehasStarted = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            print("Trying to create multiple instances of GameManager");
        switchedScenes = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        //gbackGround = GameObject.Find("background");
        //ropeSpeed = UIManager.Instance.GetRopeSpeedSlider();
        //playAgain.gameObject.SetActive(false);
        //mainMenu.gameObject.SetActive(false);
        //checkforRope = false;
        //gameOver.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //personalBest.text = "Personal Best: " + SaveData.current.profile.numofJumps;

        //// initiate countdown timer for when the game will start
        //if (player.GetComponent<Player>().GetIsPlaying())
        //{
        //    countdowntimerDisplay.GetComponent<TextMeshProUGUI>().text = "Begin Jumping in: " + (int)countdownTimer;
        //    //toggleAccolades.gameObject.SetActive(false);
        //    checkforRope = true;
        //    if (countdownTimer > 0.0)
        //        countdownTimer -= Time.deltaTime;
        //}

        //// checking to see what ropes are available
        //if (checkforRope)
        //{
        //    rope = GameObject.FindGameObjectWithTag("rope");
        //    if (rope)
        //    {
        //        ropeCS = rope.GetComponent<Rope>();
        //        if (ropeCS)
        //            checkforRope = false;
        //    }
        //}

        //// displaying how many successful jumps the player has made
        //if (ropeCS != null)
        //{
        //    successfulJumps.text = "jumps: " + ropeCS.GetCurrJumps();
        //}

    }

    public TextMeshProUGUI GetGameOver() { return gameOver; }

    public GameObject GetPlayer() { return playerGO; }

    public void ResetGame()
    {
        rope = Resources.Load<GameObject>("rope");
        ropeInst = Instantiate(rope, maxHeight.position, Quaternion.identity);
        ropeInst.GetComponent<Rope>().SetSpeed(ropeSpeed.GetComponent<Slider>().value);
        

        SerializationManager.Save("Data", SaveData.current);
        gbackGround.GetComponent<GameBackground>().ResetBackground();
        playAgain.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        //toggleAccolades.gameObject.SetActive(false);
        ropeSpeed.gameObject.SetActive(false);
        playerGO.GetComponent<Player>().SetIsPlaying(true);
        gameOver.text = "";
    }

    public Button GetPlayAgain() { return playAgain;   }
    public Button GetMainMenu() { return mainMenu; }
    
    public Button GetToggleAccolades() { return toggleAccolades;  }
    public Slider GetRopeSpeedSlider() { return ropeSpeed.GetComponent<Slider>(); }

    public float GetCountDownTimer() { return countdownTimer; }

    public void SetCountDownTimer(int timer) { countdownTimer = timer; }

    public GameObject GetCountDownDisplay() { return countdowntimerDisplay; }

    public bool HasSwitchedScenes() { return switchedScenes; }
    public void SwitchScenes(bool switchedscenes) { switchedScenes = switchedscenes; }
    public bool GetGameHasStarted() { return gamehasStarted; }
    public void SetGameHasStarted(bool gameStarted) { gamehasStarted = gameStarted; }
}
