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
    Vector2 movement;



    public bool goUp, goDown = true;
    float speedX = 0.0f, speedY = 0.0f;
    float risingDist;
    float loweringDist;
    int numcurrJumps = 0;



    // Start is called before the first frame update
    void Start()
    {
        gameover = GameObject.Find("Game Over").GetComponent<TextMeshProUGUI>();
        initialRope = GameObject.Find("rope").GetComponent<Rope>();
        risingDist = Vector2.Distance(transform.position, highestPoint.position);
        loweringDist = Vector2.Distance(transform.position, lowestPoint.position);
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
            initialRope.goUp = false;
            initialRope.goDown = false;
            collision.GetComponent<Player>().setisPlaying(false);
            initialRope.toggleAccolades.gameObject.SetActive(true);
            initialRope.playAgain.gameObject.SetActive(true);
            initialRope.mainMenu.gameObject.SetActive(true);
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
        initialRope.playAgain.gameObject.SetActive(false);
        initialRope.mainMenu.gameObject.SetActive(false);
        initialRope.toggleAccolades.gameObject.SetActive(false);
        transform.position = highestPoint.position;
        goDown = true;
        gameover.text = "";
        initialRope.returnPlayer().GetComponent<Player>().setisPlaying(true);
    }
}
