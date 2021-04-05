using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeCharacter : MonoBehaviour
{
    Button changeCharacter;
    GameObject player;
    GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        changeCharacter = GetComponent<Button>();
        changeCharacter.onClick.AddListener(changecharacter);

        player = GameObject.Find("player");
        platform = GameObject.Find("platform");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changecharacter()
    {
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(platform);
        SceneManager.LoadScene("Change Character");
    }
}
