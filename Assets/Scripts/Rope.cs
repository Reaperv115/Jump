using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rope : MonoBehaviour
{
    [SerializeField]
    Transform highestPoint;
    [SerializeField]
    Transform lowestPoint;

    Player player;

    TextMeshProUGUI gameover;
    TextMeshProUGUI personalbestDisplay;

    TextMeshPro succeessfulJumps;

    public Button playAgain;
    public Button mainMenu;
    public Button toggleAccolades;
    BeginPlay regularButton;
    DoubleDutchMode ddButton;
    ExtremeDoubleDutch extremeddButton;

    float risingDist;
    float loweringDist;

    int numcurrJumps = 0;
    float ddmileStone = 0;
    float speedX = 0.0f, speedY = 12.0f;
    Vector2 movement;

    [SerializeField]
    GameObject rope2;
    GameObject tmpRope;

    public bool goUp, goDown;
    bool regularMode = false, ddMode = false, extremeddMode = false;

    // Start is called before the first frame update
    void Start()
    {
        // getting reference of gameobjects
        gameover = GameObject.Find("Game Over").GetComponent<TextMeshProUGUI>();
        succeessfulJumps = GameObject.Find("Jumps").GetComponent<TextMeshPro>();
        playAgain = GameObject.Find("Play Again").GetComponent<Button>();
        mainMenu = GameObject.Find("MainMenu").GetComponent<Button>();
        player = GameObject.Find("player").GetComponent<Player>();
        toggleAccolades = GameObject.Find("Toggle Accolades").GetComponent<Button>();
        personalbestDisplay = GameObject.Find("Personal Best").GetComponent<TextMeshProUGUI>();
        regularButton = GameObject.Find("Regular").GetComponent<BeginPlay>();
        ddButton = GameObject.Find("Double Dutch").GetComponent<DoubleDutchMode>();
        extremeddButton = GameObject.Find("Extreme Double Dutch").GetComponent<ExtremeDoubleDutch>();

        risingDist = Vector2.Distance(transform.position, highestPoint.position);
        loweringDist = Vector2.Distance(transform.position, lowestPoint.position);
        playAgain.onClick.AddListener(Replay);
        playAgain.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        gameover.text = "";
        
        
        transform.position = highestPoint.position;
        SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/Data.saves");
    }

    // Update is called once per frame
    void Update()
    {
        // updating this for OnTriggerStay2D
        loweringDist = Vector2.Distance(transform.position, lowestPoint.position);

        personalbestDisplay.text = "Personal Best: " + SaveData.current.profile.numofJumps;

        succeessfulJumps.text = "jumps: " + numcurrJumps;

        if (regularMode)
        {
            if (goUp)
            {
                movement = new Vector2(speedX, speedY);
                transform.Translate(movement * Time.deltaTime);
                risingDist = Vector2.Distance(transform.position, highestPoint.position);
                if (risingDist < 0.3f)
                {
                    goDown = true;
                    goUp = false;
                }
            }
            if (goDown)
            {
                movement = new Vector2(speedX, -speedY);
                transform.Translate(movement * Time.deltaTime);
                loweringDist = Vector2.Distance(transform.position, lowestPoint.position);
                if (loweringDist < 0.3f)
                {
                    goDown = false;
                    goUp = true;
                    ++numcurrJumps;

                    if (numcurrJumps == 5)
                        ++SaveData.current.profile.numBronze;
                    if (numcurrJumps == 15)
                        ++SaveData.current.profile.numSilver;
                    if (numcurrJumps == 50)
                        ++SaveData.current.profile.numGold;
                    if (numcurrJumps == 75)
                        ++SaveData.current.profile.numPlat;
                    if (numcurrJumps == 100)
                        ++SaveData.current.profile.numWhy;
                }
            }
        }

        if (ddMode)
        {
            if (goUp)
            {
                movement = new Vector2(speedX, speedY);
                transform.Translate(movement * Time.deltaTime);
                risingDist = Vector2.Distance(transform.position, highestPoint.position);
                if (risingDist < 0.3f)
                {
                    goDown = true;
                    goUp = false;
                }
            }
            if (goDown)
            {
                movement = new Vector2(speedX, -speedY);
                transform.Translate(movement * Time.deltaTime);
                loweringDist = Vector2.Distance(transform.position, lowestPoint.position);
                if (loweringDist < 0.3f)
                {
                    goDown = false;
                    goUp = true;
                    ++numcurrJumps;

                    if (numcurrJumps == 5)
                        ++SaveData.current.profile.numBronze;
                    if (numcurrJumps == 15)
                        ++SaveData.current.profile.numSilver;
                    if (numcurrJumps == ddmileStone)
                    {
                        tmpRope = Instantiate<GameObject>(rope2, highestPoint);
                        tmpRope.GetComponent<DoubleDutchRope>().goDown = true;
                        speedY = 7.0f;
                    }
                    if (numcurrJumps == 50)
                        ++SaveData.current.profile.numGold;
                    if (numcurrJumps == 75)
                        ++SaveData.current.profile.numPlat;
                    if (numcurrJumps == 100)
                        ++SaveData.current.profile.numWhy;
                }
            }
        }

        if (extremeddMode)
        {
            if (goUp)
            {
                movement = new Vector2(speedX, speedY);
                transform.Translate(movement * Time.deltaTime);
                risingDist = Vector2.Distance(transform.position, highestPoint.position);
                if (risingDist < 0.3f)
                {
                    goDown = true;
                    goUp = false;
                }
            }
            if (goDown)
            {
                movement = new Vector2(speedX, -speedY);
                transform.Translate(movement * Time.deltaTime);
                loweringDist = Vector2.Distance(transform.position, lowestPoint.position);
                if (loweringDist < 0.3f)
                {
                    goDown = false;
                    goUp = true;
                    ++numcurrJumps;

                    if (numcurrJumps == 5)
                        ++SaveData.current.profile.numBronze;
                    if (numcurrJumps == 15)
                        ++SaveData.current.profile.numSilver;
                    if (numcurrJumps == ddmileStone)
                    {
                        tmpRope = Instantiate<GameObject>(rope2, highestPoint);
                        tmpRope.GetComponent<DoubleDutchRope>().goDown = true;
                        speedY = 7.5f;
                    }
                    if (numcurrJumps == 50)
                        ++SaveData.current.profile.numGold;
                    if (numcurrJumps == 75)
                        ++SaveData.current.profile.numPlat;
                    if (numcurrJumps == 100)
                        ++SaveData.current.profile.numWhy;
                }
            }
        }

    }

    public void resetJumps()
    {
        numcurrJumps = 0;
    }

    public int getJumps()
    {
        return SaveData.current.profile.numofJumps;
    }

    public void setregularMode(bool regularmode)
    {
        regularMode = regularmode;
    }

    public void setddMode(bool ddmode)
    {
        ddMode = ddmode;
    }

    public void setextremeddMode(bool extremeddmode)
    {
        extremeddMode = extremeddmode;
    }

    public int getcurrJumps()
    {
        return numcurrJumps;
    }

    public void setmileStone(float milestone)
    {
        ddmileStone = milestone;
    }

    public void Replay()
    {
        SerializationManager.Save("Data", SaveData.current);
        resetGame();
        if (extremeddMode)
        {
            ddmileStone = Random.Range(1, 100);
        }
    }

    public void gotoMenu()
    {
        SerializationManager.Save("Data", SaveData.current);
        SceneManager.LoadScene("MainMenu");
        
    }

    public void setJumps(int numjumps)
    {
        numcurrJumps = numjumps;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.name.Equals("player") && loweringDist < .3f && collision.GetComponent<Player>().isGrounded())
        {
            gameover.text = "Game Over!";
            goUp = false;
            goDown = false;
            playAgain.gameObject.SetActive(true);
            mainMenu.gameObject.SetActive(true);
            collision.GetComponent<Player>().setisPlaying(false);
            toggleAccolades.gameObject.SetActive(true);
            Destroy(tmpRope);

            if (numcurrJumps > SaveData.current.profile.numofJumps)
            {
                SaveData.current.profile.numofJumps = numcurrJumps;
            }
        }
    }

    private void OnApplicationQuit()
    {
        SerializationManager.Save("Data", SaveData.current);
    }

    void resetGame()
    {
        resetJumps();
        speedY = 12.0f;
        GameObject.Find("sky").GetComponent<GameBackground>().resetBackground();
        transform.position = highestPoint.position;
        goDown = true;
        playAgain.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        gameover.text = "";
        player.setisPlaying(true);
        toggleAccolades.gameObject.SetActive(false);
    }
}
