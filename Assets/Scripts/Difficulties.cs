using UnityEngine;
using UnityEngine.UI;

public class Difficulties : MonoBehaviour
{
    // members you can change in the editor
    [SerializeField]
    Button[] difficultyButtons;
    [SerializeField]
    Slider ropeSpeed;

    // button to display accolades or not
    Button toggleAccolades;

    // starting positions for both regular
    // and double dutch rope
    Transform ropestartPos;
    Transform ddropestartPos;

    // rope gameobject
    GameObject rope;
    GameObject instantiatedRope;

    // double dutch rope game object
    GameObject ddRope;
    GameObject instantiatedddRope;

    GameObject player;

    string selectedDifficulty;

    private void Start()
    {
        toggleAccolades = GameObject.Find("Toggle Accolades").GetComponent<Button>();
        ropestartPos = GameObject.Find("rsp").GetComponent<Transform>();
        ddropestartPos = GameObject.Find("ddrsp").GetComponent<Transform>();
        rope = Resources.Load<GameObject>("rope");
        ddRope = Resources.Load<GameObject>("dd rope");
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void BeginRegular()
    {
        selectedDifficulty = "regular";
        instantiatedRope = Instantiate(rope, ropestartPos.position, Quaternion.identity);
        //player.GetComponent<Player>().SetIsPlaying(true);
        for (int i = 0; i < difficultyButtons.Length; ++i)
            difficultyButtons[i].gameObject.SetActive(false);
        //instantiatedRope.GetComponent<Rope>().SetSpeed(ropeSpeed.value);
        ropeSpeed.gameObject.SetActive(false);
    }

    public void BeginDD()
    {
        selectedDifficulty = "dd";
        instantiatedRope = Instantiate(rope, ropestartPos.position, Quaternion.identity);
        //instantiatedRope.GetComponent<Rope>().SetSpeed(ropeSpeed.value);
        instantiatedddRope = Instantiate(ddRope, ddropestartPos.position, Quaternion.identity);
        instantiatedddRope.GetComponent<DoubleDutchRope>().SetSpeed(ropeSpeed.value);
        //player.GetComponent<Player>().SetIsPlaying(true);
        for (int i = 0; i < difficultyButtons.Length; ++i)
            difficultyButtons[i].gameObject.SetActive(false);
        ropeSpeed.gameObject.SetActive(false);
    }

    public string GetRequestedDifficulty() { return selectedDifficulty; }
}
