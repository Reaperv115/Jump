using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleDutchMode : MonoBehaviour
{
    bool doubledutchMode;

    Button regularButton;
    Button ddButton;
    Button extremeddButton;
    Button accoladesButton;

    Rope rope;

    Player player;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("player").GetComponent<Player>();

        regularButton = GameObject.Find("Regular").GetComponent<Button>();
        extremeddButton = GameObject.Find("Extreme Double Dutch").GetComponent<Button>();
        accoladesButton = GameObject.Find("Toggle Accolades").GetComponent<Button>();

        ddButton = GetComponent<Button>();
        ddButton.onClick.AddListener(begindoubleDutch);

        rope = GameObject.Find("rope").GetComponent<Rope>();
    }

    public bool getMode()
    {
        return doubledutchMode;
    }

    public void begindoubleDutch()
    {

        rope.setddMode(true);
        rope.goDown = true;
        rope.setmileStone(Random.Range(1, 100));
        player.setisPlaying(true);
        regularButton.gameObject.SetActive(false);
        ddButton.gameObject.SetActive(false);
        extremeddButton.gameObject.SetActive(false);
        accoladesButton.gameObject.SetActive(false);
    }
}
