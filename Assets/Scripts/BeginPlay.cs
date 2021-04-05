using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginPlay : MonoBehaviour
{
    Button play;
    Button toggleAccolades;
    Button ddButton;
    Button extremeddButton;

    Rope rope;

    Player player;

    bool regularMode;

    // Start is called before the first frame update
    void Start()
    {
        regularMode = false;
        play = GetComponent<Button>();
        play.onClick.AddListener(Play);
        player = GameObject.Find("player").GetComponent<Player>();
        toggleAccolades = GameObject.Find("Toggle Accolades").GetComponent<Button>();
        ddButton = GameObject.Find("Double Dutch").GetComponent<Button>();
        extremeddButton = GameObject.Find("Extreme Double Dutch").GetComponent<Button>();
        rope = GameObject.Find("rope").GetComponent<Rope>();
    }

    public bool getMode()
    {
        return regularMode;
    }

    public void setMode(bool mode)
    {
        regularMode = mode;
    }

    public void Play()
    {
        rope.setregularMode(true);

        rope.goUp = true;
        player.setisPlaying(true);
        toggleAccolades.gameObject.SetActive(false);
        gameObject.SetActive(false);
        ddButton.gameObject.SetActive(false);
        extremeddButton.gameObject.SetActive(false);
    }
}
