using UnityEngine;
using UnityEngine.UI;

public class Difficulties : MonoBehaviour
{
    string selectedDifficulty;
    [SerializeField]
    Button[] difficultyButtons;
    Button toggleAccolades;

    Transform ropestartPos;

    GameObject rope;
    [SerializeField]
    Slider ropeSpeed;

    GameObject player;

    [SerializeField]
    GameObject rope2;
    GameObject tmpRope;

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
        Debug.Log(ropestartPos);
        background = GameObject.Find("background");
        rope = Resources.Load<GameObject>("rope");
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
        selectedDifficulty = "regular";
        background.GetComponent<GameManager>().setisgameOver(false);
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
        selectedDifficulty = "dd";
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

    public void beginEDD()
    {
        selectedDifficulty = "edd";
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
