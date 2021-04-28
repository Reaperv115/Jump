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


    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rope = GameObject.Find("rope").GetComponent<Rope>();
        extremeddButton = GetComponent<Button>();
        extremeddButton.onClick.AddListener(beginextremeddMode);
        regularButton = GameObject.Find("Regular").GetComponent<Button>();
        ddButton = GameObject.Find("Double Dutch").GetComponent<Button>();
        
        toggleAccolades = GameObject.Find("Toggle Accolades").GetComponent<Button>();
    }

    public bool getMode()
    {
        return extremeddMode;
    }

    public void beginextremeddMode()
    {
        rope.setextremeddMode(true);
        rope.goUp = true;
        rope.setmileStone(Random.Range(1, 100));
        player = rope.returnPlayer();
        extremeddMode = true;
        extremeddButton.gameObject.SetActive(false);
        regularButton.gameObject.SetActive(false);
        ddButton.gameObject.SetActive(false);
        player.GetComponent<Player>().setisPlaying(true);
        toggleAccolades.gameObject.SetActive(false);
    }
}
