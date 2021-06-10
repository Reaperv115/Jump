using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoubleDutchRope : BaseRope
{
    [SerializeField]
    Transform highestPoint;
    [SerializeField]
    Transform lowestPoint;
    TextMeshProUGUI gameover;
    Rope initialRope;

    GameObject gbackGround;

    GameManager manager;
    int numcurrJumps = 0;

    Vector2 movement;

    float risingDist;
    float loweringDist;
    float speedX = 0.0f, speedY = 7.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameover = GameObject.Find("Game Over").GetComponent<TextMeshProUGUI>();
        risingDist = Vector2.Distance(transform.position, highestPoint.position);
        loweringDist = Vector2.Distance(transform.position, lowestPoint.position);
        manager = GameObject.Find("background").GetComponent<GameManager>();
        speedY = manager.getropespeedSlider().value;
        gbackGround = GameObject.Find("background");
        goUp = true;
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
                Debug.Log("Double dutch: " + numOfJumps);
                //int tmpJumps = initialRope.getcurrJumps();
                //tmpJumps++;
                //initialRope.setJumps(tmpJumps);

                //if (numcurrJumps == 5)
                //    ++SaveData.current.profile.numBronze;
                //if (numcurrJumps == 15)
                //    ++SaveData.current.profile.numSilver;
                //if (numcurrJumps == 50)
                //    ++SaveData.current.profile.numGold;
                //if (numcurrJumps == 75)
                //    ++SaveData.current.profile.numPlat;
                //if (numcurrJumps == 100)
                //    ++SaveData.current.profile.numWhy;
            }
        }

    }

    public void resetJumps() => numcurrJumps = 0;

    public int getJumps() => SaveData.current.profile.numofJumps;

    public int getcurrJumps() => numOfJumps;

    public void Replay()
    {
        SerializationManager.Save("Data", SaveData.current);
    }

    public void gotoMenu()
    {
        SerializationManager.Save("Data", SaveData.current);
        SceneManager.LoadScene("MainMenu");

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Player") && loweringDist < .3f && collision.GetComponent<Player>().isGrounded())
        {
            Debug.Log("double dutch caught you");
            resetJumps();
            manager.getgameOver().text = "Game Over!";
            goUp = false;
            goDown = false;
            manager.getplayAgain().gameObject.SetActive(true);
            manager.getmainMenu().gameObject.SetActive(true);
            manager.gettoggleAccolades().gameObject.SetActive(true);
            collision.GetComponent<Player>().setisPlaying(false);
            Destroy(this.gameObject);

            if (numOfJumps > SaveData.current.profile.numofJumps)
                SaveData.current.profile.numofJumps = numOfJumps;

        }
    }

    private void OnApplicationQuit() => SerializationManager.Save("Data", SaveData.current);

    public void setSpeed(float speed)
    {
        speedY = speed;
    }

    public void stopRope()
    {
        goUp = false;
        goDown = false;
    }
}
