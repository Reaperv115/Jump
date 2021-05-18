using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button playAgain;
    public Button mainMenu;

    Difficulties buttons;

    GameObject rope;

    [SerializeField]
    Button toggleAccolades;

    [SerializeField]
    Transform highestPoint;

    TextMeshProUGUI personalbestDisplay;
    TextMeshProUGUI succeessfulJumps;

    GameObject player;
    GameObject gamebackGround;
    TextMeshProUGUI gameover;

    // Start is called before the first frame update
    void Start()
    {
        gameover = GameObject.Find("Game Over").GetComponent<TextMeshProUGUI>();
        playAgain = GameObject.Find("Play Again").GetComponent<Button>();
        mainMenu = GameObject.Find("MainMenu").GetComponent<Button>();
        buttons = GameObject.Find("Buttons").GetComponent<Difficulties>();
        gamebackGround = GameObject.Find("game background");
        personalbestDisplay = GameObject.Find("Personal Best").GetComponent<TextMeshProUGUI>();
        succeessfulJumps = GameObject.Find("Jumps").GetComponent<TextMeshProUGUI>();
        playAgain.onClick.AddListener(Replay);
        playAgain.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/Data.saves");
    }

    // Update is called once per frame
    void Update()
    {
        personalbestDisplay.text = "Personal Best: " + SaveData.current.profile.numofJumps;
        Debug.Log(rope);
        if (GameObject.FindGameObjectWithTag("rope") && rope == null)
        {
            rope = GameObject.FindGameObjectWithTag("rope");
        }
        if (rope)
        {
            Debug.Log(succeessfulJumps.text);
            succeessfulJumps.text = "jumps: " + rope.GetComponent<RegularRope>().getcurrJumps();
        }
        
    }

    public void Replay()
    {
        SerializationManager.Save("Data", SaveData.current);
        gamebackGround.GetComponent<GameBackground>().resetBackground();
        playAgain.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        toggleAccolades.gameObject.SetActive(false);
        rope = getRope();
        Instantiate(rope, highestPoint.position, Quaternion.identity);
        gameover.GetComponent<TextMeshProUGUI>().text = "";
        if (buttons.getrequestedDifficulty().Equals("edd"))
            rope.GetComponent<RegularRope>().setmileStone(Random.Range(1, 5));
        rope.GetComponent<RegularRope>().setSpeed(buttons.getSlider().value);
        rope.GetComponent<RegularRope>().resetJumps();
        rope.GetComponent<Transform>().position = highestPoint.position;
        rope.GetComponent<RegularRope>().GoUp(true);
        buttons.getSlider().gameObject.SetActive(false);
        
        player.GetComponent<Player>().setisPlaying(true);
    }

    public Button getaccoladesButton()
    {
       return toggleAccolades;
    }

    public Button getmenuButton()
    {
        return mainMenu;
    }

    public Button getplayagainButton()
    {
        return playAgain;
    }

    public GameObject getPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        return player;
    }

    public GameObject getRope()
    {
        return Resources.Load<GameObject>("rope");
    }

    public Difficulties getdifficultyButtons()
    {
        return buttons;
    }

    public TextMeshProUGUI getGameOver()
    {
        return gameover;
    }
}
