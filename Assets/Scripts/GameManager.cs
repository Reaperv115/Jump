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
    Slider ropeSpeed;
    GameObject rope;
    GameObject instantiatedRope;
    RegularRope rr;

    [SerializeField]
    Button toggleAccolades;

    [SerializeField]
    Transform highestPoint;

    TextMeshProUGUI personalbestDisplay;
    TextMeshProUGUI succeessfulJumps;

    GameObject player;
    GameObject tmpRope;
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
        ropeSpeed = GameObject.FindGameObjectWithTag("options").GetComponent<Slider>();
        playAgain.onClick.AddListener(Replay);
        playAgain.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        player = getPlayer();
        SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/Data.saves");
    }

    // Update is called once per frame
    void Update()
    {
        personalbestDisplay.text = "Personal Best: " + SaveData.current.profile.numofJumps;
        if (GameObject.FindGameObjectWithTag("rope") && rope == null)
        {
            rope = GameObject.FindGameObjectWithTag("rope");
        }
        if (rope)
        {
            rr = rope.GetComponent<RegularRope>();
            succeessfulJumps.text = "jumps: " + rr.getcurrJumps();
            //if (rr.getisgameOver())
            //{
            //    Debug.Log("game is over");
            //    rr.setisgameOver(false);
            //    rope.gameObject.transform.position = highestPoint.position;
            //    //playAgain.gameObject.SetActive(true);
            //    //mainMenu.gameObject.SetActive(true);
            //    //toggleAccolades.gameObject.SetActive(true);
            //    //ropeSpeed.gameObject.SetActive(true);
            //    //gameover.text = "GAME OVER!";
            //}
        }
        
    }

    public void Replay()
    {
        SerializationManager.Save("Data", SaveData.current);
        gamebackGround.GetComponent<GameBackground>().resetBackground();
        playAgain.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        toggleAccolades.gameObject.SetActive(false);
        gameover.GetComponent<TextMeshProUGUI>().text = "";
        buttons.getRope().GetComponent<RegularRope>().GoDown(true);
        rope.GetComponent<RegularRope>().setSpeed(ropeSpeed.value);
        //if (buttons.getrequestedDifficulty().Equals("edd"))
        //    rope.GetComponent<RegularRope>().setmileStone(Random.Range(1, 5));
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

    public GameObject loadRope()
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

    public void setRope(GameObject nRope)
    {
        rope = nRope;
    }

    public Slider getropeSpeed()
    {
        return ropeSpeed;
    }
}
