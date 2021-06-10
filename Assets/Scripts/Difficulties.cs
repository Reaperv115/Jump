using UnityEngine;
using UnityEngine.UI;

public class Difficulties : MonoBehaviour
{
    string selectedDifficulty;
    [SerializeField]
    Button[] difficultyButtons;
    Button toggleAccolades;

    Transform ropestartPos;
    Transform ddropestartPos;

    GameObject rope;
    GameObject tmpRope;
    GameObject ddRope;
    GameObject tmpddRope;

    [SerializeField]
    Slider ropeSpeed;

    GameObject player;


    GameObject background;
    //GameManager manager;

    private void Start()
    {
        difficultyButtons[0].GetComponent<Button>();
        difficultyButtons[0].onClick.AddListener(beginRegular);
        difficultyButtons[1].GetComponent<Button>();
        difficultyButtons[1].onClick.AddListener(beginDD);
        difficultyButtons[2].GetComponent<Button>();
        difficultyButtons[2].onClick.AddListener(beginEDD);
        toggleAccolades = GameObject.Find("Toggle Accolades").GetComponent<Button>();
        ropestartPos = GameObject.Find("rsp").GetComponent<Transform>();
        ddropestartPos = GameObject.Find("ddrsp").GetComponent<Transform>();
        Debug.Log(ropestartPos);
        background = GameObject.Find("background");
        rope = Resources.Load<GameObject>("rope");
        ddRope = Resources.Load<GameObject>("dd rope");
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player);
    }

    private void Update()
    {
        //Debug.Log(ropeSpeed);
    }
    public void beginRegular()
    {
        tmpRope = Instantiate(rope, ropestartPos.position, Quaternion.identity);
        player.GetComponent<Player>().setisPlaying(true);
        for (int i = 0; i < difficultyButtons.Length; ++i)
        {
            difficultyButtons[i].gameObject.SetActive(false);
        }

        tmpRope.GetComponent<Rope>().setSpeed(ropeSpeed.value);
        ropeSpeed.gameObject.SetActive(false);
    }

    public void beginDD()
    {
        tmpRope = Instantiate(rope, ropestartPos.position, Quaternion.identity);
        tmpRope.GetComponent<Rope>().setSpeed(ropeSpeed.value);
        tmpddRope = Instantiate(ddRope, ddropestartPos.position, Quaternion.identity);
        tmpddRope.GetComponent<DoubleDutchRope>().setSpeed(ropeSpeed.value);
        player.GetComponent<Player>().setisPlaying(true);
        for (int i = 0; i < difficultyButtons.Length; ++i)
            difficultyButtons[i].gameObject.SetActive(false);
        ropeSpeed.gameObject.SetActive(false);
    }

    public void beginEDD()
    {
        rope.GetComponent<Rope>().goingUp(true);
        rope.GetComponent<Rope>().setmileStone(Random.Range(1, 5));
        player = rope.GetComponent<Rope>().returnPlayer();
        player.GetComponent<Player>().setisPlaying(true);
        toggleAccolades.gameObject.SetActive(false);
        for (int i = 0; i < difficultyButtons.Length; ++i)
            difficultyButtons[i].gameObject.SetActive(false);
        rope.GetComponent<Rope>().setSpeed(ropeSpeed.value);
        ropeSpeed.gameObject.SetActive(false);
    }

    public string getrequestedDifficulty()
    {
        return selectedDifficulty;
    }

    public Slider getSlider()
    {
        return ropeSpeed;
    }

    public GameObject getRope()
    {
        return tmpRope;
    }

    public Button[] getdifficultyButtons()
    {
        return difficultyButtons;
    }
}
