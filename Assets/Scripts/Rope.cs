using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rope : BaseRope
{
    [SerializeField]
    Transform highestPoint;
    [SerializeField]
    Transform lowestPoint;
    [SerializeField]
    Transform ddropestartPos;

    [SerializeField]
    GameObject rope2;
    GameObject playerGO;
    [HideInInspector]
    public Difficulties buttons;

    GameManager manager;
    
    public Button playAgain;
    public Button mainMenu;
    public Button toggleAccolades;

    Vector2 movement;

    float risingDist;
    float loweringDist;

    float speedX = 0.0f, speedY = 12.0f;

    bool gameover;
    // Start is called before the first frame update
    void Start()
    {
        // getting reference of gameobjects
        buttons = GameObject.Find("Buttons").GetComponent<Difficulties>();
        playerGO = GameObject.FindGameObjectWithTag("Player");
        risingDist = Vector2.Distance(transform.position, highestPoint.position);
        loweringDist = Vector2.Distance(transform.position, lowestPoint.position);
        manager = GameObject.Find("background").GetComponent<GameManager>();
        gameover = false;
        goDown = true;
        
        SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/Data.saves");
    }

    // Update is called once per frame
    void Update()
    {

        // updating this for OnTriggerStay2D
        loweringDist = Vector2.Distance(transform.position, lowestPoint.position);

        if (manager.GetCountDownTimer() <= 0)
        {
            manager.GetCountDownDisplay().GetComponent<TextMeshProUGUI>().text = "";
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
                    ++numOfJumps;
                    if (numOfJumps == 5)
                        ++SaveData.current.profile.numBronze;
                    if (numOfJumps == 15)
                        ++SaveData.current.profile.numSilver;
                    if (numOfJumps == 50)
                        ++SaveData.current.profile.numGold;
                    if (numOfJumps == 75)
                        ++SaveData.current.profile.numPlat;
                    if (numOfJumps == 1000)
                        ++SaveData.current.profile.numWhy;
                }
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Player") && loweringDist < .3f && collision.GetComponent<Player>().IsGrounded())
        {
            manager.getplayAgain().gameObject.SetActive(true);
            manager.getmainMenu().gameObject.SetActive(true);
            manager.gettoggleAccolades().gameObject.SetActive(true);
            manager.getropespeedSlider().gameObject.SetActive(true);
            collision.GetComponent<Player>().setisPlaying(false);
            manager.getgameOver().text = "Game Over!";
            manager.SetCountDownTimer(3);
            goUp = false;
            goDown = false;
            gameover = true;

            if (numOfJumps > SaveData.current.profile.numofJumps)
                SaveData.current.profile.numofJumps = numOfJumps;

            Destroy(this.gameObject);
        }
    }
    public void GoToMenu()
    {
        SerializationManager.Save("Data", SaveData.current);
        SceneManager.LoadScene("MainMenu");
    }


    public void GoingUp(bool isgoingUp)
    {
        goUp = isgoingUp;
        goDown = !goUp;
    }


    public void StopRope()
    {
        goUp = false;
        goDown = false;
    }

    public int GetJumps() => SaveData.current.profile.numofJumps;

    public int GetCurrJumps() => numOfJumps;

    public void Replay() { SerializationManager.Save("Data", SaveData.current); }
    public GameObject returnPlayer() => playerGO;

    private void OnApplicationQuit() => SerializationManager.Save("Data", SaveData.current);

    public void setSpeed(float speed) { speedY = speed; }
    public Button getaccoladesButton() { return toggleAccolades; }

    public Button getmenuButton() { return mainMenu; }

    public Button getplayagainButton() { return playAgain; }

    public bool IsGameOver() { return gameover; }

}
