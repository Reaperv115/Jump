using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI successfulJumps;
    [SerializeField]
    TextMeshProUGUI personalBest;
    [SerializeField]
    TextMeshProUGUI gameOver;
    [SerializeField]
    Button playAgain;
    [SerializeField]
    Button mainMenu;
    [SerializeField]
    Button toggleAccolades;
    [SerializeField]
    GameObject player;
    [SerializeField]
    Transform maxHeight;
    [SerializeField]
    Transform minHeight;

    Transform ddropestartPos;

    // rope and double dutch gameobject holders
    // and instantiated object holders
    GameObject ropeInst;
    GameObject rope;
    GameObject ddropeInst;
    GameObject ddrope;

    GameObject gbackGround;
    GameObject ropeSpeed;

    Rope ropeCS;
    DoubleDutchRope ddropeCS;

    bool checkforRope;

    

    
    float countdownTimer = 3f;
    [SerializeField]
    GameObject countdowntimerDisplay;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        gbackGround = GameObject.Find("background");
        ropeSpeed = GameObject.FindGameObjectWithTag("options");
        ddropestartPos = GameObject.Find("ddrsp").GetComponent<Transform>();
        playAgain.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        checkforRope = false;
        gameOver.text = "";
    }

    // Update is called once per frame
    void Update()
    {

        personalBest.text = "Personal Best: " + SaveData.current.profile.numofJumps;

        // initiate countdown timer for when the game will start
        if (player.GetComponent<Player>().GetIsPlaying())
        {
            countdowntimerDisplay.GetComponent<TextMeshProUGUI>().text = "Begin Jumping in: " + (int)countdownTimer;
            toggleAccolades.gameObject.SetActive(false);
            checkforRope = true;
            if (countdownTimer > 0.0)
                countdownTimer -= Time.deltaTime;
        }

        // checking to see what ropes are available
        if (checkforRope)
        {
            rope = GameObject.FindGameObjectWithTag("rope");
            ddrope = GameObject.FindGameObjectWithTag("ddrope");
            if (rope)
            {
                ropeCS = rope.GetComponent<Rope>();
                if (ddrope)
                    ddropeCS = ddrope.GetComponent<DoubleDutchRope>();
                if (ropeCS)
                    checkforRope = false;
            }
        }

        // displaying how many successful jumps the player has made
        if (ropeCS != null)
        {
            if (ddropeCS != null)
                successfulJumps.text = "jumps: " + (ropeCS.GetCurrJumps() + ddropeCS.GetCurrJumps());
            else
                successfulJumps.text = "jumps: " + ropeCS.GetCurrJumps();
        }

    }

    public TextMeshProUGUI GetGameOver() { return gameOver; }

    public GameObject GetPlayer() { return player; }

    public void ResetGame()
    {
        if (GameObject.Find("Buttons").GetComponent<Difficulties>().GetRequestedDifficulty().Equals("dd"))
        {
            rope = Resources.Load<GameObject>("rope");
            ropeInst = Instantiate(rope, maxHeight.position, Quaternion.identity);
            ropeInst.GetComponent<Rope>().SetSpeed(ropeSpeed.GetComponent<Slider>().value);
            ddrope = Resources.Load<GameObject>("dd rope");
            ddropeInst = Instantiate(ddrope, ddropestartPos.position, Quaternion.identity);
            ddropeInst.GetComponent<DoubleDutchRope>().SetSpeed(ropeSpeed.GetComponent<Slider>().value);
        }
        else
        {
            rope = Resources.Load<GameObject>("rope");
            ropeInst = Instantiate(rope, maxHeight.position, Quaternion.identity);
            ropeInst.GetComponent<Rope>().SetSpeed(ropeSpeed.GetComponent<Slider>().value);
        }

        SerializationManager.Save("Data", SaveData.current);
        gbackGround.GetComponent<GameBackground>().ResetBackground();
        playAgain.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        toggleAccolades.gameObject.SetActive(false);
        ropeSpeed.gameObject.SetActive(false);
        player.GetComponent<Player>().SetIsPlaying(true);
        gameOver.text = "";
    }

    public Button GetPlayAgain() { return playAgain;   }
    public Button GetMainMenu() { return mainMenu; }
    
    public Button GetToggleAccolades() { return toggleAccolades;  }
    public Slider GetRopeSpeedSlider() { return ropeSpeed.GetComponent<Slider>(); }

    public float GetCountDownTimer() { return countdownTimer; }

    public void SetCountDownTimer(int timer) { countdownTimer = timer; }

    public GameObject GetCountDownDisplay() { return countdowntimerDisplay; }

    public GameObject GetRope()
    {
        return rope;
    }
}
