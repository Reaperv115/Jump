using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginPlay : MonoBehaviour
{
    Button play;
    Button toggleAccolades;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        play = GetComponent<Button>();
        play.onClick.AddListener(Play);
        player = GameObject.Find("player").GetComponent<Player>();
        toggleAccolades = GameObject.Find("Toggle Accolades").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        GameObject.Find("rope").GetComponent<Rope>().goUp = true;
        player.setisPlaying(true);
        toggleAccolades.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
