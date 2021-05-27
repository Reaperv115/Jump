using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI successfulJumps;
    [SerializeField]
    TextMeshProUGUI personalBest;
    [SerializeField]
    TextMeshProUGUI gameOver;

    GameObject rope;
    Rope ropeCS;
    // Start is called before the first frame update
    void Start()
    {
        rope = GameObject.FindGameObjectWithTag("rope");
        ropeCS = rope.GetComponent<Rope>();
        gameOver.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        successfulJumps.text = "jumps: " + rope.GetComponent<Rope>().getcurrJumps();
        personalBest.text = "Personal Best: " + SaveData.current.profile.numofJumps;

        if (ropeCS.getisGG())
            gameOver.text = "Game Over!";
        else
            gameOver.text = "";
    }

    public TextMeshProUGUI getgameOver()
    {
        return gameOver;
    }
}
