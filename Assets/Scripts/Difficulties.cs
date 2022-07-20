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
    GameObject instantiatedRope;
    GameObject ddRope;
    GameObject instantiatedddRope;

    [SerializeField]
    Slider ropeSpeed;

    GameObject player;


    GameObject background;

    private void Start()
    {
        difficultyButtons[0].GetComponent<Button>();
        difficultyButtons[0].onClick.AddListener(beginRegular);
        difficultyButtons[1].GetComponent<Button>();
        difficultyButtons[1].onClick.AddListener(beginDD);
        toggleAccolades = GameObject.Find("Toggle Accolades").GetComponent<Button>();
        ropestartPos = GameObject.Find("rsp").GetComponent<Transform>();
        ddropestartPos = GameObject.Find("ddrsp").GetComponent<Transform>();
        background = GameObject.Find("background");
        rope = Resources.Load<GameObject>("rope");
        ddRope = Resources.Load<GameObject>("dd rope");
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void beginRegular()
    {
        selectedDifficulty = "regular";
        instantiatedRope = Instantiate(rope, ropestartPos.position, Quaternion.identity);
        player.GetComponent<Player>().setisPlaying(true);
        for (int i = 0; i < difficultyButtons.Length; ++i)
        {
            difficultyButtons[i].gameObject.SetActive(false);
        }

        instantiatedRope.GetComponent<Rope>().setSpeed(ropeSpeed.value);
        ropeSpeed.gameObject.SetActive(false);
    }

    public void beginDD()
    {
        selectedDifficulty = "dd";
        instantiatedRope = Instantiate(rope, ropestartPos.position, Quaternion.identity);
        instantiatedRope.GetComponent<Rope>().setSpeed(ropeSpeed.value);
        instantiatedddRope = Instantiate(ddRope, ddropestartPos.position, Quaternion.identity);
        instantiatedddRope.GetComponent<DoubleDutchRope>().setSpeed(ropeSpeed.value);
        player.GetComponent<Player>().setisPlaying(true);
        for (int i = 0; i < difficultyButtons.Length; ++i)
            difficultyButtons[i].gameObject.SetActive(false);
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
        return instantiatedRope;
    }

    public GameObject getddRope()
    {
        return ddRope;
    }

    public Button[] getdifficultyButtons()
    {
        return difficultyButtons;
    }
}
