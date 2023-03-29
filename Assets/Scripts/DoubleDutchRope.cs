using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoubleDutchRope : BaseRope
{
    [SerializeField]
    Transform highestPoint;
    [SerializeField]
    Transform lowestPoint;
    Difficulties difficulty;

    GameManager manager;
    Vector2 movement;

    float risingDist;
    float loweringDist;
    float speedX = 0.0f, speedY = 7.0f;
    // Start is called before the first frame update
    void Start()
    {
        risingDist = Vector2.Distance(transform.position, highestPoint.position);
        loweringDist = Vector2.Distance(transform.position, lowestPoint.position);
        manager = GameObject.Find("background").GetComponent<GameManager>();
        difficulty = GameObject.Find("Buttons").GetComponent<Difficulties>();
        speedY = manager.GetRopeSpeedSlider().value;
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



    public void GoToMenu()
    {
        SerializationManager.Save("Data", SaveData.current);
        SceneManager.LoadScene("MainMenu");
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Player") && loweringDist < .3f && collision.GetComponent<Player>().IsGrounded())
        {
            manager.GetGameOver().text = "Game Over!";
            manager.GetPlayAgain().gameObject.SetActive(true);
            manager.GetMainMenu().gameObject.SetActive(true);
            manager.GetToggleAccolades().gameObject.SetActive(true);
            collision.GetComponent<Player>().SetIsPlaying(false);
            Destroy(this.gameObject);
            goUp = false;
            goDown = false;

            if (numOfJumps > SaveData.current.profile.numofJumps)
                SaveData.current.profile.numofJumps = numOfJumps;

        }
    }

    public int GetCurrJumps() => numOfJumps;
    public void Replay() => SerializationManager.Save("Data", SaveData.current);
    private void OnApplicationQuit() => SerializationManager.Save("Data", SaveData.current);

    public void SetSpeed(float speed) { speedY = speed; }

}
