using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegularRope : Rope
{
    [SerializeField]
    Transform highestPoint;
    [SerializeField]
    Transform lowestPoint;


    TextMeshProUGUI gameover;
    

    

    GameManager manager;

    
    
    float ddmileStone = 0;
    GameObject backGround;
    GameObject playerGO;

    // Start is called before the first frame update
    void Start()
    {
        // getting reference of gameobjects
        gameover = GameObject.Find("Game Over").GetComponent<TextMeshProUGUI>();
        
        
        risingDist = Vector2.Distance(transform.position, highestPoint.position);
        loweringDist = Vector2.Distance(transform.position, lowestPoint.position);
        backGround = GameObject.Find("game background");
        Debug.Log("Rope" + backGround);
        manager = backGround.GetComponent<GameManager>();
        
        gameover.text = "";
        goDown = true;
        goUp = false;
        speedX = 0.0f;
        speedY = 12.0f;
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

    public void resetJumps() => numcurrJumps = 0;

    public int getJumps() => SaveData.current.profile.numofJumps;

    public int getcurrJumps() => numcurrJumps;

    public void setmileStone(float milestone)
    {
        ddmileStone = milestone;
    }

    public void Replay()
    {
        SerializationManager.Save("Data", SaveData.current);
        backGround = GameObject.Find("game background");
        manager = backGround.GetComponent<GameManager>();
        Debug.Log(manager);
        manager.Replay();
        resetGame();
        
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
            gameover.text = "Game Over!";
            goUp = false;
            goDown = false;
            manager.playAgain.gameObject.SetActive(true);
            manager.mainMenu.gameObject.SetActive(true);
            collision.GetComponent<Player>().setisPlaying(false);
            manager.getaccoladesButton().gameObject.SetActive(true);
            manager.getdifficultyButtons().getSlider().gameObject.SetActive(true);

            if (numcurrJumps > SaveData.current.profile.numofJumps)
                SaveData.current.profile.numofJumps = numcurrJumps;
        }
    }

    private void OnApplicationQuit() => SerializationManager.Save("Data", SaveData.current);

    void resetGame()
    {
        //resetJumps();
        //backGround.GetComponent<GameBackground>().resetBackground();
        transform.position = highestPoint.position;
        //goDown = true;
        //playerGO = manager.getPlayer();
        //manager.playAgain.gameObject.SetActive(false);
        //manager.mainMenu.gameObject.SetActive(false);
        gameover.text = "";
        //playerGO.GetComponent<Player>().setisPlaying(true);
        //manager.getaccoladesButton().gameObject.SetActive(false);
    }

    public void setSpeed(float speed)
    {
        speedY = speed;
    }

    public GameBackground getBackground()
    {
        return backGround.GetComponent<GameBackground>();
    }
}
