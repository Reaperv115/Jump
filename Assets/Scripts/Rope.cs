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
    GameObject ddRope;

    GameManager manager;
    GameBackground background;

    // Start is called before the first frame update
    void Start()
    {
        // getting reference of gameobjects
        buttons = GameObject.Find("Buttons").GetComponent<Difficulties>();
        playerGO = GameObject.FindGameObjectWithTag("Player");
        risingDist = Vector2.Distance(transform.position, highestPoint.position);
        loweringDist = Vector2.Distance(transform.position, lowestPoint.position);
        goDown = true;
        manager = GameObject.Find("background").GetComponent<GameManager>();
        
        SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/Data.saves");
    }

    // Update is called once per frame
    void Update()
    {

        // updating this for OnTriggerStay2D
        loweringDist = Vector2.Distance(transform.position, lowestPoint.position);

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
                Debug.Log("Rope: " + numOfJumps);
                if (numOfJumps == 5)
                    ++SaveData.current.profile.numBronze;
                if (numOfJumps == 15)
                    ++SaveData.current.profile.numSilver;
                if (numOfJumps == 50)
                    ++SaveData.current.profile.numGold;
                if (numOfJumps == 75)
                    ++SaveData.current.profile.numPlat;
                if (numOfJumps == 100)
                    ++SaveData.current.profile.numWhy;
            }
        }

    }

    public void resetJumps() => numcurrJumps = 0;

    public int getJumps() => SaveData.current.profile.numofJumps;

    public int getcurrJumps() => numOfJumps;

    public void setmileStone(float milestone)
    {
        ddmileStone = milestone;
        Debug.Log(ddmileStone);
    }

    public void Replay()
    {
        SerializationManager.Save("Data", SaveData.current);
        
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
            resetJumps();
            manager.getplayAgain().gameObject.SetActive(true);
            manager.getmainMenu().gameObject.SetActive(true);
            manager.gettoggleAccolades().gameObject.SetActive(true);
            manager.getgameOver().text = "Game Over!";
            manager.getropespeedSlider().gameObject.SetActive(true);
            goUp = false;
            goDown = false;
            collision.GetComponent<Player>().setisPlaying(false);

            if (numOfJumps > SaveData.current.profile.numofJumps)
                SaveData.current.profile.numofJumps = numOfJumps;

            Destroy(this.gameObject);
        }
    }

    public GameObject returnPlayer() => playerGO;

    private void OnApplicationQuit() => SerializationManager.Save("Data", SaveData.current);

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

}
