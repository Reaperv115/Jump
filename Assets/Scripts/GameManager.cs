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

    RegularRope rope;

    [SerializeField]
    Button toggleAccolades;

    TextMeshProUGUI personalbestDisplay;
    TextMeshProUGUI succeessfulJumps;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playAgain = GameObject.Find("Play Again").GetComponent<Button>();
        mainMenu = GameObject.Find("MainMenu").GetComponent<Button>();
        buttons = GameObject.Find("Buttons").GetComponent<Difficulties>();
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
        if (GameObject.FindGameObjectWithTag("rope") && rope == null)
        {
            rope = GameObject.FindGameObjectWithTag("rope").GetComponent<RegularRope>();
        }
        if (rope)
        {
            //Debug.Log(rope);
            succeessfulJumps.text = "jumps: " + rope.getcurrJumps();
        }
        
    }

    public void Replay()
    {
        SerializationManager.Save("Data", SaveData.current);
        
        if (buttons.getrequestedDifficulty().Equals("edd"))
            rope.setmileStone(Random.Range(1, 5));
        rope.setSpeed(buttons.getSlider().value);
        buttons.getSlider().gameObject.SetActive(false);
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
}
