using UnityEngine;
using UnityEngine.UI;

public class Difficulties : MonoBehaviour
{
    string selectedDifficulty;
    [SerializeField]
    Button[] difficultyButtons;
    [SerializeField]
    Button toggleAccolades;

    Transform ddstartPos;

    GameObject rope;
    Slider ropeSpeed;

    GameObject player;

    [SerializeField]
    GameObject rope2;
    GameObject tmpRope;

    GameObject background;
    GameManager manager;

    private void Start()
    {
        difficultyButtons[0].GetComponent<Button>();
        difficultyButtons[0].onClick.AddListener(beginRegular);
        difficultyButtons[1].GetComponent<Button>();
        difficultyButtons[1].onClick.AddListener(beginDD);
        difficultyButtons[2].GetComponent<Button>();
        difficultyButtons[2].onClick.AddListener(beginEDD);
        toggleAccolades = GameObject.Find("Toggle Accolades").GetComponent<Button>();
        ropeSpeed = GameObject.FindGameObjectWithTag("options").GetComponent<Slider>();
        background = GameObject.Find("game background");
        manager = background.GetComponent<GameManager>();
    }

    private void Update()
    {
        //Debug.Log(ropeSpeed);
    }
    public void beginRegular()
    {
        //selectedDifficulty = "regular";
        rope = manager.loadRope();
        tmpRope = Instantiate(rope, GameObject.Find("max height").transform.position, Quaternion.identity);
        player = manager.getPlayer();
        player.GetComponent<Player>().setisPlaying(true);
        manager.getaccoladesButton().gameObject.SetActive(false);
        for (int i = 0; i < difficultyButtons.Length; ++i)
        {
            difficultyButtons[i].gameObject.SetActive(false);
        }

        tmpRope.GetComponent<RegularRope>().setSpeed(ropeSpeed.value);
        manager.getropeSpeed().gameObject.SetActive(false);
    }

    public void beginDD()
    {
        selectedDifficulty = "dd";
        rope = Resources.Load<GameObject>("rope");
        Instantiate(rope, GameObject.Find("max height").GetComponent<Transform>().position, Quaternion.identity);
        tmpRope = Resources.Load<GameObject>("dd rope");
        Instantiate(tmpRope, ddstartPos.position, Quaternion.identity);
        player = manager.getPlayer();
        player.GetComponent<Player>().setisPlaying(true);
        for (int i = 0; i < difficultyButtons.Length; ++i)
            difficultyButtons[i].gameObject.SetActive(false);
        rope.GetComponent<RegularRope>().setSpeed(ropeSpeed.value);
        tmpRope.GetComponent<DoubleDutchRope>().setSpeed(ropeSpeed.value);
        ropeSpeed.gameObject.SetActive(false);
    }

    public void beginEDD()
    {
        //selectedDifficulty = "edd";
        //player.GetComponent<Player>().setisPlaying(true);
        //toggleAccolades.gameObject.SetActive(false);
        //rope.goUp = true;
        //rope.setmileStone(Random.Range(1, rope.getJumps()));
        //for (int i = 0; i < difficultyButtons.Length; ++i)
        //    difficultyButtons[i].gameObject.SetActive(false);
        //rope.setSpeed(ropeSpeed.value);
        //ropeSpeed.gameObject.SetActive(false);
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
