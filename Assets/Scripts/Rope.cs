using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rope : MonoBehaviour
{
    [SerializeField]
    Transform highestPoint;
    [SerializeField]
    Transform lowestPoint;

    GameObject playerGO;

    [HideInInspector]
    public Difficulties buttons;


    public Button playAgain;
    public Button mainMenu;
    public Button toggleAccolades;

    float risingDist;
    float loweringDist;

    int numcurrJumps = 0;
    float ddmileStone = 0;
    float speedX = 0.0f, speedY = 12.0f;
    Vector2 movement;

    [SerializeField]
    GameObject rope2;
    GameObject tmpRope;

    GameManager manager;

    public bool goUp, goDown;
    bool isgameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        // getting reference of gameobjects
        buttons = GameObject.Find("Buttons").GetComponent<Difficulties>();
        playerGO = GameObject.FindGameObjectWithTag("Player");
        risingDist = Vector2.Distance(transform.position, highestPoint.position);
        loweringDist = Vector2.Distance(transform.position, lowestPoint.position);
        playAgain.onClick.AddListener(Replay);
        mainMenu.onClick.AddListener(gotoMenu);
        playAgain.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);

        manager = GameObject.Find("background").GetComponent<GameManager>();
        
        SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/Data.saves");
    }

    // Update is called once per frame
    void Update()
    {
        // updating this for OnTriggerStay2D
        loweringDist = Vector2.Distance(transform.position, lowestPoint.position);


        switch (buttons.getrequestedDifficulty())
        {
            // regular jump rope
            case "regular":
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
                    break;
                }
            // double dutch jump rope
            case "dd":
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
                                tmpRope = Instantiate<GameObject>(rope2, highestPoint.position, Quaternion.identity);
                                tmpRope.GetComponent<DoubleDutchRope>().goDown = true;
                                Debug.Log(buttons.getSlider().value);
                                tmpRope.GetComponent<DoubleDutchRope>().setSpeed(buttons.getSlider().value);
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
                    break;
                }
            // extreme double dutch jump rope
            case "edd":
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
                                tmpRope = Instantiate<GameObject>(rope2, highestPoint.position, Quaternion.identity);
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
                    break;
                }
            default:
                break;
        }

    }

    public void resetJumps() => numcurrJumps = 0;

    public int getJumps() => SaveData.current.profile.numofJumps;

    public int getcurrJumps() => numcurrJumps;

    public void setmileStone(float milestone)
    {
        ddmileStone = milestone;
        Debug.Log(ddmileStone);
    }

    public void Replay()
    {
        SerializationManager.Save("Data", SaveData.current);
        resetGame();
        if (buttons.getrequestedDifficulty().Equals("edd"))
            ddmileStone = Random.Range(1, 5);
        Debug.Log(ddmileStone);
        
    }

    public void gotoMenu()
    {
        SerializationManager.Save("Data", SaveData.current);
        SceneManager.LoadScene("MainMenu");
    }

    public void setJumps(int numjumps) => numcurrJumps = numjumps;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Player") && loweringDist < .3f && collision.GetComponent<Player>().isGrounded())
        {
            Debug.Log("regular rope caught you");
            isgameOver = true;
            goUp = false;
            goDown = false;
            playAgain.gameObject.SetActive(true);
            mainMenu.gameObject.SetActive(true);
            collision.GetComponent<Player>().setisPlaying(false);
            toggleAccolades.gameObject.SetActive(true);
            if (buttons.getrequestedDifficulty().Equals("dd") || buttons.getrequestedDifficulty().Equals("edd"))
                Destroy(tmpRope);

            if (numcurrJumps > SaveData.current.profile.numofJumps)
                SaveData.current.profile.numofJumps = numcurrJumps;

            buttons.getSlider().gameObject.SetActive(true);
        }
    }

    public GameObject returnPlayer() => playerGO;

    private void OnApplicationQuit() => SerializationManager.Save("Data", SaveData.current);

    void resetGame()
    {
        resetJumps();
        GameObject.Find("background").GetComponent<GameBackground>().resetBackground();
        transform.position = highestPoint.position;
        goDown = true;
        playAgain.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        manager.getgameOver().text = "";
        playerGO.GetComponent<Player>().setisPlaying(true);
        toggleAccolades.gameObject.SetActive(false);
        setSpeed(buttons.getSlider().value);
        buttons.getSlider().gameObject.SetActive(false);
    }

    public void setSpeed(float speed)
    {
        speedY = speed;
    }

    public void goingUp(bool isgoingUp)
    {
        goUp = isgoingUp;
        goDown = !goUp;
    }

    public Button getaccoladesButton()
    {
        return toggleAccolades;
    }

    public Button getmenuButton()
    {
        return mainMenu;
    }

    public Button getplayagainButton()
    {
        return playAgain;
    }

    public void stopRope()
    {
        goUp = false;
        goDown = false;
    }

    public bool getisGG()
    {
        return isgameOver;
    }
}
