using UnityEngine;
using UnityEngine.UI;

public class Difficulties : MonoBehaviour
{
    string selectedDifficulty;
    [SerializeField]
    protected Button[] difficultyButtons;
    Button toggleAccolades;


    Rope rope;


    GameObject player;

    private void Start()
    {
        difficultyButtons[0].GetComponent<Button>();
        difficultyButtons[0].onClick.AddListener(beginRegular);
        difficultyButtons[1].GetComponent<Button>();
        difficultyButtons[1].onClick.AddListener(beginDD);
        difficultyButtons[2].GetComponent<Button>();
        difficultyButtons[2].onClick.AddListener(beginEDD);
        toggleAccolades = GameObject.Find("Toggle Accolades").GetComponent<Button>();
        Debug.Log(toggleAccolades);
        rope = GameObject.FindGameObjectWithTag("rope").GetComponent<Rope>();
    }
    public void beginRegular()
    {
        selectedDifficulty = "regular";
        player = rope.returnPlayer();
        rope.goUp = true;
        player.GetComponent<Player>().setisPlaying(true);
        toggleAccolades.gameObject.SetActive(false);
        for (int i = 0; i < difficultyButtons.Length; ++i)
            difficultyButtons[i].gameObject.SetActive(false);
    }

    public void beginDD()
    {
        selectedDifficulty = "dd";
        rope.goUp = true;
        rope.setmileStone(Random.Range(1, 100));
        player = rope.returnPlayer();
        player.GetComponent<Player>().setisPlaying(true);
        for (int i = 0; i < difficultyButtons.Length; ++i)
            difficultyButtons[i].gameObject.SetActive(false);
    }

    public void beginEDD()
    {
        selectedDifficulty = "edd";
        player.GetComponent<Player>().setisPlaying(true);
        toggleAccolades.gameObject.SetActive(false);
        rope.goUp = true;
        rope.setmileStone(Random.Range(1, 100));
        player = rope.returnPlayer();
        for (int i = 0; i < difficultyButtons.Length; ++i)
            difficultyButtons[i].gameObject.SetActive(false);
    }

    public string getrequestedDifficulty()
    {
        return selectedDifficulty;
    }
}
