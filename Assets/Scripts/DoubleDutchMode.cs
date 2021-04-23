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

    [SerializeField]
    GameObject sky;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {

        

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
        player = rope.returnPlayer();
        rope.setddMode(true);
        rope.goUp = true;
        rope.setmileStone(Random.Range(1, 100));
        player.GetComponent<Player>().setisPlaying(true);
        regularButton.gameObject.SetActive(false);
        ddButton.gameObject.SetActive(false);
        extremeddButton.gameObject.SetActive(false);
        accoladesButton.gameObject.SetActive(false);
    }
}
