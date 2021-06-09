using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI successfulJumps;
    [SerializeField]
    TextMeshProUGUI personalBest;
    [SerializeField]
    TextMeshProUGUI gameOver;
    [SerializeField]
    Button playAgain;
    [SerializeField]
    Button mainMenu;
    [SerializeField]
    Button toggleAccolades;
    [SerializeField]
    GameObject player;
    [SerializeField]
    Transform maxHeight;
    [SerializeField]
    Transform minHeight;

    bool isgameOver;
    bool deleteRope;

    GameObject ropeInst;
    GameObject rope;
    GameObject gbackGround;
    GameObject ropeSpeed;

    Rope ropeCS;

    bool checkforRope;
    // Start is called before the first frame update
    void Start()
    {
        //rope = GameObject.FindGameObjectWithTag("rope");
        //ropeCS = rope.GetComponent<Rope>();
        player = GameObject.FindGameObjectWithTag("Player");
        gbackGround = GameObject.Find("background");
        ropeSpeed = GameObject.FindGameObjectWithTag("options");
        Debug.Log(player);
        playAgain.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        checkforRope = false;
        gameOver.text = "";
        isgameOver = false;
        deleteRope = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        personalBest.text = "Personal Best: " + SaveData.current.profile.numofJumps;

        Debug.Log(rope);
        
        if (player.GetComponent<Player>().getisPlaying())
        {
            //Debug.Log("player is playing");
            toggleAccolades.gameObject.SetActive(false);
            checkforRope = true;
        }

        if (checkforRope)
        {
            //Debug.Log("checking for rope");
            rope = GameObject.FindGameObjectWithTag("rope");
            if (rope)
            {
                //Debug.Log("found rope and checking for the script");
                ropeCS = rope.GetComponent<Rope>();
                if (ropeCS)
                {
                    
                    //Debug.Log("got the rope component");
                    checkforRope = false;
                }
            }
        }

        if (ropeCS != null)
        {
            successfulJumps.text = "jumps: " + rope.GetComponent<Rope>().getcurrJumps();
        }

    }

    public TextMeshProUGUI getgameOver()
    {
        return gameOver;
    }

    public GameObject getPlayer()
    {
        return player;
    }

    public void resetRope()
    {
        SerializationManager.Save("Data", SaveData.current);
        rope = Resources.Load<GameObject>("rope");
        ropeInst = Instantiate(rope, maxHeight.position, Quaternion.identity);
        gbackGround.GetComponent<GameBackground>().resetBackground();
        playAgain.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
        toggleAccolades.gameObject.SetActive(false);
        ropeSpeed.gameObject.SetActive(false);
        player.GetComponent<Player>().setisPlaying(true);
        gameOver.text = "";
        //rope.transform.position = maxHeight.position;
    }

    public void setisgameOver(bool gameOver)
    {
        isgameOver = gameOver;
    }

    public Button getplayAgain()
    {
        return playAgain;
    }
    public Button getmainMenu()
    {
        return mainMenu;
    }
    public Button gettoggleAccolades()
    {
        return toggleAccolades;
    }
    public Slider getropespeedSlider()
    {
        return ropeSpeed.GetComponent<Slider>();
    }
}
