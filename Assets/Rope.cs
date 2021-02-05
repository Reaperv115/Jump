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

    TextMeshProUGUI gameover;
    TextMeshPro succeessfulJumps;

    Button playAgain;
    Button mainMenu;

    float risingDist;
    float loweringDist;
    int jumps = 0;

    bool goUp = true, goDown;

    // Start is called before the first frame update
    void Start()
    {
        gameover = GameObject.Find("Game Over").GetComponent<TextMeshProUGUI>();
        succeessfulJumps = GameObject.Find("Jumps").GetComponent<TextMeshPro>();
        playAgain = GameObject.Find("Play Again").GetComponent<Button>();
        mainMenu = GameObject.Find("MainMenu").GetComponent<Button>();
        risingDist = Vector2.Distance(transform.position, highestPoint.position);
        loweringDist = Vector2.Distance(transform.position, lowestPoint.position);
        playAgain.onClick.AddListener(Replay);
        playAgain.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        gameover.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        // updating this for OnTriggerStay2D
        loweringDist = Vector2.Distance(transform.position, lowestPoint.position);

        succeessfulJumps.text = "jumps: " + jumps.ToString();

        if (goUp)
        {
            transform.Translate(new Vector2(0.0f, 0.10f), Space.World);
            risingDist = Vector2.Distance(transform.position, highestPoint.position);
            if (risingDist < 0.1f)
            {
                goDown = true;
                goUp = false;
            }
        }
        if (goDown)
        {
            transform.Translate(new Vector2(0.0f, -0.10f), Space.World);
            loweringDist = Vector2.Distance(transform.position, lowestPoint.position);
            if (loweringDist < 0.1f)
            {
                goDown = false;
                goUp = true;
                ++jumps;
            }
        }

    }

    public void setDirection(string direction)
    {
        if (direction.Equals("up"))
            goUp = true;
        else
            goDown = true;
    }

    public void resetJumps()
    {
        jumps = 0;
    }

    public void Replay()
    {
        Debug.Log("begin replay");
        SceneManager.LoadScene("Game");
    }

    public void gotoMenu()
    {
        SceneManager.LoadScene("MainMenu");
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
        }
    }
}
