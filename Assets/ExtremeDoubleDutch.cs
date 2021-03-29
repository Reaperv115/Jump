using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtremeDoubleDutch : MonoBehaviour
{
    Button extremeddButton;
    Button regularButton;
    Button ddButton;
    Button toggleAccolades;

    bool extremeddMode;

    Rope rope;

    Player player;
    // Start is called before the first frame update
    void Start()
    {
        rope = GameObject.Find("rope").GetComponent<Rope>();
        extremeddButton = GetComponent<Button>();
        extremeddButton.onClick.AddListener(beginextremeddMode);
        regularButton = GameObject.Find("Regular").GetComponent<Button>();
        ddButton = GameObject.Find("Double Dutch").GetComponent<Button>();
        player = GameObject.Find("player").GetComponent<Player>();
        toggleAccolades = GameObject.Find("Toggle Accolades").GetComponent<Button>();
    }

    public bool getMode()
    {
        return extremeddMode;
    }

    public void beginextremeddMode()
    {
        rope.setextremeddMode(true);
        rope.goDown = true;
        rope.setmileStone(Random.Range(1, 100));

        extremeddMode = true;
        extremeddButton.gameObject.SetActive(false);
        regularButton.gameObject.SetActive(false);
        ddButton.gameObject.SetActive(false);
        player.setisPlaying(true);
        toggleAccolades.gameObject.SetActive(false);
    }
}
