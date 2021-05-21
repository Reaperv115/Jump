using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoubleDutchRope : MonoBehaviour
{
    [SerializeField]
    Transform highestPoint;
    [SerializeField]
    Transform lowestPoint;
    TextMeshProUGUI gameover;
    Rope initialRope;

    //GameManager manager;
    int numcurrJumps = 0;

    Vector2 movement;

    float risingDist;
    float loweringDist;
    public bool goUp, goDown;
    float speedX = 0.0f, speedY = 12.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameover = GameObject.Find("Game Over").GetComponent<TextMeshProUGUI>();
        //initialRope = GameObject.Find("rope").GetComponent<RegularRope>();
        //risingDist = Vector2.Distance(transform.position, highestPoint.position);
        //loweringDist = Vector2.Distance(transform.position, lowestPoint.position);
        //manager = GameObject.Find("background").GetComponent<GameManager>();
        //speedY = initialRope.buttons.getSlider().value;
        goUp = true; 
        goDown = true;
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
                int tmpJumps = initialRope.getcurrJumps();
                tmpJumps++;
                initialRope.setJumps(tmpJumps);
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

    public void Replay()
    {
        SerializationManager.Save("Data", SaveData.current);
        resetGame();
    }

    public void gotoMenu()
    {
        SerializationManager.Save("Data", SaveData.current);
        SceneManager.LoadScene("MainMenu");

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.name.Equals("player") && loweringDist < .3f && collision.GetComponent<Player>().isGrounded())
        {
            gameover.text = "Game Over!";
            goUp = false;
            goDown = false;
            collision.GetComponent<Player>().setisPlaying(false);
            //manager.getplayagainButton().gameObject.SetActive(true);
            //manager.getmenuButton().gameObject.SetActive(true);
            //manager.getaccoladesButton().gameObject.SetActive(true);
            Destroy(this.gameObject);

            if (initialRope.getcurrJumps() > SaveData.current.profile.numofJumps)
                SaveData.current.profile.numofJumps = numcurrJumps;
            
        }
    }

    private void OnApplicationQuit() => SerializationManager.Save("Data", SaveData.current);

    void resetGame()
    {
        resetJumps();
        GameObject.Find("sky").GetComponent<GameBackground>().resetBackground();
        //manager.getplayagainButton().gameObject.SetActive(false);
        //manager.getmenuButton().gameObject.SetActive(false);
        //manager.getaccoladesButton().gameObject.SetActive(false);
        transform.position = highestPoint.position;
        goDown = true;
        gameover.text = "";
        //initialRope.returnPlayer().GetComponent<Player>().setisPlaying(true);
    }

    public void setSpeed(float speed)
    {
        speedY = speed;
    }
}
