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



    //TextMeshProUGUI gameoverText;

    Difficulties buttons;

    GameManager manager;

    bool isgameOver;
    
    float ddmileStone = 0;
    GameObject backGround;
    GameObject playerGO;

    // Start is called before the first frame update
    void Start()
    {
        // getting reference of gameobjects

        buttons = GameObject.Find("Buttons").GetComponent<Difficulties>();
        isgameOver = false;
        risingDist = Vector2.Distance(transform.position, highestPoint.position);
        loweringDist = Vector2.Distance(transform.position, lowestPoint.position);
        backGround = GameObject.Find("game background");
        manager = backGround.GetComponent<GameManager>();
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

    public void resetJumps()
    {
        numcurrJumps = 0;
    }

    public int getJumps() => SaveData.current.profile.numofJumps;

    public int getcurrJumps()
    {
        return this.numcurrJumps;
    }

    public void setmileStone(float milestone)
    {
        ddmileStone = milestone;
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
            stopRope();
            resetJumps();
            collision.GetComponent<Player>().setisPlaying(false);
            manager.getplayagainButton().gameObject.SetActive(true);
            manager.getmenuButton().gameObject.SetActive(true);
            manager.getaccoladesButton().gameObject.SetActive(true);
            manager.getropeSpeed().gameObject.SetActive(true);
            manager.getGameOver().GetComponent<TextMeshProUGUI>().text = "GAME OVER!";
            transform.position = highestPoint.position;
            //isgameOver = true;
            if (numcurrJumps > SaveData.current.profile.numofJumps)
                SaveData.current.profile.numofJumps = numcurrJumps;
        }
    }

    private void OnApplicationQuit() => SerializationManager.Save("Data", SaveData.current);


    public void setSpeed(float speed)
    {
        speedY = speed;
    }

    public void GoDown(bool direction)
    {
        goDown = direction;
        goUp = !goDown;
        Debug.Log("go down: " + goDown);
        Debug.Log("go up: " + goUp);
    }
    

    public GameBackground getBackground()
    {
        return backGround.GetComponent<GameBackground>();
    }

    public bool getisgameOver()
    {
        return isgameOver;
    }

    public void setisgameOver(bool isgameover)
    {
        isgameOver = isgameover;
    }

    public void stopRope()
    {
        goUp = false;
        goDown = false;
    }
}
