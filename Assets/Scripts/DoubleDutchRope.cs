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

    GameManager manager;
    int numcurrJumps = 0;

    Vector2 movement;

    float risingDist;
    float loweringDist;
    public bool goUp, goDown;
    float speedX = 0.0f, speedY = 7.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameover = GameObject.Find("Game Over").GetComponent<TextMeshProUGUI>();
        initialRope = GameObject.Find("rope").GetComponent<Rope>();
        risingDist = Vector2.Distance(transform.position, highestPoint.position);
        loweringDist = Vector2.Distance(transform.position, lowestPoint.position);
        manager = GameObject.Find("background").GetComponent<GameManager>();
        speedY = initialRope.buttons.getSlider().value;
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
        if (collision.transform.tag.Equals("Player") && loweringDist < .3f && collision.GetComponent<Player>().isGrounded())
        {
            Debug.Log("double dutch caught you");
            manager.getgameOver().text = "Game Over!";
            goUp = false;
            goDown = false;
            initialRope.stopRope();
            initialRope.getplayagainButton().gameObject.SetActive(true);
            initialRope.getmenuButton().gameObject.SetActive(true);
            initialRope.getaccoladesButton().gameObject.SetActive(true);
            collision.GetComponent<Player>().setisPlaying(false);
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
        initialRope.getplayagainButton().gameObject.SetActive(false);
        initialRope.getmenuButton().gameObject.SetActive(false);
        initialRope.getaccoladesButton().gameObject.SetActive(false);
        transform.position = highestPoint.position;
        goDown = true;
        gameover.text = "";
        initialRope.returnPlayer().GetComponent<Player>().setisPlaying(true);
    }

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
